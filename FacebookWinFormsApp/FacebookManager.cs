using FacebookWrapper.ObjectModel;
using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class FacebookManager : IFacebookManager
    {
        private FacebookWrapper.LoginResult m_LoginResult;
        public FacebookManager(FacebookWrapper.LoginResult loginResult)
        {
            m_LoginResult = loginResult;
        }
        public void FetchGroups(ListBox DataListBox)
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
        public void FetchAlbums(ListBox DataListBox)
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
        public void FetchFriends(ListBox DataListBox)
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
        public void FetchPosts(ListBox DataListBox)
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
        public void FetchLikedPages(ListBox DataListBox)
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
        public void FetchEvents(ListBox DataListBox)
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
        public void Post(string message, TextBox statusTextBox)
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
        public Post PostVideo(string filePath)
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
    }
}
