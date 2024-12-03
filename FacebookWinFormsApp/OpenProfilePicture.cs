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
    public class OpenProfilePicture : Form
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
        private void InitializeComponent()
        {
            this.showProfileButton = new System.Windows.Forms.Button();
            this.changeProfileButton = new System.Windows.Forms.Button();
            this.showProfilePictureBox = new System.Windows.Forms.PictureBox();
            this.changePorfilePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.showProfilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changePorfilePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // showProfileButton
            // 
            this.showProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showProfileButton.Location = new System.Drawing.Point(61, 30);
            this.showProfileButton.Name = "showProfileButton";
            this.showProfileButton.Size = new System.Drawing.Size(211, 33);
            this.showProfileButton.TabIndex = 0;
            this.showProfileButton.Text = "Show your profile";
            this.showProfileButton.UseVisualStyleBackColor = true;
            this.showProfileButton.Click += new System.EventHandler(this.showProfileButton_Click);
            // 
            // changeProfileButton
            // 
            this.changeProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeProfileButton.Location = new System.Drawing.Point(61, 82);
            this.changeProfileButton.Name = "changeProfileButton";
            this.changeProfileButton.Size = new System.Drawing.Size(211, 33);
            this.changeProfileButton.TabIndex = 1;
            this.changeProfileButton.Text = "Change your profile";
            this.changeProfileButton.UseVisualStyleBackColor = true;
            this.changeProfileButton.Click += new System.EventHandler(this.changeProfileButton_Click);
            // 
            // showProfilePictureBox
            // 
            this.showProfilePictureBox.Image = global::BasicFacebookFeatures.Properties.Resources._1865156_200;
            this.showProfilePictureBox.InitialImage = global::BasicFacebookFeatures.Properties.Resources._1865156_200;
            this.showProfilePictureBox.Location = new System.Drawing.Point(278, 26);
            this.showProfilePictureBox.Name = "showProfilePictureBox";
            this.showProfilePictureBox.Size = new System.Drawing.Size(45, 42);
            this.showProfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showProfilePictureBox.TabIndex = 3;
            this.showProfilePictureBox.TabStop = false;
            this.showProfilePictureBox.Click += new System.EventHandler(this.showProfilePictureBox_Click);
            // 
            // changePorfilePictureBox
            // 
            this.changePorfilePictureBox.Image = global::BasicFacebookFeatures.Properties.Resources._3342137;
            this.changePorfilePictureBox.InitialImage = global::BasicFacebookFeatures.Properties.Resources._3342137;
            this.changePorfilePictureBox.Location = new System.Drawing.Point(278, 76);
            this.changePorfilePictureBox.Name = "changePorfilePictureBox";
            this.changePorfilePictureBox.Size = new System.Drawing.Size(45, 42);
            this.changePorfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.changePorfilePictureBox.TabIndex = 2;
            this.changePorfilePictureBox.TabStop = false;
            this.changePorfilePictureBox.Click += new System.EventHandler(this.changePorfilePictureBox_Click);
            // 
            // OpenProfilePicture
            // 
            this.ClientSize = new System.Drawing.Size(377, 142);
            this.Controls.Add(this.showProfilePictureBox);
            this.Controls.Add(this.changePorfilePictureBox);
            this.Controls.Add(this.changeProfileButton);
            this.Controls.Add(this.showProfileButton);
            this.Name = "OpenProfilePicture";
            this.Text = "Profile Picture Form";
            ((System.ComponentModel.ISupportInitialize)(this.showProfilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changePorfilePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        private void showProfileButton_Click(object sender, EventArgs e)
        {
            SelectedOption = ProfileOption.ShowProfile;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OpenProfilePicture_Load(object sender, EventArgs e)
        {
            SelectedOption = ProfileOption.ChangeProfile;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void showProfilePictureBox_Click(object sender, EventArgs e)
        {
            SelectedOption = ProfileOption.ShowProfile;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void changePorfilePictureBox_Click(object sender, EventArgs e)
        {
            SelectedOption = ProfileOption.ChangeProfile;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void changeProfileButton_Click(object sender, EventArgs e)
        {
            SelectedOption = ProfileOption.ChangeProfile;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
