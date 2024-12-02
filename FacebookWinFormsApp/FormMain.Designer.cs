namespace BasicFacebookFeatures
{
    partial class FormMain
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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DataPanel = new System.Windows.Forms.TableLayoutPanel();
            this.amotionsListBox = new System.Windows.Forms.ListBox();
            this.likesListBox = new System.Windows.Forms.ListBox();
            this.commentsListBox = new System.Windows.Forms.ListBox();
            this.DataListBox = new System.Windows.Forms.ListBox();
            this.albumsButton = new System.Windows.Forms.Button();
            this.postsButton = new System.Windows.Forms.Button();
            this.friendsButton = new System.Windows.Forms.Button();
            this.likedButton = new System.Windows.Forms.Button();
            this.groupsButton = new System.Windows.Forms.Button();
            this.rememberMe_CheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.eventsButton = new System.Windows.Forms.Button();
            this.eventsPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.photosPicture = new System.Windows.Forms.PictureBox();
            this.postsPicture = new System.Windows.Forms.PictureBox();
            this.friendsPicture = new System.Windows.Forms.PictureBox();
            this.likedPicture = new System.Windows.Forms.PictureBox();
            this.groupsPicture = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.DataPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photosPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postsPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendsPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.likedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Navy;
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.buttonLogin.Location = new System.Drawing.Point(18, 17);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(268, 32);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login with Facebook";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonLogout.Enabled = false;
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Location = new System.Drawing.Point(18, 57);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(268, 32);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 53;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1243, 697);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.eventsButton);
            this.tabPage1.Controls.Add(this.eventsPictureBox);
            this.tabPage1.Controls.Add(this.DataPanel);
            this.tabPage1.Controls.Add(this.DataListBox);
            this.tabPage1.Controls.Add(this.albumsButton);
            this.tabPage1.Controls.Add(this.postsButton);
            this.tabPage1.Controls.Add(this.friendsButton);
            this.tabPage1.Controls.Add(this.likedButton);
            this.tabPage1.Controls.Add(this.groupsButton);
            this.tabPage1.Controls.Add(this.photosPicture);
            this.tabPage1.Controls.Add(this.postsPicture);
            this.tabPage1.Controls.Add(this.friendsPicture);
            this.tabPage1.Controls.Add(this.likedPicture);
            this.tabPage1.Controls.Add(this.groupsPicture);
            this.tabPage1.Controls.Add(this.rememberMe_CheckBox);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1235, 662);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // DataPanel
            // 
            this.DataPanel.ColumnCount = 2;
            this.DataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DataPanel.Controls.Add(this.amotionsListBox, 1, 1);
            this.DataPanel.Controls.Add(this.likesListBox, 0, 1);
            this.DataPanel.Controls.Add(this.pictureBox, 1, 0);
            this.DataPanel.Controls.Add(this.commentsListBox, 0, 0);
            this.DataPanel.Location = new System.Drawing.Point(715, 153);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DataPanel.RowCount = 2;
            this.DataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DataPanel.Size = new System.Drawing.Size(500, 350);
            this.DataPanel.TabIndex = 72;
            // 
            // amotionsListBox
            // 
            this.amotionsListBox.FormattingEnabled = true;
            this.amotionsListBox.ItemHeight = 22;
            this.amotionsListBox.Location = new System.Drawing.Point(3, 178);
            this.amotionsListBox.Name = "amotionsListBox";
            this.amotionsListBox.Size = new System.Drawing.Size(244, 136);
            this.amotionsListBox.TabIndex = 3;
            // 
            // likesListBox
            // 
            this.likesListBox.FormattingEnabled = true;
            this.likesListBox.ItemHeight = 22;
            this.likesListBox.Location = new System.Drawing.Point(253, 178);
            this.likesListBox.Name = "likesListBox";
            this.likesListBox.Size = new System.Drawing.Size(244, 136);
            this.likesListBox.TabIndex = 2;
            // 
            // commentsListBox
            // 
            this.commentsListBox.FormattingEnabled = true;
            this.commentsListBox.ItemHeight = 22;
            this.commentsListBox.Location = new System.Drawing.Point(253, 3);
            this.commentsListBox.Name = "commentsListBox";
            this.commentsListBox.Size = new System.Drawing.Size(244, 136);
            this.commentsListBox.TabIndex = 1;
            // 
            // DataListBox
            // 
            this.DataListBox.AccessibleName = "DataListBox";
            this.DataListBox.FormattingEnabled = true;
            this.DataListBox.HorizontalScrollbar = true;
            this.DataListBox.ItemHeight = 22;
            this.DataListBox.Location = new System.Drawing.Point(203, 159);
            this.DataListBox.Name = "DataListBox";
            this.DataListBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DataListBox.ScrollAlwaysVisible = true;
            this.DataListBox.Size = new System.Drawing.Size(482, 312);
            this.DataListBox.TabIndex = 70;
            this.DataListBox.SelectedIndexChanged += new System.EventHandler(this.DataListBox_SelectedIndexChanged);
            // 
            // albumsButton
            // 
            this.albumsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.albumsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.albumsButton.Enabled = false;
            this.albumsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.albumsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.albumsButton.Location = new System.Drawing.Point(73, 324);
            this.albumsButton.Name = "albumsButton";
            this.albumsButton.Size = new System.Drawing.Size(91, 35);
            this.albumsButton.TabIndex = 69;
            this.albumsButton.Text = "Albums";
            this.albumsButton.UseVisualStyleBackColor = false;
            this.albumsButton.Click += new System.EventHandler(this.photosButton_Click);
            // 
            // postsButton
            // 
            this.postsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.postsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.postsButton.Enabled = false;
            this.postsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.postsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.postsButton.Location = new System.Drawing.Point(73, 378);
            this.postsButton.Name = "postsButton";
            this.postsButton.Size = new System.Drawing.Size(91, 35);
            this.postsButton.TabIndex = 68;
            this.postsButton.Text = "Posts";
            this.postsButton.UseVisualStyleBackColor = false;
            this.postsButton.Click += new System.EventHandler(this.postsButton_Click);
            // 
            // friendsButton
            // 
            this.friendsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.friendsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.friendsButton.Enabled = false;
            this.friendsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.friendsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.friendsButton.Location = new System.Drawing.Point(73, 268);
            this.friendsButton.Name = "friendsButton";
            this.friendsButton.Size = new System.Drawing.Size(91, 35);
            this.friendsButton.TabIndex = 66;
            this.friendsButton.Text = "Friends";
            this.friendsButton.UseVisualStyleBackColor = false;
            this.friendsButton.Click += new System.EventHandler(this.friendsButton_Click);
            // 
            // likedButton
            // 
            this.likedButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.likedButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.likedButton.Enabled = false;
            this.likedButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.likedButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.likedButton.Location = new System.Drawing.Point(73, 215);
            this.likedButton.Name = "likedButton";
            this.likedButton.Size = new System.Drawing.Size(91, 35);
            this.likedButton.TabIndex = 65;
            this.likedButton.Text = "Liked";
            this.likedButton.UseVisualStyleBackColor = false;
            this.likedButton.Click += new System.EventHandler(this.likedButton_Click);
            // 
            // groupsButton
            // 
            this.groupsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupsButton.Enabled = false;
            this.groupsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupsButton.Location = new System.Drawing.Point(73, 159);
            this.groupsButton.Name = "groupsButton";
            this.groupsButton.Size = new System.Drawing.Size(91, 35);
            this.groupsButton.TabIndex = 64;
            this.groupsButton.Text = "Groups";
            this.groupsButton.UseVisualStyleBackColor = false;
            this.groupsButton.Click += new System.EventHandler(this.groupsButton_Click);
            // 
            // rememberMe_CheckBox
            // 
            this.rememberMe_CheckBox.AutoSize = true;
            this.rememberMe_CheckBox.Location = new System.Drawing.Point(18, 97);
            this.rememberMe_CheckBox.Name = "rememberMe_CheckBox";
            this.rememberMe_CheckBox.Size = new System.Drawing.Size(159, 28);
            this.rememberMe_CheckBox.TabIndex = 56;
            this.rememberMe_CheckBox.Text = "Remember Me";
            this.rememberMe_CheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1235, 662);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // eventsButton
            // 
            this.eventsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.eventsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.eventsButton.Enabled = false;
            this.eventsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eventsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eventsButton.Location = new System.Drawing.Point(73, 434);
            this.eventsButton.Name = "eventsButton";
            this.eventsButton.Size = new System.Drawing.Size(91, 35);
            this.eventsButton.TabIndex = 74;
            this.eventsButton.Text = "Events";
            this.eventsButton.UseVisualStyleBackColor = false;
            this.eventsButton.Click += new System.EventHandler(this.eventsButton_Click);
            // 
            // eventsPictureBox
            // 
            this.eventsPictureBox.Image = global::BasicFacebookFeatures.Properties.Resources.events_icon;
            this.eventsPictureBox.InitialImage = global::BasicFacebookFeatures.Properties.Resources.events_icon;
            this.eventsPictureBox.Location = new System.Drawing.Point(18, 425);
            this.eventsPictureBox.Name = "eventsPictureBox";
            this.eventsPictureBox.Size = new System.Drawing.Size(49, 48);
            this.eventsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.eventsPictureBox.TabIndex = 73;
            this.eventsPictureBox.TabStop = false;
            this.eventsPictureBox.Click += new System.EventHandler(this.eventsPictureBox_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(5, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(242, 154);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // photosPicture
            // 
            this.photosPicture.Image = global::BasicFacebookFeatures.Properties.Resources.photos_icon__2_;
            this.photosPicture.InitialImage = global::BasicFacebookFeatures.Properties.Resources.photos_icon__2_;
            this.photosPicture.Location = new System.Drawing.Point(18, 315);
            this.photosPicture.Name = "photosPicture";
            this.photosPicture.Size = new System.Drawing.Size(49, 48);
            this.photosPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photosPicture.TabIndex = 63;
            this.photosPicture.TabStop = false;
            this.photosPicture.Click += new System.EventHandler(this.photosPicture_Click);
            // 
            // postsPicture
            // 
            this.postsPicture.Image = global::BasicFacebookFeatures.Properties.Resources.posts_icon;
            this.postsPicture.InitialImage = global::BasicFacebookFeatures.Properties.Resources.posts_icon;
            this.postsPicture.Location = new System.Drawing.Point(18, 369);
            this.postsPicture.Name = "postsPicture";
            this.postsPicture.Size = new System.Drawing.Size(49, 48);
            this.postsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.postsPicture.TabIndex = 62;
            this.postsPicture.TabStop = false;
            this.postsPicture.Click += new System.EventHandler(this.postsPicture_Click);
            // 
            // friendsPicture
            // 
            this.friendsPicture.Image = global::BasicFacebookFeatures.Properties.Resources.new_friends_icon;
            this.friendsPicture.InitialImage = global::BasicFacebookFeatures.Properties.Resources.new_friends_icon;
            this.friendsPicture.Location = new System.Drawing.Point(18, 261);
            this.friendsPicture.Name = "friendsPicture";
            this.friendsPicture.Size = new System.Drawing.Size(49, 48);
            this.friendsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.friendsPicture.TabIndex = 60;
            this.friendsPicture.TabStop = false;
            this.friendsPicture.Click += new System.EventHandler(this.friendsPicture_Click);
            // 
            // likedPicture
            // 
            this.likedPicture.Image = global::BasicFacebookFeatures.Properties.Resources.liked_icon;
            this.likedPicture.InitialImage = global::BasicFacebookFeatures.Properties.Resources.liked_icon;
            this.likedPicture.Location = new System.Drawing.Point(18, 207);
            this.likedPicture.Name = "likedPicture";
            this.likedPicture.Size = new System.Drawing.Size(49, 48);
            this.likedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.likedPicture.TabIndex = 59;
            this.likedPicture.TabStop = false;
            this.likedPicture.Click += new System.EventHandler(this.likedPicture_Click);
            // 
            // groupsPicture
            // 
            this.groupsPicture.Image = global::BasicFacebookFeatures.Properties.Resources.groups_icon;
            this.groupsPicture.InitialImage = global::BasicFacebookFeatures.Properties.Resources.groups_icon;
            this.groupsPicture.Location = new System.Drawing.Point(18, 153);
            this.groupsPicture.Name = "groupsPicture";
            this.groupsPicture.Size = new System.Drawing.Size(49, 48);
            this.groupsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.groupsPicture.TabIndex = 58;
            this.groupsPicture.TabStop = false;
            this.groupsPicture.Click += new System.EventHandler(this.groupsPicture_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(293, 11);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(84, 78);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 697);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.DataPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photosPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postsPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendsPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.likedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.CheckBox rememberMe_CheckBox;
        private System.Windows.Forms.PictureBox groupsPicture;
        private System.Windows.Forms.PictureBox likedPicture;
        private System.Windows.Forms.PictureBox photosPicture;
        private System.Windows.Forms.PictureBox postsPicture;
        private System.Windows.Forms.PictureBox friendsPicture;
        private System.Windows.Forms.Button groupsButton;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Button friendsButton;
        private System.Windows.Forms.Button likedButton;
        private System.Windows.Forms.Button albumsButton;
        private System.Windows.Forms.Button postsButton;
        private System.Windows.Forms.ListBox DataListBox;
        private System.Windows.Forms.TableLayoutPanel DataPanel;
        private System.Windows.Forms.ListBox amotionsListBox;
        private System.Windows.Forms.ListBox likesListBox;
        private System.Windows.Forms.ListBox commentsListBox;
        private System.Windows.Forms.Button eventsButton;
        private System.Windows.Forms.PictureBox eventsPictureBox;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

