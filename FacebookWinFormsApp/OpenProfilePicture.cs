using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public enum ProfileOption
    {
        ShowProfile,
        ChangeProfile
    }
    public partial class OpenProfilePicture : Form
    {
        private Button showProfileButton;
        private PictureBox changePorfilePictureBox;
        private PictureBox showProfilePictureBox;
        private Button changeProfileButton;
        public ProfileOption SelectedOption { get; private set; }

        public OpenProfilePicture()
        {
            InitializeComponent();
        }
        private void showProfile_Click(object sender, EventArgs e)
        {
            SelectedOption = ProfileOption.ShowProfile;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void changeProfile_Click(object sender, EventArgs e)
        {
            SelectedOption = ProfileOption.ChangeProfile;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void changePorfilePictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox_MouseEnter(sender, e);
        }

        private void changePorfilePictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_MouseLeave(sender, e);
        }

        private void PictureBox_MouseEnter(object sender, EventArgs e)
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

        private void PictureBox_MouseLeave(object sender, EventArgs e)
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

        private void showProfilePictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox_MouseEnter(sender, e);
        }

        private void showProfilePictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox_MouseLeave(sender, e);
        }
    }
}
