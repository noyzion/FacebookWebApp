using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using Microsoft.Win32;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private AppSettings m_AppSettings;
        private WishlistManager m_WishlistManager;
        private WorkoutManager m_WorkoutManager;
        FacebookWrapper.LoginResult m_LoginResult;
        FormAppSettings m_FormAppSettings = null;
        private bool m_IsTextBoxChanged = false;
        private bool m_IsComboBoxChanged = false;
        public DataGridView workoutTable { get; set; }
        private FacebookManager m_FacebookManager;
        public FormMain()
        {
            InitializeComponent();
            m_AppSettings = AppSettings.LoadFromFile();
            this.rememberMeCheckBox.Checked = m_AppSettings.RememberUser;
            FacebookWrapper.FacebookService.s_CollectionLimit = 70; // If the limit is bigger, it works but very slow
            m_WishlistManager = m_AppSettings.m_WishlistManager;
            m_WorkoutManager = m_AppSettings.WorkoutManager;
            InitializeWorkoutTable();
        }
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                pictureBox.BorderStyle = BorderStyle.FixedSingle;
                pictureBox.Width += 5;
                pictureBox.Height += 5;
                pictureBox.BackColor = System.Drawing.Color.LightGray;
            }
        }
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {

            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                pictureBox.BorderStyle = BorderStyle.None;
                pictureBox.Width -= 5;
                pictureBox.Height -= 5;
                pictureBox.BackColor = System.Drawing.Color.Transparent;
            }
        }
        public void InitializeWorkoutTable()
        {
            workoutTable = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnCount = 4
            };

            workoutTable.Columns[0].Name = "Category";
            workoutTable.Columns[1].Name = "Duration";
            workoutTable.Columns[2].Name = "Calories";
            workoutTable.Columns[3].Name = "Date";
            panelWorkouts.Controls.Add(workoutTable);
        }
        private void fetchWorkoutData()
        {
            if (m_WorkoutManager.Workouts != null)
            {
                foreach (var workout in m_WorkoutManager.Workouts)
                {
                    workoutTable.Rows.Add(
                        workout.Category,
                        workout.Duration,
                        workout.Calories,
                        workout.DateTime.ToString("yyyy-MM-dd")
                    );
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            m_AppSettings.RememberUser = this.rememberMeCheckBox.Checked;
            if (m_AppSettings.RememberUser)
            {
                m_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
                m_AppSettings.m_WishlistManager = m_WishlistManager;
                m_AppSettings.WorkoutManager = m_WorkoutManager;
            }
            else
            {
                m_AppSettings.LastAccessToken = null;
            }
            m_AppSettings.SaveToFile();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (m_AppSettings.RememberUser && !string.IsNullOrEmpty(m_AppSettings.LastAccessToken))
            {
                m_LoginResult = FacebookService.Connect(m_AppSettings.LastAccessToken);
                m_FacebookManager = new FacebookManager(m_LoginResult);
                populateUIFromFacebookData();
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (m_LoginResult == null || string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                Login();
            }
        }
        private void checkItem(CheckedListBox checkedListBox, ListObject item)
        {
            if (item.m_Checked)
            {
                int index = checkedListBox.Items.IndexOf(item);
                if (index >= 0)
                {
                    checkedListBox.SetItemChecked(index, true);
                }
            }
        }
        private void buttonsAfterLogin()
        {
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;
            buttonFriends.Enabled = true;
            buttonGroups.Enabled = true;
            buttonLikesPages.Enabled = true;
            buttonAlbums.Enabled = true;
            buttonPosts.Enabled = true;
            postsPicture.Enabled = true;
            photosPicture.Enabled = true;
            friendsPicture.Enabled = true;
            groupsPicture.Enabled = true;
            pictureBoxEventes.Enabled = true;
            eventsButton.Enabled = true;
            buttonAddPicture.Enabled = true;
            textBoxStatus.Enabled = true;
            buttonAddVideo.Enabled = true;
            buttonSettings.Enabled = true;
        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            m_LoginResult = null;
            logoutUIChanges();
        }
        private void logoutUIChanges()
        {

            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            buttonLogin.ForeColor = buttonLogout.ForeColor;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            pictureBoxProfile.ImageLocation = null;
            labelBirthday.Text = "Birthday: ";
            labelEmail.Text = "Email: ";
            workoutTable.Rows.Clear();
            m_WishlistManager.ResetWishlistUI(checkedListBoxFood, checkedListBoxPets,
                                              checkedListBoxActivities, checkedListBoxShopping);

        }
        private void groups_Click(object sender, EventArgs e)
        {
            m_FacebookManager.FetchGroups(dataListBox);
        }
        private void friends_Click(object sender, EventArgs e)
        {
            m_FacebookManager.FetchFriends(dataListBox);
        }
        private void posts_Click(object sender, EventArgs e)
        {
            m_FacebookManager.FetchPosts(dataListBox);
        }
        private void photos_Click(object sender, EventArgs e)
        {
            m_FacebookManager.FetchAlbums(dataListBox);
        }
        private void pages_Click(object sender, EventArgs e)
        {
            m_FacebookManager.FetchLikedPages(dataListBox);
        }
        private void events_Click(object sender, EventArgs e)
        {
            m_FacebookManager.FetchEvents(dataListBox);
        }
        public void Login()
        {
            m_LoginResult = FacebookService.Login(m_AppSettings.AppID, m_AppSettings.Permissions);

            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                populateUIFromFacebookData();
            }
        }
        private void dataListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataListBox.SelectedItems.Count == 1)
            {

                dataPanel.Controls.Clear();
                if (dataListBox.SelectedItem is Post)
                {
                    displayPostDetails(dataListBox.SelectedItem as Post);
                }
                else if (dataListBox.SelectedItem is Album)
                {
                    displayAlbumDetails(dataListBox.SelectedItem as Album);
                }
                else if (dataListBox.SelectedItem is Group)
                {
                    displayGroupDetails(dataListBox.SelectedItem as Group);
                }
                else if (dataListBox.SelectedItem is Page)
                {
                    displayPageDetails(dataListBox.SelectedItem as Page);
                }
                else if (dataListBox.SelectedItem is Event)
                {
                    displayEventDetails(dataListBox.SelectedItem as Event);
                }
                else if (dataListBox.SelectedItem is User)
                {
                    displayFriendsDetails(dataListBox.SelectedItem as User);
                }
            }
        }
        private void displayFriendsDetails(User user)
        {
            try
            {
                if (user != null)
                {
                    Label nameLabel = new Label { Text = $"Name: {user.Name}", AutoSize = true };
                    Label birthdayLabel = new Label { Text = $"Birthday: {user.Birthday}", AutoSize = true };

                    dataPanel.Controls.Add(nameLabel);
                    dataPanel.Controls.Add(birthdayLabel);
                    PictureBox userPictureBox = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(150, 150)
                    };

                    if (!string.IsNullOrEmpty(user.PictureNormalURL))
                    {
                        userPictureBox.ImageLocation = user.PictureNormalURL;
                    }
                    else
                    {
                        userPictureBox.Image = pictureBoxProfile.ErrorImage;
                    }

                    dataPanel.Controls.Add(userPictureBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying friend details: {ex.Message}");
            }
        }
        private void displayGroupDetails(Group group)
        {
            try
            {
                if (group != null)
                {
                    Label nameLabel = new Label { Text = $"Group Name: {group.Name}", AutoSize = true };
                    Label membersLabel = new Label { Text = $"Members: {group.Members.Count}", AutoSize = true };
                    Label privacyLabel = new Label { Text = $"Privacy: {group.Privacy}", AutoSize = true };

                    dataPanel.Controls.Add(nameLabel);
                    dataPanel.Controls.Add(membersLabel);
                    dataPanel.Controls.Add(privacyLabel);

                    PictureBox groupPicture = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(150, 150)
                    };

                    if (!string.IsNullOrEmpty(group.PictureNormalURL))
                    {
                        groupPicture.ImageLocation = group.PictureNormalURL;
                    }
                    else
                    {
                        groupPicture.Image = pictureBoxProfile.ErrorImage;
                    }

                    dataPanel.Controls.Add(groupPicture);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying group details: {ex.Message}");
            }
        }
        private void displayPageDetails(Page page)
        {
            try
            {
                if (page != null)
                {
                    Label nameLabel = new Label { Text = $"Page Name: {page.Name}", AutoSize = true };
                    Label categoryLabel = new Label { Text = $"Category: {page.Category}", AutoSize = true };
                    Label likesLabel = new Label { Text = $"Likes: {page.LikesCount}", AutoSize = true };

                    dataPanel.Controls.Add(nameLabel);
                    dataPanel.Controls.Add(categoryLabel);
                    dataPanel.Controls.Add(likesLabel);

                    PictureBox pagePicture = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(150, 150)
                    };

                    if (!string.IsNullOrEmpty(page.PictureURL))
                    {
                        pagePicture.ImageLocation = page.PictureURL;
                    }
                    else
                    {
                        pagePicture.Image = pictureBoxProfile.ErrorImage;
                    }

                    dataPanel.Controls.Add(pagePicture);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying page details: {ex.Message}");
            }
        }
        private void displayEventDetails(Event fbEvent)
        {
            try
            {
                if (fbEvent != null)
                {
                    Label nameLabel = new Label { Text = $"Event Name: {fbEvent.Name}", AutoSize = true };
                    Label descriptionLabel = new Label { Text = $"Description: {fbEvent.Description}", AutoSize = true };
                    Label startTimeLabel = new Label { Text = $"Start Time: {fbEvent.StartTime}", AutoSize = true };
                    Label endTimeLabel = new Label { Text = $"End Time: {fbEvent.EndTime}", AutoSize = true };
                    Label locationLabel = new Label { Text = $"Location: {fbEvent.Location}", AutoSize = true };

                    dataPanel.Controls.Add(nameLabel);
                    dataPanel.Controls.Add(descriptionLabel);
                    dataPanel.Controls.Add(startTimeLabel);
                    dataPanel.Controls.Add(endTimeLabel);
                    dataPanel.Controls.Add(locationLabel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying event details: {ex.Message}");
            }
        }
        private void displayAlbumDetails(Album album)
        {
            try
            {
                if (album != null)
                {
                    Label nameLabel = new Label { Text = $"Album Name: {album.Name}", RightToLeft = RightToLeft.Yes, AutoSize = true };
                    Label countLabel = new Label { Text = $"Photos: {album.Photos.Count}", RightToLeft = RightToLeft.Yes, AutoSize = true };

                    dataPanel.Controls.Add(nameLabel);
                    dataPanel.Controls.Add(countLabel);

                    PictureBox albumPicture = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(150, 150)
                    };

                    if (!string.IsNullOrEmpty(album.PictureAlbumURL))
                    {
                        albumPicture.ImageLocation = album.PictureAlbumURL;
                    }
                    else
                    {
                        albumPicture.Image = pictureBoxProfile.ErrorImage;
                    }

                    dataPanel.Controls.Add(albumPicture);

                    Button openAlbumButton = new Button
                    {
                        Text = "Open Album",
                        AutoSize = true
                    };

                    dataPanel.Controls.Add(openAlbumButton);

                    openAlbumButton.Click += (sender, e) => openAlbumPhotos(album);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying album details: {ex.Message}");
            }
        }
        private void openAlbumPhotos(Album album)
        {
            Form albumForm = new Form
            {
                Text = album.Name,
                Width = 450,
                Height = 600
            };

            albumForm.StartPosition = FormStartPosition.CenterScreen;

            FlowLayoutPanel photoPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            foreach (Photo photo in album.Photos)
            {
                PictureBox photoPicture = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(200, 200)
                };

                if (!string.IsNullOrEmpty(photo.PictureNormalURL))
                {
                    photoPicture.ImageLocation = photo.PictureNormalURL;
                }
                else
                {
                    photoPicture.Image = pictureBoxProfile.ErrorImage;
                }
                photoPanel.Controls.Add(photoPicture);
            }
            albumForm.Controls.Add(photoPanel);

            albumForm.ShowDialog();
        }
        private void displayPostDetails(Post post)
        {
            if (post != null)
            {

                Label messageLabel = new Label { Text = $"Message:  {post.Message}", AutoSize = true };
              //  Label likesLabel = new Label { Text = $"Likes: {post.LikedBy.Count}", AutoSize = true }; //no access!!!
              //  Label commentsLabel = new Label { Text = $"Comments: {post.Comments.Count}", AutoSize = true };

                dataPanel.Controls.Add(messageLabel);
                //    DataPanel.Controls.Add(likesLabel); //no access!!!
                //    DataPanel.Controls.Add(commentsLabel);

                PictureBox thisPostPicture = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(150, 150)
                };

                if (!string.IsNullOrEmpty(post.PictureURL))
                {
                    thisPostPicture.ImageLocation = post.PictureURL;
                }

                dataPanel.Controls.Add(thisPostPicture);
            }
        }
        private void populateCheckBoxListOfWishlist(int i, EWishlistCategories category)
        {
            foreach (var kvp in m_AppSettings.m_WishlistManager.m_WishlistValues)
            {
                if (category.ToString() == kvp.Key)
                {

                    foreach (var item in kvp.Value)
                    {
                        switch (category)
                        {
                            case EWishlistCategories.food:
                                checkedListBoxFood.Items.Add(item);
                                checkItem(checkedListBoxFood, item);
                                break;
                            case EWishlistCategories.shopping:
                                checkedListBoxShopping.Items.Add(item);
                                checkItem(checkedListBoxShopping, item);
                                break;
                            case EWishlistCategories.activities:
                                checkedListBoxActivities.Items.Add(item);
                                checkItem(checkedListBoxActivities, item);
                                break;

                            case EWishlistCategories.pets:
                                checkedListBoxPets.Items.Add(item);
                                checkItem(checkedListBoxPets, item);
                                break;

                        }
                    }

                }
            }
        }
        public void populateUIFromFacebookData()
        {
            this.Text = $"{m_LoginResult.LoggedInUser.Name} Facebook App";
            buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
            buttonLogin.BackColor = Color.LightGreen;
            pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;

            labelBirthday.Text = $"Birthday:  {m_LoginResult.LoggedInUser.Birthday}";
            labelEmail.Text = $"Email: {m_LoginResult.LoggedInUser?.Email}";
            for (int i = 0; i < Enum.GetValues(typeof(EWishlistCategories)).Length; i++)
            {
                EWishlistCategories category = (EWishlistCategories)i;
                populateCheckBoxListOfWishlist(i, (EWishlistCategories)i);
            }
            buttonsAfterLogin();
            fetchWorkoutData();
        }
        private void addPostButton_Click(object sender, EventArgs e)
        {
            m_FacebookManager.Post(textBoxStatus.Text, textBoxStatus);
        }
        private void addPictureButton_Click(object sender, EventArgs e)
        {

            string photoPath = m_FacebookManager.AddPhoto();

            if (string.IsNullOrEmpty(photoPath))
            {
                MessageBox.Show("No photo selected. Please select a photo to post.");
                return;
            }

            Post postedPhoto = m_LoginResult.LoggedInUser.PostPhoto(photoPath);
        }
        private void textBoxStatus_TextChanged(object sender, EventArgs e)
        {
            buttonAddPost.Enabled = !string.IsNullOrWhiteSpace(textBoxStatus.Text);
        }
        private void buttonVideo_Click(object sender, EventArgs e)
        {
            string selectedFilePath = m_FacebookManager.SelectVideoFile();

            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("No video selected. Please select a video to upload.");
                return;
            }

            Post postedVideo = m_FacebookManager.PostVideo(selectedFilePath);
        }
        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {
            using (OpenProfilePicture optionsForm = new OpenProfilePicture())
            {
                if (optionsForm.ShowDialog() == DialogResult.OK)
                {
                    switch (optionsForm.SelectedOption)
                    {
                        case EProfileOption.ShowProfile:
                            showProfile();
                            break;

                        case EProfileOption.ChangeProfile:
                            addPictureButton_Click(sender, e);
                            break;
                    }
                }
            }
        }
        private void showProfile()
        {
            try
            {
                string profilePictureUrl = m_LoginResult.LoggedInUser.PictureLargeURL;

                PictureBox profilePictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(600, 600),
                    Location = new Point(0, 0),
                    BorderStyle = BorderStyle.FixedSingle
                };

                profilePictureBox.Load(profilePictureUrl);

                Form profileForm = new Form
                {
                    Text = "Profile Picture",
                    Size = new Size(600, 600),
                };

                profileForm.Controls.Add(profilePictureBox);
                profileForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load the profile picture: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private ListObject findListObjectByName(EWishlistCategories category, string itemName)
        {
            foreach (var kvp in m_WishlistManager.m_WishlistValues)
            {
                if (kvp.Key.Equals(category.ToString()))
                {
                    foreach (var listObject in kvp.Value)
                    {
                        if (listObject.m_Text == itemName)
                        {
                            return listObject;
                        }
                    }
                }
            }
            return null;
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (m_FormAppSettings == null)
            {
                m_FormAppSettings = new FormAppSettings(m_AppSettings);
            }

            if (m_FormAppSettings.ShowDialog() == DialogResult.OK)
            {
                m_AppSettings.SaveToFile();

                DialogResult reLoginDialog = MessageBox.Show(
                    "Permissions have been updated. You need to log in again to apply the changes. Proceed?",
                    "Re-login Required",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (reLoginDialog == DialogResult.Yes)
                {
                    Login();
                }
            }
        }
        private void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                ListObject newObject = new ListObject(textBoxName.Text.Trim(), m_FacebookManager.AddPhoto());
                m_WishlistManager.AddWishToWishlistValues(comboBoxCategory.Text, newObject);
                m_WishlistManager.UpdateCheckedListBox(checkedListBoxFood, checkedListBoxPets,
                                                       checkedListBoxActivities, checkedListBoxShopping,
                                                       comboBoxCategory.Text, newObject);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string category = comboBoxCategory.Text;
                string itemName = textBoxName.Text.Trim();

                if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(itemName))
                {
                    MessageBox.Show("Please provide both a category and item name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ListObject newObject = new ListObject(itemName);
                m_WishlistManager.AddWishToWishlistValues(category, newObject);
                m_WishlistManager.UpdateCheckedListBox(checkedListBoxFood, checkedListBoxPets,
                                                        checkedListBoxActivities, checkedListBoxShopping,
                                                       category, newObject);
                textBoxName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            m_IsTextBoxChanged = !string.IsNullOrWhiteSpace(textBoxName.Text);
            updateAddButtonState();
        }
        private void comboBoxCategory_TextChanged(object sender, EventArgs e)
        {
            m_IsComboBoxChanged = !string.IsNullOrWhiteSpace(comboBoxCategory.Text);
            updateAddButtonState();
        }
        private void updateAddButtonState()
        {
            buttonAddPhoto.Enabled = m_IsComboBoxChanged && m_IsTextBoxChanged;
            buttonAdd.Enabled = m_IsTextBoxChanged && m_IsComboBoxChanged;
        }
        private void checkedListBoxFood_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(sender, e, checkedListBoxFood, EWishlistCategories.food);
        }
        private void checkedListBoxShopping_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(sender, e, checkedListBoxShopping, EWishlistCategories.shopping);
        }
        private void checkedListBoxActivities_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(sender, e, checkedListBoxActivities, EWishlistCategories.activities);
        }
        private void checkedListBoxPets_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(sender, e, checkedListBoxPets, EWishlistCategories.pets);
        }
        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e, CheckedListBox list, EWishlistCategories category)
        {
            string itemName = list.Text;
            ListObject listObject = findListObjectByName(category, itemName);
            if (listObject != null)
            {
                if (listObject.m_Checked)
                    listObject.m_Checked = false;
                else
                    listObject.m_Checked = true;
            }
        }
        private void checkedListBoxFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListObject listObject = findListObjectByName(EWishlistCategories.food, checkedListBoxFood.Text);
            m_WishlistManager.LoadImageForPictureBoxInList(listObject, pictureBoxFood);
            buttonDeleteItem.Enabled = true;
        }
        private void checkedListBoxShopping_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListObject listObject = findListObjectByName(EWishlistCategories.shopping, checkedListBoxActivities.Text);
            m_WishlistManager.LoadImageForPictureBoxInList(listObject, pictureBoxShopping);
            buttonDeleteItem.Enabled = true;
        }
        private void checkedListBoxPets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListObject listObject = findListObjectByName(EWishlistCategories.pets, checkedListBoxPets.Text);
            m_WishlistManager.LoadImageForPictureBoxInList(listObject, pictureBoxPets);
            buttonDeleteItem.Enabled = true;

        }
        private void checkedListBoxActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListObject listObject = findListObjectByName(EWishlistCategories.activities, checkedListBoxActivities.Text);
            m_WishlistManager.LoadImageForPictureBoxInList(listObject, pictureBoxActivities);
            buttonDeleteItem.Enabled = true;

        }
        private void buttonPost_Click(object sender, EventArgs e)
        {
            string postData = m_WishlistManager.ShareWishlist(checkedListBoxFood, checkedListBoxActivities, checkedListBoxPets, checkedListBoxShopping);
            m_FacebookManager.Post(postData, textBoxStatus);
        }
        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            if (checkedListBoxFood.SelectedIndex >= 0)
            {
                m_WishlistManager.DeleteWishFromListBox(checkedListBoxFood, EWishlistCategories.food);
            }
            if (checkedListBoxActivities.SelectedIndex >= 0)
            {
                m_WishlistManager.DeleteWishFromListBox(checkedListBoxActivities, EWishlistCategories.activities);
            }
            if (checkedListBoxPets.SelectedIndex >= 0)
            {
                m_WishlistManager.DeleteWishFromListBox(checkedListBoxPets, EWishlistCategories.pets);

            }
            if (checkedListBoxShopping.SelectedIndex >= 0)
            {
                m_WishlistManager.DeleteWishFromListBox(checkedListBoxShopping, EWishlistCategories.shopping);
            }
            MessageBox.Show("Item deleted successfully.");
        }
        private void buttonAddWorkout_Click(object sender, EventArgs e)
        {
            AddWorkoutForm addWorkoutForm = new AddWorkoutForm(workoutTable, m_WorkoutManager);
            addWorkoutForm.ShowDialog();
        }
        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            StatisicsForm statisicsForm = new StatisicsForm(workoutTable);
            statisicsForm.ShowDialog();
        }
    }
}

