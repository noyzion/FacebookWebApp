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
        private FacebookWrapper.LoginResult m_LoginResult;
        private FormAppSettings m_FormAppSettings = null;
        private bool m_IsTextBoxChanged = false;
        private bool m_IsComboBoxChanged = false;
        private FacebookManager m_FacebookManager;
        private DataGridView m_WorkoutTable;

        public FormMain()
        {
            InitializeComponent();
            m_AppSettings = AppSettings.LoadFromFile();
            this.rememberMeCheckBox.Checked = m_AppSettings.RememberUser;
            FacebookWrapper.FacebookService.s_CollectionLimit = 70; // If the limit is bigger, it works but very slow
            m_WishlistManager = m_AppSettings.WishlistManager;
            m_WorkoutManager = m_AppSettings.WorkoutManager;
            m_WorkoutTable = m_WorkoutManager.InitializeWorkoutTable();
            panelWorkouts.Controls.Add(m_WorkoutTable);
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            m_AppSettings.RememberUser = this.rememberMeCheckBox.Checked;
            if (m_AppSettings.RememberUser)
            {
                m_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
                m_AppSettings.WishlistManager = m_WishlistManager;
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
            m_WorkoutTable.Rows.Clear();
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
                   m_FacebookManager.MakePostPanel(ref dataPanel,dataListBox.SelectedItem as Post);
                }
                else if (dataListBox.SelectedItem is Album)
                {
                    m_FacebookManager.MakeAlbumPanel(ref dataPanel,dataListBox.SelectedItem as Album, 
                                                     pictureBoxProfile);
                }
                else if (dataListBox.SelectedItem is Group)
                {
                    m_FacebookManager.MakeGroupsPanel(ref dataPanel,dataListBox.SelectedItem as Group, 
                                                      pictureBoxProfile);
                }
                else if (dataListBox.SelectedItem is Page)
                {
                    m_FacebookManager.MakePagePanel(ref dataPanel,dataListBox.SelectedItem as Page, 
                                                    pictureBoxProfile);
                }
                else if (dataListBox.SelectedItem is Event)
                {
                  m_FacebookManager.MakeEventPanel(ref dataPanel,dataListBox.SelectedItem as Event);
                }
                else if (dataListBox.SelectedItem is User)
                {
                    m_FacebookManager.MakeFriendsPanel(ref dataPanel,dataListBox.SelectedItem as User,
                                                       pictureBoxProfile);
                }
            }
        }
        private void populateCheckBoxListOfWishlist(int i, EWishlistCategories category)
        {
            foreach (var kvp in m_AppSettings.WishlistManager.WishlistValues)
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
            m_WorkoutManager.FetchWorkoutData(m_WorkoutTable);
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
            ListObject foundedListObject = null;

            foreach (KeyValuePairWrapper kvp in m_WishlistManager.WishlistValues)
            {
                if (kvp.Key.Equals(category.ToString()))
                {
                    foreach (ListObject listObject in kvp.Value)
                    {
                        if (listObject.Text == itemName)
                        {
                            foundedListObject = listObject;
                        }
                    }
                }
            }
            return foundedListObject;
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
                string photoURL = m_FacebookManager.AddPhoto();
                ListObject newObject = new ListObject(textBoxName.Text.Trim(), photoURL);

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
                {
                    listObject.m_Checked = false;
                }
                else
                {
                    listObject.m_Checked = true;
                }
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
            AddWorkoutForm addWorkoutForm = new AddWorkoutForm(m_WorkoutTable, m_WorkoutManager);

            addWorkoutForm.ShowDialog();
        }
        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            StatisicsForm statisicsForm = new StatisicsForm(m_WorkoutTable);

            statisicsForm.ShowDialog();
        }
    }
}

