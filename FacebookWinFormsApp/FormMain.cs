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
        private readonly AppSettings r_AppSettings;
        private readonly WishlistManager r_WishlistManager;
        private readonly WorkoutManager r_WorkoutManager;
        private FacebookWrapper.LoginResult m_LoginResult;
        private FormAppSettings m_FormAppSettings = null;
        private bool m_IsTextBoxChanged = false;
        private bool m_IsComboBoxChanged = false;
        private FacebookManager m_FacebookManager;
        private readonly DataGridView r_WorkoutTable;

        public FormMain()
        {
            InitializeComponent();
            r_AppSettings = AppSettings.LoadFromFile();
            this.rememberMeCheckBox.Checked = r_AppSettings.RememberUser;
            FacebookWrapper.FacebookService.s_CollectionLimit = 70; // If the limit is bigger, it works but very slow
            r_WishlistManager = r_AppSettings.WishlistManager;
            r_WorkoutManager = r_AppSettings.WorkoutManager;
            r_WorkoutTable = r_WorkoutManager.InitializeWorkoutTable();
            panelWorkouts.Controls.Add(r_WorkoutTable);
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
            r_AppSettings.RememberUser = this.rememberMeCheckBox.Checked;
            if (r_AppSettings.RememberUser)
            {
                r_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
                r_AppSettings.WishlistManager = r_WishlistManager;
                r_AppSettings.WorkoutManager = r_WorkoutManager;
            }
            else
            {
                r_AppSettings.LastAccessToken = null;
            }

            r_AppSettings.SaveToFile();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (r_AppSettings.RememberUser && !string.IsNullOrEmpty(r_AppSettings.LastAccessToken))
            {
                m_LoginResult = FacebookService.Connect(r_AppSettings.LastAccessToken);
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
            r_WorkoutTable.Rows.Clear();
            r_WishlistManager.ResetWishlistUI(checkedListBoxFood, checkedListBoxPets,
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
            m_LoginResult = FacebookService.Login(r_AppSettings.AppID, r_AppSettings.Permissions);
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
                populateCheckBoxListOfWishlist((EWishlistCategories)i);
            }

            buttonsAfterLogin();
            r_WorkoutManager.FetchWorkoutData(r_WorkoutTable);
        }
        private void addPostButton_Click(object sender, EventArgs e)
        {
            m_FacebookManager.PostStatus(textBoxStatus.Text, textBoxStatus);
        }
        private void addPictureButton_Click(object sender, EventArgs e)
        {
            string photoPath = m_FacebookManager.SelectPhotoFile();

            if (string.IsNullOrEmpty(photoPath))
            {
                MessageBox.Show("No photo selected. Please select a photo to post.");
                return;
            }

            m_FacebookManager.PostPhoto(photoPath);
        }
        private void textBoxStatus_TextChanged(object sender, EventArgs e)
        {
            buttonAddPost.Enabled = !string.IsNullOrWhiteSpace(textBoxStatus.Text);
        }
        private void buttonVideo_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedFilePath = m_FacebookManager.SelectVideoFile();

                if (string.IsNullOrEmpty(selectedFilePath))
                {
                    MessageBox.Show("No video selected. Please select a video to upload.");
                    return;
                }

                m_FacebookManager.PostVideo(selectedFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (m_FormAppSettings == null)
            {
                m_FormAppSettings = new FormAppSettings(r_AppSettings);
            }

            if (m_FormAppSettings.ShowDialog() == DialogResult.OK)
            {
                r_AppSettings.SaveToFile();
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
        private void checkItemInList(CheckedListBox i_CheckedListBox, WishListItem i_CheckedItem)
        {
            if (i_CheckedItem.Checked)
            {
                int indexInList = i_CheckedListBox.Items.IndexOf(i_CheckedItem);

                if (indexInList >= 0)
                {
                    i_CheckedListBox.SetItemChecked(indexInList, true);
                }
            }
        }
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            m_IsTextBoxChanged = !string.IsNullOrWhiteSpace(textBoxName.Text);
            updateAddButtonState();
        }
        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_IsComboBoxChanged = (comboBoxCategory.SelectedItem is EWishlistCategories selectedCategory);
            updateAddButtonState();

        }
        private void updateAddButtonState()
        {
            buttonAddPhoto.Enabled = m_IsComboBoxChanged && m_IsTextBoxChanged;
            buttonAdd.Enabled = m_IsTextBoxChanged && m_IsComboBoxChanged;
        }
        private void populateCheckBoxListOfWishlist(EWishlistCategories i_Category)
        {
            foreach (KeyValuePairWrapper kvp in r_AppSettings.WishlistManager.WishlistValues)
            {
                if (i_Category.ToString() == kvp.Key)
                {
                    foreach (WishListItem item in kvp.Value)
                    {
                        switch (i_Category)
                        {
                            case EWishlistCategories.Food:
                                checkedListBoxFood.Items.Add(item);
                                checkItemInList(checkedListBoxFood, item);
                                break;
                            case EWishlistCategories.Shopping:
                                checkedListBoxShopping.Items.Add(item);
                                checkItemInList(checkedListBoxShopping, item);
                                break;
                            case EWishlistCategories.Activities:
                                checkedListBoxActivities.Items.Add(item);
                                checkItemInList(checkedListBoxActivities, item);
                                break;
                            case EWishlistCategories.Pets:
                                checkedListBoxPets.Items.Add(item);
                                checkItemInList(checkedListBoxPets, item);
                                break;
                        }
                    }
                }
            }
        }
        private void buttonAddWithPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                string photoURL = m_FacebookManager.SelectPhotoFile();
                WishListItem newObject = new WishListItem(textBoxName.Text.Trim(), photoURL);

                r_WishlistManager.AddWishToWishlistValues(comboBoxCategory.Text, newObject);
                r_WishlistManager.UpdateCheckedListBox(checkedListBoxFood, checkedListBoxPets,
                                                       checkedListBoxActivities, checkedListBoxShopping,
                                                       comboBoxCategory.Text, newObject);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void buttonAddWithoutPhoto_Click(object sender, EventArgs e)
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

                WishListItem newObject = new WishListItem(itemName);

                r_WishlistManager.AddWishToWishlistValues(category, newObject);
                r_WishlistManager.UpdateCheckedListBox(checkedListBoxFood, checkedListBoxPets,
                                                        checkedListBoxActivities, checkedListBoxShopping,
                                                       category, newObject);
                textBoxName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkedListBoxFood_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(checkedListBoxFood, EWishlistCategories.Food);
        }
        private void checkedListBoxShopping_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(checkedListBoxShopping, EWishlistCategories.Shopping);
        }
        private void checkedListBoxActivities_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(checkedListBoxActivities, EWishlistCategories.Activities);
        }
        private void checkedListBoxPets_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            checkedListBox_ItemCheck(checkedListBoxPets, EWishlistCategories.Pets);
        }
        private void checkedListBox_ItemCheck(CheckedListBox i_List, EWishlistCategories i_Category)
        {
            string itemName = i_List.Text;
            WishListItem wishListItemChecked = findWishListItemByName(i_Category, itemName);

            if (wishListItemChecked != null)
            {
                if (wishListItemChecked.Checked)
                {
                    wishListItemChecked.Checked = false;
                }
                else
                {
                    wishListItemChecked.Checked = true;
                }
            }
        }
        private void checkedListBoxFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            WishListItem wishListItemOfSelectedItem = findWishListItemByName(EWishlistCategories.Food, checkedListBoxFood.Text);

            r_WishlistManager.LoadImageForPictureBoxInList(wishListItemOfSelectedItem, pictureBoxFood);
            buttonDeleteItem.Enabled = true;
        }
        private void checkedListBoxShopping_SelectedIndexChanged(object sender, EventArgs e)
        {
            WishListItem wishListItemOfSelectedItem = findWishListItemByName(EWishlistCategories.Shopping, checkedListBoxActivities.Text);

            r_WishlistManager.LoadImageForPictureBoxInList(wishListItemOfSelectedItem, pictureBoxShopping);
            buttonDeleteItem.Enabled = true;
        }
        private void checkedListBoxPets_SelectedIndexChanged(object sender, EventArgs e)
        {
            WishListItem wishListItemOfSelectedItem = findWishListItemByName(EWishlistCategories.Pets, checkedListBoxPets.Text);

            r_WishlistManager.LoadImageForPictureBoxInList(wishListItemOfSelectedItem, pictureBoxPets);
            buttonDeleteItem.Enabled = true;
        }
        private void checkedListBoxActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            WishListItem wishListItemOfSelectedItem = findWishListItemByName(EWishlistCategories.Activities, checkedListBoxActivities.Text);

            r_WishlistManager.LoadImageForPictureBoxInList(wishListItemOfSelectedItem, pictureBoxActivities);
            buttonDeleteItem.Enabled = true;
        }
        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            deleteSelectedItem(checkedListBoxFood, EWishlistCategories.Food);
            deleteSelectedItem(checkedListBoxActivities, EWishlistCategories.Activities);
            deleteSelectedItem(checkedListBoxPets, EWishlistCategories.Pets);
            deleteSelectedItem(checkedListBoxShopping, EWishlistCategories.Shopping);
            MessageBox.Show("Item deleted successfully.");
        }
        private void deleteSelectedItem(CheckedListBox i_CheckedListBox, EWishlistCategories i_Category)
        {
            if (i_CheckedListBox.SelectedIndex >= 0)
            {
                r_WishlistManager.DeleteWishFromListBox(i_CheckedListBox, i_Category);
            }
        }
        private void buttonPostWishlist_Click(object sender, EventArgs e)
        {
            string postData = r_WishlistManager.ShareWishlist(checkedListBoxFood, checkedListBoxActivities, 
                                                              checkedListBoxPets, checkedListBoxShopping);

            m_FacebookManager.PostStatus(postData, textBoxStatus);
        }
        private WishListItem findWishListItemByName(EWishlistCategories i_Category, string i_ItemName)
        {
            WishListItem foundedWishListItem = null;

            foreach (KeyValuePairWrapper kvp in r_WishlistManager.WishlistValues)
            {
                if (kvp.Key.Equals(i_Category.ToString()))
                {
                    foreach (WishListItem WishListItem in kvp.Value)
                    {
                        if (WishListItem.Text == i_ItemName)
                        {
                            foundedWishListItem = WishListItem;
                        }
                    }
                }
            }
            return foundedWishListItem;
        }
        private void buttonAddWorkout_Click(object sender, EventArgs e)
        {
            AddWorkoutForm addWorkoutForm = new AddWorkoutForm(r_WorkoutTable, r_WorkoutManager);

            addWorkoutForm.ShowDialog();
        }
        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            StatisicsForm statisicsForm = new StatisicsForm(r_WorkoutTable);

            statisicsForm.ShowDialog();
        }
    }
}