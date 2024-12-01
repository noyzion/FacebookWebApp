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
                "public_profile"
                /// add any relevant permissions
                );
            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                buttonLogin.Text = $"Logged in as {m_LoginResult.LoggedInUser.Name}";
                buttonLogin.BackColor = Color.LightGreen;
                pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
                friendsButton.Enabled = true;
                groupsButton.Enabled = true;
                videosButton.Enabled = true;
                likedButton.Enabled = true;
               photosButton.Enabled = true;
                postsButton.Enabled = true;
                postsPicture.Enabled = true;
                photosPicture.Enabled = true;
                friendsPicture.Enabled = true;  
                videosPicture.Enabled = true;
                groupsPicture.Enabled = true;
                        

            }
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

  
        
      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupsButton_Click(object sender, EventArgs e)
        {

        }

        private void friendsButton_Click(object sender, EventArgs e)
        {

        }

        private void videosButton_Click(object sender, EventArgs e)
        {

        }

        private void postsButton_Click(object sender, EventArgs e)
        {

        }

        private void photosButton_Click(object sender, EventArgs e)
        {

        }

        private void likedButton_Click(object sender, EventArgs e)
        {

        }

        private void groupsPicture_Click(object sender, EventArgs e)
        {

        }

        private void likedPicture_Click(object sender, EventArgs e)
        {

        }

        private void friendsPicture_Click(object sender, EventArgs e)
        {

        }

        private void videosPicture_Click(object sender, EventArgs e)
        {

        }

        private void postsPicture_Click(object sender, EventArgs e)
        {

        }

        private void photosPicture_Click(object sender, EventArgs e)
        {

        }

        private void rememberMe_CheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
