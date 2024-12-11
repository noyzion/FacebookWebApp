using FacebookWrapper.ObjectModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class FacebookManager : IFacebookManager
    {
        private FacebookWrapper.LoginResult m_LoginResult;
        public FacebookManager(FacebookWrapper.LoginResult i_LoginResult)
        {
            m_LoginResult = i_LoginResult;
        }
        public void FetchGroups(ListBox i_DataListBox)
        {
            try
            {
                i_DataListBox.DataSource = null;
                i_DataListBox.Items?.Clear();
                i_DataListBox.DisplayMember = "Name";

                foreach (Group group in m_LoginResult.LoggedInUser.Groups)
                {
                    i_DataListBox.Items.Add(group);
                }

                if (i_DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No groups to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching groups: {ex.Message}");
            }
        }
        public void FetchAlbums(ListBox i_DataListBox)
        {
            try
            {
                i_DataListBox.DataSource = null;
                i_DataListBox.Items?.Clear();
                i_DataListBox.DisplayMember = "Name";
                i_DataListBox.DataSource = m_LoginResult.LoggedInUser.Albums;
                if (i_DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No albums to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching albums: {ex.Message}");
            }
        }
        public void FetchFriends(ListBox i_DataListBox)
        {
            try
            {
                i_DataListBox.DataSource = null;
                i_DataListBox.Items?.Clear();
                i_DataListBox.DisplayMember = "Name";
                i_DataListBox.DataSource = m_LoginResult.LoggedInUser.Friends;
                if (i_DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No friends to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching friends: {ex.Message}");
            }
        }
        public void FetchPosts(ListBox i_DataListBox)
        {
            try
            {
                i_DataListBox.DataSource = null;
                i_DataListBox.Items?.Clear();
                i_DataListBox.DisplayMember = "UpdateTime";
                foreach (Post post in m_LoginResult.LoggedInUser.Posts)
                {
                    if (post.Message != null || post.PictureURL != null)
                    {
                        i_DataListBox.Items.Add(post);
                    }
                }

                if (i_DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No posts to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching posts: {ex.Message}");
            }
        }
        public void FetchLikedPages(ListBox i_DataListBox)
        {
            try
            {
                i_DataListBox.DataSource = null;
                i_DataListBox.Items?.Clear();
                i_DataListBox.DisplayMember = "Name";
                foreach (Page page in m_LoginResult.LoggedInUser.LikedPages)
                {
                    i_DataListBox.Items.Add(page);
                }

                if (i_DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No liked pages to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching liked pages: {ex.Message}");
            }
        }
        public void FetchEvents(ListBox i_DataListBox)
        {
            try
            {
                i_DataListBox.DataSource = null;
                i_DataListBox.Items?.Clear();
                i_DataListBox.DisplayMember = "Name";
                foreach (Event fbEvent in m_LoginResult.LoggedInUser.Events)
                {
                    i_DataListBox.Items.Add(fbEvent);
                }

                if (i_DataListBox.Items.Count == 0)
                {
                    MessageBox.Show("No events to retrieve :(");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching events: {ex.Message}");
            }
        }
        public void PostStatus(string i_Message, TextBox i_StatusTextBox)
        {
            try
            {
                Status postedStatus = m_LoginResult.LoggedInUser.PostStatus(i_Message);

                MessageBox.Show($"Status posted! ID: {postedStatus.Id}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                i_StatusTextBox.Clear();
            }
        }
        public Post PostPhoto(string i_FilePath)
        {
            return m_LoginResult.LoggedInUser.PostPhoto(i_FilePath);
        }
        public string AddPhoto()
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
        public string SelectVideoFile()
        {
            string selectedFilePath = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.wmv;*.flv";
                openFileDialog.Title = "Select a Video File to Upload";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                }
            }

            return selectedFilePath;
        }
        public Post PostVideo(string i_FilePath)
        {
            Post newPostVideo = null;

            try
            {
                newPostVideo = m_LoginResult.LoggedInUser.PostPhoto(i_FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while posting the video: {ex.Message}");
            }
            
            return newPostVideo;
        }
        public void MakeFriendsPanel(ref TableLayoutPanel io_DataPanel,User i_User, PictureBox i_PictureBoxProfile)
        {
            try
            {
                Label nameLabel = new Label { Text = $"Name: {i_User.Name}", AutoSize = true };
                Label birthdayLabel = new Label { Text = $"Birthday: {i_User.Birthday}", AutoSize = true };

                io_DataPanel.Controls.Add(nameLabel);
                io_DataPanel.Controls.Add(birthdayLabel);
                PictureBox userPictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(150, 150)
                };

                if (!string.IsNullOrEmpty(i_User.PictureNormalURL))
                {
                    userPictureBox.ImageLocation = i_User.PictureNormalURL;
                }
                else
                {
                    userPictureBox.Image = i_PictureBoxProfile.ErrorImage;
                }

                io_DataPanel.Controls.Add(userPictureBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying friend details: {ex.Message}");
            }
        }
        public void MakeGroupsPanel(ref TableLayoutPanel io_DataPanel,Group i_Group, PictureBox i_PictureBoxProfile)
        {
            try
            {
                if (i_Group != null)
                {
                    Label nameLabel = new Label { Text = $"Group Name: {i_Group.Name}", AutoSize = true };
                    Label membersLabel = new Label { Text = $"Members: {i_Group.Members.Count}", AutoSize = true };
                    Label privacyLabel = new Label { Text = $"Privacy: {i_Group.Privacy}", AutoSize = true };

                    io_DataPanel.Controls.Add(nameLabel);
                    io_DataPanel.Controls.Add(membersLabel);
                    io_DataPanel.Controls.Add(privacyLabel);
                    PictureBox groupPicture = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(150, 150)
                    };

                    if (!string.IsNullOrEmpty(i_Group.PictureNormalURL))
                    {
                        groupPicture.ImageLocation = i_Group.PictureNormalURL;
                    }
                    else
                    {
                        groupPicture.Image = i_PictureBoxProfile.ErrorImage;
                    }

                    io_DataPanel.Controls.Add(groupPicture);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying group details: {ex.Message}");
            }
        }
        public void MakePagePanel(ref TableLayoutPanel io_DataPanel,Page i_Page, PictureBox i_PictureBoxProfile)
        {
            try
            {
                if (i_Page != null)
                {
                    Label nameLabel = new Label { Text = $"Page Name: {i_Page.Name}", AutoSize = true };
                    Label categoryLabel = new Label { Text = $"Category: {i_Page.Category}", AutoSize = true };
                    Label likesLabel = new Label { Text = $"Likes: {i_Page.LikesCount}", AutoSize = true };

                    io_DataPanel.Controls.Add(nameLabel);
                    io_DataPanel.Controls.Add(categoryLabel);
                    io_DataPanel.Controls.Add(likesLabel);
                    PictureBox pagePicture = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(150, 150)
                    };

                    if (!string.IsNullOrEmpty(i_Page.PictureURL))
                    {
                        pagePicture.ImageLocation = i_Page.PictureURL;
                    }
                    else
                    {
                        pagePicture.Image = i_PictureBoxProfile.ErrorImage;
                    }

                    io_DataPanel.Controls.Add(pagePicture);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying page details: {ex.Message}");
            }
        }
        public void MakeEventPanel(ref TableLayoutPanel io_DataPanel,Event i_FbEvent)
        {
            try
            {
                if (i_FbEvent != null)
                {
                    Label nameLabel = new Label { Text = $"Event Name: {i_FbEvent.Name}", AutoSize = true };
                    Label descriptionLabel = new Label { Text = $"Description: {i_FbEvent.Description}", AutoSize = true };
                    Label startTimeLabel = new Label { Text = $"Start Time: {i_FbEvent.StartTime}", AutoSize = true };
                    Label endTimeLabel = new Label { Text = $"End Time: {i_FbEvent.EndTime}", AutoSize = true };
                    Label locationLabel = new Label { Text = $"Location: {i_FbEvent.Location}", AutoSize = true };

                    io_DataPanel.Controls.Add(nameLabel);
                    io_DataPanel.Controls.Add(descriptionLabel);
                    io_DataPanel.Controls.Add(startTimeLabel);
                    io_DataPanel.Controls.Add(endTimeLabel);
                    io_DataPanel.Controls.Add(locationLabel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying event details: {ex.Message}");
            }
        }
        public void MakeAlbumPanel(ref TableLayoutPanel io_DataPanel,Album i_Album, PictureBox i_PictureBoxProfile)
        {
            try
            {
                Label nameLabel = new Label { Text = $"Album Name: {i_Album.Name}", AutoSize = true };
                Label countLabel = new Label { Text = $"Photos: {i_Album.Photos.Count}", AutoSize = true };

                io_DataPanel.Controls.Add(nameLabel);
                io_DataPanel.Controls.Add(countLabel);

                PictureBox albumPicture = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(150, 150)
                };

                if (!string.IsNullOrEmpty(i_Album.PictureAlbumURL))
                {
                    albumPicture.ImageLocation = i_Album.PictureAlbumURL;
                }
                else
                {
                    albumPicture.Image = i_PictureBoxProfile.ErrorImage;
                }

                io_DataPanel.Controls.Add(albumPicture);
                Button openAlbumButton = new Button
                {
                    Text = "Open Album",
                    AutoSize = true
                };

                io_DataPanel.Controls.Add(openAlbumButton);
                openAlbumButton.Click += (sender, e) => openAlbumPhotos(i_Album, i_PictureBoxProfile);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying album details: {ex.Message}");
            }
        }
        public void MakePostPanel(ref TableLayoutPanel io_DataPanel,Post post)
        {
            try
            {
                if (post != null)
                {
                    Label messageLabel = new Label { Text = $"Message: {post.Message}", AutoSize = true };
                    // Label likesLabel = new Label { Text = $"Likes: {post.LikedBy.Count}", AutoSize = true }; // no access
                    // Label commentsLabel = new Label { Text = $"Comments: {post.Comments.Count}", AutoSize = true };

                    io_DataPanel.Controls.Add(messageLabel);
                    // dataPanel.Controls.Add(likesLabel); // no access
                    // dataPanel.Controls.Add(commentsLabel);

                    PictureBox thisPostPicture = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(150, 150)
                    };

                    if (!string.IsNullOrEmpty(post.PictureURL))
                    {
                        thisPostPicture.ImageLocation = post.PictureURL;
                    }

                    io_DataPanel.Controls.Add(thisPostPicture);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying post details: {ex.Message}");
            }
        }
        private void openAlbumPhotos(Album i_Album, PictureBox i_PictureBoxProfile)
        {
            Form albumForm = new Form
            {
                Text = i_Album.Name,
                Width = 450,
                Height = 600
            };

            albumForm.StartPosition = FormStartPosition.CenterScreen;
            FlowLayoutPanel photoPanel = new FlowLayoutPanel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            foreach (Photo photo in i_Album.Photos)
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
                    photoPicture.Image = i_PictureBoxProfile.ErrorImage;
                }
                photoPanel.Controls.Add(photoPicture);
            }

            albumForm.Controls.Add(photoPanel);
            albumForm.ShowDialog();
        }
    }
}