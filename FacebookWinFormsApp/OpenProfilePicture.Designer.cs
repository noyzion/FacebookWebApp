namespace BasicFacebookFeatures
{
    partial class OpenProfilePicture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.showProfilePictureBox = new System.Windows.Forms.PictureBox();
            this.changePorfilePictureBox = new System.Windows.Forms.PictureBox();
            this.changeProfileButton = new System.Windows.Forms.Button();
            this.showProfileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showProfilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changePorfilePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // showProfilePictureBox
            // 
            this.showProfilePictureBox.Image = global::BasicFacebookFeatures.Properties.Resources._1865156_200;
            this.showProfilePictureBox.InitialImage = global::BasicFacebookFeatures.Properties.Resources._1865156_200;
            this.showProfilePictureBox.Location = new System.Drawing.Point(242, 23);
            this.showProfilePictureBox.Name = "showProfilePictureBox";
            this.showProfilePictureBox.Size = new System.Drawing.Size(45, 42);
            this.showProfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.showProfilePictureBox.TabIndex = 7;
            this.showProfilePictureBox.TabStop = false;
            this.showProfilePictureBox.Click += new System.EventHandler(this.showProfile_Click);
            this.showProfilePictureBox.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.showProfilePictureBox.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // changePorfilePictureBox
            // 
            this.changePorfilePictureBox.Image = global::BasicFacebookFeatures.Properties.Resources._3342137;
            this.changePorfilePictureBox.InitialImage = global::BasicFacebookFeatures.Properties.Resources._3342137;
            this.changePorfilePictureBox.Location = new System.Drawing.Point(242, 73);
            this.changePorfilePictureBox.Name = "changePorfilePictureBox";
            this.changePorfilePictureBox.Size = new System.Drawing.Size(45, 42);
            this.changePorfilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.changePorfilePictureBox.TabIndex = 6;
            this.changePorfilePictureBox.TabStop = false;
            this.changePorfilePictureBox.Click += new System.EventHandler(this.changeProfile_Click);
            this.changePorfilePictureBox.MouseEnter += new System.EventHandler(this.changePorfilePictureBox_MouseEnter);
            this.changePorfilePictureBox.MouseLeave += new System.EventHandler(this.changePorfilePictureBox_MouseLeave);
            // 
            // changeProfileButton
            // 
            this.changeProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeProfileButton.Location = new System.Drawing.Point(25, 79);
            this.changeProfileButton.Name = "changeProfileButton";
            this.changeProfileButton.Size = new System.Drawing.Size(211, 33);
            this.changeProfileButton.TabIndex = 5;
            this.changeProfileButton.Text = "Change your profile";
            this.changeProfileButton.UseVisualStyleBackColor = true;
            this.changeProfileButton.Click += new System.EventHandler(this.changeProfile_Click);
            // 
            // showProfileButton
            // 
            this.showProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showProfileButton.Location = new System.Drawing.Point(25, 27);
            this.showProfileButton.Name = "showProfileButton";
            this.showProfileButton.Size = new System.Drawing.Size(211, 33);
            this.showProfileButton.TabIndex = 4;
            this.showProfileButton.Text = "Show your profile";
            this.showProfileButton.UseVisualStyleBackColor = true;
            this.showProfileButton.Click += new System.EventHandler(this.showProfile_Click);
            // 
            // OpenProfilePicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 144);
            this.Controls.Add(this.showProfilePictureBox);
            this.Controls.Add(this.changePorfilePictureBox);
            this.Controls.Add(this.changeProfileButton);
            this.Controls.Add(this.showProfileButton);
            this.Name = "OpenProfilePicture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile Picture Options";
            ((System.ComponentModel.ISupportInitialize)(this.showProfilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changePorfilePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}