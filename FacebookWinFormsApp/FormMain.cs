using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        AppSettings m_AppSettings;

        public FormMain()
        {
            InitializeComponent();
            m_AppSettings = AppSettings.LoadFromFile();
            this.rememberMe_CheckBox.Checked = m_AppSettings.RememberUser;

            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }

        FacebookWrapper.LoginResult m_LoginResult;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            m_AppSettings.RememberUser = this.rememberMe_CheckBox.Checked;
            if (m_AppSettings.RememberUser)
            {
                m_AppSettings.LastAccessToken = m_LoginResult.AccessToken;
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
               "914564353962957",
                "email",
                "public_profile",
                "user_photos",
                "user_likes",
                "user_videos",
                "user_posts",
                "user_friends",
                "user_events"

                //"publish_to_groups"
                //"groups_access_member_info"
                );

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
            buttonsAfterLogin();
        }

        private void buttonsAfterLogin()
        {
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;
            friendsButton.Enabled = true;
            groupsButton.Enabled = true;
            likedButton.Enabled = true;
            albumsButton.Enabled = true;
            postsButton.Enabled = true;
            postsPicture.Enabled = true;
            photosPicture.Enabled = true;
            friendsPicture.Enabled = true;
            groupsPicture.Enabled = true;
            eventsPictureBox.Enabled = true;
            eventsButton.Enabled = true;
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

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void groupsButton_Click(object sender, EventArgs e)
        {
            fetchGroups();
        }

        private void friendsButton_Click(object sender, EventArgs e)
        {
            fetchFriends();
        }



        private void postsButton_Click(object sender, EventArgs e)
        {
            fetchPosts();
        }

        private void photosButton_Click(object sender, EventArgs e)
        {
            fetchAlbums();
        }

        private void likedButton_Click(object sender, EventArgs e)
        {
            fetchLiked();
        }

        private void groupsPicture_Click(object sender, EventArgs e)
        {
            fetchGroups();
        }

        private void likedPicture_Click(object sender, EventArgs e)
        {
            fetchLiked();
        }

        private void friendsPicture_Click(object sender, EventArgs e)
        {
            fetchFriends();
        }

        private void postsPicture_Click(object sender, EventArgs e)
        {
            fetchPosts();
        }

        private void photosPicture_Click(object sender, EventArgs e)
        {
            fetchAlbums();

        }

        private void rememberMe_CheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void fetchGroups()
        {
            DataListBox.DataSource = null;
            if (DataListBox.Items != null)
                DataListBox.Items.Clear();
            DataListBox.DisplayMember = "Name";
            try
            {
                foreach (Group group in m_LoginResult.LoggedInUser.Groups)
                {
                    DataListBox.Items.Add(group);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (DataListBox.Items.Count == 0)
            {
                MessageBox.Show("No groups to retrive :(");
            }
        }
        private void fetchAlbums()
        {
            DataListBox.DataSource = null;
            if (DataListBox.Items != null)
                DataListBox.Items.Clear();
            DataListBox.DisplayMember = "Name";
            DataListBox.DataSource = m_LoginResult.LoggedInUser.Albums;
        }

        private void fetchFriends()
        {
            DataListBox.DataSource = null;
            if (DataListBox.Items != null)
                DataListBox.Items.Clear();
            DataListBox.DisplayMember = "Name";
            DataListBox.DataSource = m_LoginResult.LoggedInUser.Friends;
        }

        private void fetchPosts()
        {
            DataListBox.DataSource = null;
            if (DataListBox.Items != null)
                DataListBox.Items.Clear();
            DataListBox.DisplayMember = "Name";
            foreach (Post post in m_LoginResult.LoggedInUser.Posts)
            {
                if (post.Message != null)
                    DataListBox.Items.Add(post.Message);
            }

        }

        private void fetchLiked()
        {
            DataListBox.DataSource = null;
            if(DataListBox.Items != null)
            DataListBox.Items.Clear();
            DataListBox.DisplayMember = "Name";
            foreach (Page page in m_LoginResult.LoggedInUser.LikedPages)
            {
                DataListBox.Items.Add(page.Name);
            }
        }

        private void fetchEvents()
        {
            DataListBox.DataSource = null;
            if (DataListBox.Items != null)
                DataListBox.Items.Clear();
            DataListBox.DisplayMember = "Name";
            foreach (Event fbEvent in m_LoginResult.LoggedInUser.Events)
            {
                DataListBox.Items.Add(fbEvent);
            }
            if (DataListBox.Items.Count == 0)
            {
                MessageBox.Show("No events to retrive");
            }
        }

        private void DataListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataListBox.SelectedItems.Count == 1)
            {
                Type type = DataListBox.SelectedItem.GetType();

                if(typeof(Album) == type)
                {
                    Album album =DataListBox.SelectedItem as Album;
                    foreach (Control control in DataPanel.Controls)
                    {
                        if(control is PictureBox)
                        {
                            PictureBox pictureBox = (PictureBox)control;
                            if (album.PictureAlbumURL != null)
                                pictureBox.LoadAsync(album.PictureAlbumURL);
                            else
                                pictureBoxProfile.Image = pictureBoxProfile.ErrorImage;
                        }
                       
                    }
                }

            }
        }

        private void eventsButton_Click(object sender, EventArgs e)
        {
            fetchEvents();
        }

        private void eventsPictureBox_Click(object sender, EventArgs e)
        {
            fetchEvents();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }

}

