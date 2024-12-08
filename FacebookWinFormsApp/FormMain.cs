﻿using System;
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
        private Tab2Manager m_Tab2Manager;
        private WorkoutManager m_workoutManager;
        FacebookWrapper.LoginResult m_LoginResult;
        FormAppSettings m_FormAppSettings = null;
        private bool isTextBoxChanged = false;
        private bool isComboBoxChanged = false;
        public DataGridView workoutTable { get; set; }

        public FormMain()
        {
            InitializeComponent();
            m_AppSettings = AppSettings.LoadFromFile();
            this.rememberMe_CheckBox.Checked = m_AppSettings.RememberUser;
            FacebookWrapper.FacebookService.s_CollectionLimit = 70; // If the limit is bigger, it works but very slow
            m_Tab2Manager = m_AppSettings.Tab2Manager;
            m_workoutManager = m_AppSettings.WorkoutManager;
            InitializeWorkoutTable();
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

            if (m_workoutManager.Workouts != null)
            {
                foreach (var workout in m_workoutManager.Workouts)
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
            m_AppSettings.RememberUser = this.rememberMe_CheckBox.Checked;
            if (m_AppSettings.RememberUser)
            {
                m_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
                m_AppSettings.Tab2Manager = m_Tab2Manager;
                m_AppSettings.WorkoutManager = m_workoutManager;
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
                populateUIFromFacebookData();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");

            if (m_LoginResult == null || string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                login();
            }
        }

        private void login()
        {
            m_LoginResult = FacebookService.Login(
              m_AppSettings.s_AppID, m_AppSettings.s_Permissions);

            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                populateUIFromFacebookData();
            }
        }


        private void populateUIFromFacebookData()
        {
            this.Text = $"{m_LoginResult.LoggedInUser.Name} Facebook App";
            buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
            buttonLogin.BackColor = Color.LightGreen;
            pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;

            birthdayLabel.Text = $"Birthday:  {m_LoginResult.LoggedInUser.Birthday}";
            emailLabel.Text = $"Email: {m_LoginResult.LoggedInUser?.Email}";
            for (int i = 0; i < Enum.GetValues(typeof(EWishlistCategories)).Length; i++)
            {
                EWishlistCategories category = (EWishlistCategories)i;
                populateCheckBoxListOfWishlist(i, (EWishlistCategories)i);
            }
            buttonsAfterLogin();
        }

        private void populateCheckBoxListOfWishlist(int i, EWishlistCategories category)
        {
            foreach (var kvp in m_AppSettings.Tab2Manager.m_WishlistValues)
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
            friendsButton.Enabled = true;
            groupsButton.Enabled = true;
            pagesButton.Enabled = true;
            albumsButton.Enabled = true;
            postsButton.Enabled = true;
            postsPicture.Enabled = true;
            photosPicture.Enabled = true;
            friendsPicture.Enabled = true;
            groupsPicture.Enabled = true;
            eventsPictureBox.Enabled = true;
            eventsButton.Enabled = true;
            addPictureButton.Enabled = true;
            statusTextBox.Enabled = true;
            videoButton.Enabled = true;
            settingsButton.Enabled = true;
        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = buttonLogout.BackColor;
            buttonLogin.ForeColor = buttonLogout.ForeColor;
            m_LoginResult = null;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }

        private void groups_Click(object sender, EventArgs e)
        {
            fetchGroups();
        }

        private void friends_Click(object sender, EventArgs e)
        {
            fetchFriends();
        }

        private void posts_Click(object sender, EventArgs e)
        {
            fetchPosts();
        }

        private void photos_Click(object sender, EventArgs e)
        {
            fetchAlbums();
        }

        private void pages_Click(object sender, EventArgs e)
        {
            fetchLiked();
        }

        private void events_Click(object sender, EventArgs e)
        {
            fetchEvents();
        }

        private void fetchGroups()
        {
            try
            {
                DataListBox.DataSource = null;
                DataListBox.Items?.Clear();
                DataListBox.DisplayMember = "Name";

                foreach (Group group in m_LoginResult.LoggedInUser.Groups)
                {
                    DataListBox.Items.Add(group);
                }

                if (DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No groups to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching groups: {ex.Message}");
            }
        }

        private void fetchAlbums()
        {
            try
            {
                DataListBox.DataSource = null;
                DataListBox.Items?.Clear();
                DataListBox.DisplayMember = "Name";

                DataListBox.DataSource = m_LoginResult.LoggedInUser.Albums;

                if (DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No albums to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching albums: {ex.Message}");
            }
        }

        private void fetchFriends()
        {
            try
            {
                DataListBox.DataSource = null;
                DataListBox.Items?.Clear();
                DataListBox.DisplayMember = "Name";

                DataListBox.DataSource = m_LoginResult.LoggedInUser.Friends;

                if (DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No friends to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching friends: {ex.Message}");
            }
        }

        private void fetchPosts()
        {
            try
            {
                DataListBox.DataSource = null;
                DataListBox.Items?.Clear();
                DataListBox.DisplayMember = "UpdateTime";

                foreach (Post post in m_LoginResult.LoggedInUser.Posts)
                {
                    if (post.Message != null || post.PictureURL != null)
                    {
                        DataListBox.Items.Add(post);
                    }
                }

                if (DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No posts to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching posts: {ex.Message}");
            }
        }

        private void fetchLiked()
        {
            try
            {
                DataListBox.DataSource = null;
                DataListBox.Items?.Clear();
                DataListBox.DisplayMember = "Name";

                foreach (Page page in m_LoginResult.LoggedInUser.LikedPages)
                {
                    DataListBox.Items.Add(page);
                }

                if (DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No liked pages to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching liked pages: {ex.Message}");
            }
        }

        private void fetchEvents()
        {
            try
            {
                DataListBox.DataSource = null;
                DataListBox.Items?.Clear();
                DataListBox.DisplayMember = "Name";

                foreach (Event fbEvent in m_LoginResult.LoggedInUser.Events)
                {
                    DataListBox.Items.Add(fbEvent);
                }

                if (DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No events to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching events: {ex.Message}");
            }
        }

        private void DataListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataListBox.SelectedItems.Count == 1)
            {

                DataPanel.Controls.Clear();
                if (DataListBox.SelectedItem is Post)
                {
                    displayPostDetails(DataListBox.SelectedItem as Post);
                }
                else if (DataListBox.SelectedItem is Album)
                {
                    displayAlbumDetails(DataListBox.SelectedItem as Album);
                }
                else if (DataListBox.SelectedItem is Group)
                {
                    displayGroupDetails(DataListBox.SelectedItem as Group);
                }
                else if (DataListBox.SelectedItem is Page)
                {
                    displayPageDetails(DataListBox.SelectedItem as Page);
                }
                else if (DataListBox.SelectedItem is Event)
                {
                    displayEventDetails(DataListBox.SelectedItem as Event);
                }
                else if (DataListBox.SelectedItem is User)
                {
                    displayFriendsDetails(DataListBox.SelectedItem as User);
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
                    DataPanel.Controls.Add(nameLabel);

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

                    DataPanel.Controls.Add(userPictureBox);
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

                    DataPanel.Controls.Add(nameLabel);
                    DataPanel.Controls.Add(membersLabel);
                    DataPanel.Controls.Add(privacyLabel);

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

                    DataPanel.Controls.Add(groupPicture);
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

                    DataPanel.Controls.Add(nameLabel);
                    DataPanel.Controls.Add(categoryLabel);
                    DataPanel.Controls.Add(likesLabel);

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

                    DataPanel.Controls.Add(pagePicture);
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

                    DataPanel.Controls.Add(nameLabel);
                    DataPanel.Controls.Add(descriptionLabel);
                    DataPanel.Controls.Add(startTimeLabel);
                    DataPanel.Controls.Add(endTimeLabel);
                    DataPanel.Controls.Add(locationLabel);
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

                    DataPanel.Controls.Add(nameLabel);
                    DataPanel.Controls.Add(countLabel);

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

                    DataPanel.Controls.Add(albumPicture);

                    Button openAlbumButton = new Button
                    {
                        Text = "Open Album",
                        AutoSize = true
                    };

                    DataPanel.Controls.Add(openAlbumButton);

                    openAlbumButton.Click += (sender, e) => OpenAlbumPhotos(album);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying album details: {ex.Message}");
            }
        }

        private void OpenAlbumPhotos(Album album)
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
                //   Label likesLabel = new Label { Text = $"Likes: {post.LikedBy.Count}", AutoSize = true };
                //    Label commentsLabel = new Label { Text = $"Comments: {post.Comments.Count}", AutoSize = true };

                DataPanel.Controls.Add(messageLabel);
                //    DataPanel.Controls.Add(likesLabel);
                //     DataPanel.Controls.Add(commentsLabel);

                // foreach (Comment comment in post.Comments)
                //     {
                //       DataPanel.Controls.Add(new Label { Text = $"Comment: {comment.Message}", AutoSize = true });
                // }
                PictureBox thisPostPicture = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(150, 150)
                };

                if (!string.IsNullOrEmpty(post.PictureURL))
                {
                    thisPostPicture.ImageLocation = post.PictureURL;
                }

                DataPanel.Controls.Add(thisPostPicture);
            }
        }


        private void addPostButton_Click(object sender, EventArgs e)
        {
             post(statusTextBox.Text);         
        }
        private void post(string message)
        {
            try
            {
                Status postedStatus = m_LoginResult.LoggedInUser.PostStatus(message);
                MessageBox.Show($"Status posted! ID: {postedStatus.Id}");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                statusTextBox.Clear();

            }
        }

        private void addPictureButton_Click(object sender, EventArgs e)
        {

            string photoPath = addPhoto();

            if (string.IsNullOrEmpty(photoPath))
            {
                MessageBox.Show("No photo selected. Please select a photo to post.");
                return;
            }

            Post postedPhoto = m_LoginResult.LoggedInUser.PostPhoto(photoPath);
        }
  
        private string addPhoto()
        {
            string selectedFilePath = null;
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    openFileDialog.Title = "Select a Picture to Upload";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        selectedFilePath = openFileDialog.FileName;
                    }
                }
                return selectedFilePath;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {
            addPostButton.Enabled = !string.IsNullOrWhiteSpace(statusTextBox.Text);
        }

        private void videoButton_Click(object sender, EventArgs e)
        {
            string selectedFilePath = SelectVideoFile();

            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("No video selected. Please select a video to upload.");
                return;
            }

            Post postedVideo = PostVideo(selectedFilePath);
        }

        private string SelectVideoFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv;*.flv";
                openFileDialog.Title = "Select a Video File to Upload";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }

            return null;
        }

        private Post PostVideo(string filePath)
        {
            try
            {
                return m_LoginResult.LoggedInUser.PostPhoto(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while posting the video: {ex.Message}");
                return null;
            }
        }

        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {
            using (OpenProfilePicture optionsForm = new OpenProfilePicture())
            {
                if (optionsForm.ShowDialog() == DialogResult.OK)
                {
                    switch (optionsForm.SelectedOption)
                    {
                        case ProfileOption.ShowProfile:
                            ShowProfile();
                            break;

                        case ProfileOption.ChangeProfile:
                            addPictureButton_Click(sender, e);
                            break;
                    }
                }
            }
        }

        private void ShowProfile()
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

        private void settingsButton_Click(object sender, EventArgs e)
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
                    login();
                }
            }
        }

        private void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            m_Tab2Manager.AddToWishlist(comboBoxCategory.Text, new ListObject(textBoxName.Text, addPhoto()));
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string category = comboBoxCategory.Text;
                string itemName = textBoxName.Text;

                if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(itemName))
                {
                    MessageBox.Show("Please provide both a category and item name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddItemToWishlist(category, itemName);
                UpdateCheckedListBox(category, itemName);
                textBoxName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddItemToWishlist(string category, string itemName)
        {
            try
            {
                if (m_Tab2Manager.m_WishlistValues == null)
                {
                    m_Tab2Manager.m_WishlistValues = new List<KeyValuePairWrapper>();
                }

                var existingCategory = m_Tab2Manager.m_WishlistValues.FirstOrDefault(kvp => kvp.Key == category);

                if (existingCategory != null)
                {
                    bool itemExists = existingCategory.Value.Any(item => item.m_Text == itemName);
                    if (!itemExists)
                    {
                        existingCategory.Value.Add(new ListObject(itemName));
                    }
                }
                else
                {
                    m_Tab2Manager.AddToWishlist(category, new ListObject(itemName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding to wishlist: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void UpdateCheckedListBox(string category, string itemName)
        {
            try
            {
                switch (category)
                {
                    case nameof(EWishlistCategories.food):
                        checkedListBoxFood.Items.Add(itemName);
                        break;

                    case nameof(EWishlistCategories.shopping):
                        checkedListBoxShopping.Items.Add(itemName);
                        break;

                    case nameof(EWishlistCategories.activities):
                        checkedListBoxActivities.Items.Add(itemName);
                        break;

                    case nameof(EWishlistCategories.pets):
                        checkedListBoxPets.Items.Add(itemName);
                        break;

                    default:
                        MessageBox.Show("Invalid category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the checked list box: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw; 
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            isTextBoxChanged = !string.IsNullOrWhiteSpace(textBoxName.Text);
            UpdateAddButtonState();
        }

        private void comboBoxCategory_TextChanged(object sender, EventArgs e)
        {
            isComboBoxChanged = !string.IsNullOrWhiteSpace(comboBoxCategory.Text);
            UpdateAddButtonState();
        }

        private void UpdateAddButtonState()
        {
            buttonAddPhoto.Enabled = isComboBoxChanged && isTextBoxChanged;
            buttonAdd.Enabled = isTextBoxChanged && isComboBoxChanged;
        }

        private void checkedListBoxFood_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(sender, e, checkedListBoxFood);
        }

        private void checkedListBoxShopping_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(sender, e, checkedListBoxShopping);
        }
        private void checkedListBoxActivities_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(sender, e, checkedListBoxActivities);
        }
        private void checkedListBoxPets_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(sender, e, checkedListBoxPets);
        }
        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e, CheckedListBox list)
        {
            string itemName = list.Text;
            ListObject listObject = m_Tab2Manager.FindListObjectByName(itemName);
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
            m_Tab2Manager.loadImageForPictureBoxInList(checkedListBoxFood, pictureBoxFood);
            buttonDeleteItem.Enabled = true;
        }
        private void checkedListBoxShopping_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_Tab2Manager.loadImageForPictureBoxInList(checkedListBoxShopping, pictureBoxShopping);
            buttonDeleteItem.Enabled = true;
        }
        private void checkedListBoxPets_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_Tab2Manager.loadImageForPictureBoxInList(checkedListBoxPets, pictureBoxPets);
            buttonDeleteItem.Enabled = true;

        }
        private void checkedListBoxActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_Tab2Manager.loadImageForPictureBoxInList(checkedListBoxActivities, pictureBoxActivities);
            buttonDeleteItem.Enabled = true;

        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
          string postData=  m_Tab2Manager.ShareWishlist(checkedListBoxFood, checkedListBoxActivities, checkedListBoxPets, checkedListBoxShopping);
            post(postData);
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            if (checkedListBoxFood.SelectedIndex >= 0)
            {
                m_Tab2Manager.deleteFromList(checkedListBoxFood, EWishlistCategories.food);
            }
            if (checkedListBoxActivities.SelectedIndex >= 0)
            {
                m_Tab2Manager.deleteFromList(checkedListBoxActivities, EWishlistCategories.activities);
            }
            if (checkedListBoxPets.SelectedIndex >= 0)
            {
                m_Tab2Manager.deleteFromList(checkedListBoxPets, EWishlistCategories.pets);

            }
            if (checkedListBoxShopping.SelectedIndex >= 0)
            {
                m_Tab2Manager.deleteFromList(checkedListBoxShopping, EWishlistCategories.shopping);
            }
            MessageBox.Show("Item deleted successfully.");
        }

        private void buttonAddWorkout_Click(object sender, EventArgs e)
        {
            AddWorkoutForm addWorkoutForm = new AddWorkoutForm(workoutTable, m_workoutManager);
            addWorkoutForm.ShowDialog();
        }

        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            StatisicsForm statisicsForm  = new StatisicsForm(workoutTable);
            statisicsForm.ShowDialog();
        }
    }
}

