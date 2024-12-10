﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class OpenProfilePicture : Form
    {
        public EProfileOption SelectedOption { get; set; }
        public OpenProfilePicture()
        {
            InitializeComponent();
        }
        private void showProfile_Click(object sender, EventArgs e)
        {
            SelectedOption = EProfileOption.ShowProfile;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void changeProfile_Click(object sender, EventArgs e)
        {
            SelectedOption = EProfileOption.ChangeProfile;
            DialogResult = DialogResult.OK;
            Close();
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
    }
}
