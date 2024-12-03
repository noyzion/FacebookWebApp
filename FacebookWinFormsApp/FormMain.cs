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
using Microsoft.Win32;

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
                "user_events",
                "user_birthday"
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

            birthdayLabel.Text = $"Birthday:  {m_LoginResult.LoggedInUser.Birthday}";
            emailLabel.Text = $"Email: {m_LoginResult.LoggedInUser?.Email}";
            buttonsAfterLogin();
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

        private void pagesButton_Click(object sender, EventArgs e)
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
            DataListBox.DisplayMember = "UpdateTime";
            foreach (Post post in m_LoginResult.LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    DataListBox.Items.Add(post);
                }
                else if (post.PictureURL != null)
                {
                    DataListBox.Items.Add(post);
                }

            }
        }

        private void fetchLiked()
        {
            DataListBox.DataSource = null;
            if (DataListBox.Items != null)
                DataListBox.Items.Clear();
            DataListBox.DisplayMember = "Name";
            foreach (Page page in m_LoginResult.LoggedInUser.LikedPages)
            {
                DataListBox.Items.Add(page);
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
            }
        }

        private void displayGroupDetails(Group group)
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



        private void displayPageDetails(Page page)
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

        private void displayEventDetails(Event fbEvent)
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

        private void displayAlbumDetails(Album album)
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

        private void eventsButton_Click(object sender, EventArgs e)
        {
            fetchEvents();
        }

        private void eventsPictureBox_Click(object sender, EventArgs e)
        {
            fetchEvents();
        }

        private void addPostButton_Click(object sender, EventArgs e)
        {
            try
            {
                Status postedStatus = m_LoginResult.LoggedInUser.PostStatus(statusTextBox.Text);
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
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    openFileDialog.Title = "Select a Picture to Upload";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFilePath = openFileDialog.FileName;

                        Post postedPhoto = m_LoginResult.LoggedInUser.PostPhoto(selectedFilePath, "Uploaded via MyApp");
                        MessageBox.Show($"Photo posted successfully! ID: {postedPhoto?.Id}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {
            addPostButton.Enabled = !string.IsNullOrWhiteSpace(statusTextBox.Text);
        }

        private void videoButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Filter to accept only video file formats
                    openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv;*.flv";
                    openFileDialog.Title = "Select a Video File to Upload";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFilePath = openFileDialog.FileName;

                        // Upload the video
                        Post postedVideo = m_LoginResult.LoggedInUser.PostPhoto(selectedFilePath, "Uploaded via MyApp");
                        MessageBox.Show($"Video posted successfully! ID: {postedVideo?.Id}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
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
                            addPictureButton_Click(sender,e);
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

        private void ChangeProfile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select a Profile Picture"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProfile.ImageLocation = openFileDialog.FileName;
            }
        }

        private void tab1_Click(object sender, EventArgs e)
        {

        }
    }
}

