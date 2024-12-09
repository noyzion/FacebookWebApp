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
            this.feedTab = new System.Windows.Forms.TabPage();
            this.settingsButton = new System.Windows.Forms.Button();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.videoButton = new System.Windows.Forms.Button();
            this.addPostButton = new System.Windows.Forms.Button();
            this.addPictureButton = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.eventsButton = new System.Windows.Forms.Button();
            this.DataPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DataListBox = new System.Windows.Forms.ListBox();
            this.albumsButton = new System.Windows.Forms.Button();
            this.postsButton = new System.Windows.Forms.Button();
            this.friendsButton = new System.Windows.Forms.Button();
            this.pagesButton = new System.Windows.Forms.Button();
            this.groupsButton = new System.Windows.Forms.Button();
            this.rememberMe_CheckBox = new System.Windows.Forms.CheckBox();
            this.wishlistTab = new System.Windows.Forms.TabPage();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkedListBoxShopping = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxPets = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxActivities = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxFood = new System.Windows.Forms.CheckedListBox();
            this.buttonAddPhoto = new System.Windows.Forms.Button();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.buttonPost = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonDeleteItem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonAddWorkout = new System.Windows.Forms.Button();
            this.birthdayLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.panelWorkouts = new System.Windows.Forms.Panel();
            this.buttonStatistics = new System.Windows.Forms.Button();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.eventsPictureBox = new System.Windows.Forms.PictureBox();
            this.photosPicture = new System.Windows.Forms.PictureBox();
            this.postsPicture = new System.Windows.Forms.PictureBox();
            this.friendsPicture = new System.Windows.Forms.PictureBox();
            this.likedPicture = new System.Windows.Forms.PictureBox();
            this.groupsPicture = new System.Windows.Forms.PictureBox();
            this.pictureBoxPets = new System.Windows.Forms.PictureBox();
            this.pictureBoxShopping = new System.Windows.Forms.PictureBox();
            this.pictureBoxActivities = new System.Windows.Forms.PictureBox();
            this.pictureBoxFood = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.feedTab.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.wishlistTab.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.photosPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postsPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendsPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.likedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShopping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFood)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Navy;
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.buttonLogin.Location = new System.Drawing.Point(7, 55);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(230, 32);
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
            this.buttonLogout.Location = new System.Drawing.Point(7, 94);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(230, 32);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 53;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.feedTab);
            this.tabControl1.Controls.Add(this.wishlistTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1243, 697);
            this.tabControl1.TabIndex = 54;
            this.tabControl1.Tag = "";
            // 
            // feedTab
            // 
            this.feedTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.feedTab.Controls.Add(this.label10);
            this.feedTab.Controls.Add(this.settingsButton);
            this.feedTab.Controls.Add(this.pictureBoxProfile);
            this.feedTab.Controls.Add(this.statusPanel);
            this.feedTab.Controls.Add(this.emailLabel);
            this.feedTab.Controls.Add(this.birthdayLabel);
            this.feedTab.Controls.Add(this.eventsButton);
            this.feedTab.Controls.Add(this.eventsPictureBox);
            this.feedTab.Controls.Add(this.DataPanel);
            this.feedTab.Controls.Add(this.DataListBox);
            this.feedTab.Controls.Add(this.albumsButton);
            this.feedTab.Controls.Add(this.postsButton);
            this.feedTab.Controls.Add(this.friendsButton);
            this.feedTab.Controls.Add(this.pagesButton);
            this.feedTab.Controls.Add(this.groupsButton);
            this.feedTab.Controls.Add(this.photosPicture);
            this.feedTab.Controls.Add(this.postsPicture);
            this.feedTab.Controls.Add(this.friendsPicture);
            this.feedTab.Controls.Add(this.likedPicture);
            this.feedTab.Controls.Add(this.groupsPicture);
            this.feedTab.Controls.Add(this.rememberMe_CheckBox);
            this.feedTab.Controls.Add(this.label1);
            this.feedTab.Controls.Add(this.buttonLogout);
            this.feedTab.Controls.Add(this.buttonLogin);
            this.feedTab.Controls.Add(this.panel1);
            this.feedTab.Location = new System.Drawing.Point(4, 31);
            this.feedTab.Name = "feedTab";
            this.feedTab.Padding = new System.Windows.Forms.Padding(3);
            this.feedTab.Size = new System.Drawing.Size(1235, 662);
            this.feedTab.TabIndex = 0;
            this.feedTab.Text = "Feed";
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.settingsButton.Enabled = false;
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.Location = new System.Drawing.Point(13, 15);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(79, 30);
            this.settingsButton.TabIndex = 85;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // statusPanel
            // 
            this.statusPanel.Controls.Add(this.label2);
            this.statusPanel.Controls.Add(this.videoButton);
            this.statusPanel.Controls.Add(this.addPostButton);
            this.statusPanel.Controls.Add(this.addPictureButton);
            this.statusPanel.Controls.Add(this.statusTextBox);
            this.statusPanel.Location = new System.Drawing.Point(430, 558);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(785, 90);
            this.statusPanel.TabIndex = 84;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 87;
            this.label2.Text = "Add status:";
            // 
            // videoButton
            // 
            this.videoButton.BackColor = System.Drawing.Color.White;
            this.videoButton.Enabled = false;
            this.videoButton.Location = new System.Drawing.Point(412, 50);
            this.videoButton.Name = "videoButton";
            this.videoButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.videoButton.Size = new System.Drawing.Size(136, 31);
            this.videoButton.TabIndex = 89;
            this.videoButton.Text = "Add video";
            this.videoButton.UseVisualStyleBackColor = false;
            this.videoButton.Click += new System.EventHandler(this.videoButton_Click);
            // 
            // addPostButton
            // 
            this.addPostButton.BackColor = System.Drawing.Color.White;
            this.addPostButton.Enabled = false;
            this.addPostButton.Location = new System.Drawing.Point(709, 6);
            this.addPostButton.Name = "addPostButton";
            this.addPostButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addPostButton.Size = new System.Drawing.Size(70, 31);
            this.addPostButton.TabIndex = 85;
            this.addPostButton.Text = "Post";
            this.addPostButton.UseVisualStyleBackColor = false;
            this.addPostButton.Click += new System.EventHandler(this.addPostButton_Click);
            // 
            // addPictureButton
            // 
            this.addPictureButton.BackColor = System.Drawing.Color.White;
            this.addPictureButton.Enabled = false;
            this.addPictureButton.Location = new System.Drawing.Point(270, 50);
            this.addPictureButton.Name = "addPictureButton";
            this.addPictureButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addPictureButton.Size = new System.Drawing.Size(136, 31);
            this.addPictureButton.TabIndex = 88;
            this.addPictureButton.Text = "Add picture";
            this.addPictureButton.UseVisualStyleBackColor = false;
            this.addPictureButton.Click += new System.EventHandler(this.addPictureButton_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Enabled = false;
            this.statusTextBox.Location = new System.Drawing.Point(124, 7);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(579, 28);
            this.statusTextBox.TabIndex = 86;
            this.statusTextBox.TextChanged += new System.EventHandler(this.statusTextBox_TextChanged);
            // 
            // eventsButton
            // 
            this.eventsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.eventsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.eventsButton.Enabled = false;
            this.eventsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eventsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.eventsButton.Location = new System.Drawing.Point(73, 594);
            this.eventsButton.Name = "eventsButton";
            this.eventsButton.Size = new System.Drawing.Size(91, 35);
            this.eventsButton.TabIndex = 74;
            this.eventsButton.Text = "Events";
            this.eventsButton.UseVisualStyleBackColor = false;
            this.eventsButton.Click += new System.EventHandler(this.eventsButton_Click);
            // 
            // DataPanel
            // 
            this.DataPanel.ColumnCount = 2;
            this.DataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DataPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DataPanel.Location = new System.Drawing.Point(430, 188);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DataPanel.RowCount = 2;
            this.DataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DataPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DataPanel.Size = new System.Drawing.Size(785, 356);
            this.DataPanel.TabIndex = 72;
            // 
            // DataListBox
            // 
            this.DataListBox.AccessibleName = "DataListBox";
            this.DataListBox.FormattingEnabled = true;
            this.DataListBox.HorizontalScrollbar = true;
            this.DataListBox.ItemHeight = 22;
            this.DataListBox.Location = new System.Drawing.Point(195, 179);
            this.DataListBox.Name = "DataListBox";
            this.DataListBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DataListBox.ScrollAlwaysVisible = true;
            this.DataListBox.Size = new System.Drawing.Size(215, 466);
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
            this.albumsButton.Location = new System.Drawing.Point(73, 435);
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
            this.postsButton.Location = new System.Drawing.Point(73, 515);
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
            this.friendsButton.Location = new System.Drawing.Point(73, 353);
            this.friendsButton.Name = "friendsButton";
            this.friendsButton.Size = new System.Drawing.Size(91, 35);
            this.friendsButton.TabIndex = 66;
            this.friendsButton.Text = "Friends";
            this.friendsButton.UseVisualStyleBackColor = false;
            this.friendsButton.Click += new System.EventHandler(this.friendsButton_Click);
            // 
            // pagesButton
            // 
            this.pagesButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pagesButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pagesButton.Enabled = false;
            this.pagesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pagesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pagesButton.Location = new System.Drawing.Point(73, 277);
            this.pagesButton.Name = "pagesButton";
            this.pagesButton.Size = new System.Drawing.Size(91, 32);
            this.pagesButton.TabIndex = 65;
            this.pagesButton.Text = "Pages";
            this.pagesButton.UseVisualStyleBackColor = false;
            this.pagesButton.Click += new System.EventHandler(this.pagesButton_Click);
            // 
            // groupsButton
            // 
            this.groupsButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupsButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupsButton.Enabled = false;
            this.groupsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupsButton.Location = new System.Drawing.Point(73, 199);
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
            this.rememberMe_CheckBox.Location = new System.Drawing.Point(12, 137);
            this.rememberMe_CheckBox.Name = "rememberMe_CheckBox";
            this.rememberMe_CheckBox.Size = new System.Drawing.Size(159, 28);
            this.rememberMe_CheckBox.TabIndex = 56;
            this.rememberMe_CheckBox.Text = "Remember Me";
            this.rememberMe_CheckBox.UseVisualStyleBackColor = true;
            // 
            // wishlistTab
            // 
            this.wishlistTab.Controls.Add(this.buttonDeleteItem);
            this.wishlistTab.Controls.Add(this.label9);
            this.wishlistTab.Controls.Add(this.label8);
            this.wishlistTab.Controls.Add(this.buttonPost);
            this.wishlistTab.Controls.Add(this.buttonAdd);
            this.wishlistTab.Controls.Add(this.label7);
            this.wishlistTab.Controls.Add(this.label6);
            this.wishlistTab.Controls.Add(this.label5);
            this.wishlistTab.Controls.Add(this.label4);
            this.wishlistTab.Controls.Add(this.pictureBoxPets);
            this.wishlistTab.Controls.Add(this.pictureBoxShopping);
            this.wishlistTab.Controls.Add(this.pictureBoxActivities);
            this.wishlistTab.Controls.Add(this.pictureBoxFood);
            this.wishlistTab.Controls.Add(this.checkedListBoxShopping);
            this.wishlistTab.Controls.Add(this.checkedListBoxPets);
            this.wishlistTab.Controls.Add(this.checkedListBoxActivities);
            this.wishlistTab.Controls.Add(this.checkedListBoxFood);
            this.wishlistTab.Controls.Add(this.buttonAddPhoto);
            this.wishlistTab.Controls.Add(this.comboBoxCategory);
            this.wishlistTab.Controls.Add(this.textBoxName);
            this.wishlistTab.Controls.Add(this.label3);
            this.wishlistTab.Location = new System.Drawing.Point(4, 31);
            this.wishlistTab.Name = "wishlistTab";
            this.wishlistTab.Padding = new System.Windows.Forms.Padding(3);
            this.wishlistTab.Size = new System.Drawing.Size(1235, 662);
            this.wishlistTab.TabIndex = 1;
            this.wishlistTab.Text = "Wishlist";
            this.wishlistTab.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(876, 87);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(88, 35);
            this.buttonAdd.TabIndex = 12;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(421, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 24);
            this.label7.TabIndex = 11;
            this.label7.Text = "Activities";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(699, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Pets";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(938, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Shopping";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(176, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Food";
            // 
            // checkedListBoxShopping
            // 
            this.checkedListBoxShopping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxShopping.DisplayMember = "m_Text";
            this.checkedListBoxShopping.FormattingEnabled = true;
            this.checkedListBoxShopping.Location = new System.Drawing.Point(876, 190);
            this.checkedListBoxShopping.Name = "checkedListBoxShopping";
            this.checkedListBoxShopping.Size = new System.Drawing.Size(225, 347);
            this.checkedListBoxShopping.TabIndex = 17;
            this.checkedListBoxShopping.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxShopping_ItemCheck);
            this.checkedListBoxShopping.SelectedValueChanged += new System.EventHandler(this.checkedListBoxShopping_SelectedIndexChanged);
            // 
            // checkedListBoxPets
            // 
            this.checkedListBoxPets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxPets.DisplayMember = "m_Text";
            this.checkedListBoxPets.FormattingEnabled = true;
            this.checkedListBoxPets.Location = new System.Drawing.Point(616, 190);
            this.checkedListBoxPets.Name = "checkedListBoxPets";
            this.checkedListBoxPets.Size = new System.Drawing.Size(225, 347);
            this.checkedListBoxPets.TabIndex = 18;
            this.checkedListBoxPets.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxPets_ItemCheck);
            this.checkedListBoxPets.SelectedValueChanged += new System.EventHandler(this.checkedListBoxPets_SelectedIndexChanged);
            // 
            // checkedListBoxActivities
            // 
            this.checkedListBoxActivities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxActivities.DisplayMember = "m_Text";
            this.checkedListBoxActivities.FormattingEnabled = true;
            this.checkedListBoxActivities.Location = new System.Drawing.Point(354, 190);
            this.checkedListBoxActivities.Name = "checkedListBoxActivities";
            this.checkedListBoxActivities.Size = new System.Drawing.Size(225, 347);
            this.checkedListBoxActivities.TabIndex = 19;
            this.checkedListBoxActivities.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxActivities_ItemCheck);
            this.checkedListBoxActivities.SelectedValueChanged += new System.EventHandler(this.checkedListBoxActivities_SelectedIndexChanged);
            // 
            // checkedListBoxFood
            // 
            this.checkedListBoxFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxFood.DisplayMember = "m_Text";
            this.checkedListBoxFood.FormattingEnabled = true;
            this.checkedListBoxFood.Location = new System.Drawing.Point(93, 190);
            this.checkedListBoxFood.Name = "checkedListBoxFood";
            this.checkedListBoxFood.Size = new System.Drawing.Size(225, 347);
            this.checkedListBoxFood.TabIndex = 20;
            this.checkedListBoxFood.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxFood_ItemCheck);
            this.checkedListBoxFood.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxFood_SelectedIndexChanged);
            // 
            // buttonAddPhoto
            // 
            this.buttonAddPhoto.Enabled = false;
            this.buttonAddPhoto.Location = new System.Drawing.Point(722, 87);
            this.buttonAddPhoto.Name = "buttonAddPhoto";
            this.buttonAddPhoto.Size = new System.Drawing.Size(145, 35);
            this.buttonAddPhoto.TabIndex = 21;
            this.buttonAddPhoto.Text = "Add Photo";
            this.buttonAddPhoto.UseVisualStyleBackColor = true;
            this.buttonAddPhoto.Click += new System.EventHandler(this.buttonAddPhoto_Click);
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DisplayMember = "choose category";
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "food",
            "pets",
            "activities",
            "shopping"});
            this.comboBoxCategory.Location = new System.Drawing.Point(587, 90);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 30);
            this.comboBoxCategory.TabIndex = 2;
            this.comboBoxCategory.TextChanged += new System.EventHandler(this.comboBoxCategory_TextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxName.Location = new System.Drawing.Point(329, 90);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(245, 28);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(523, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 43);
            this.label3.TabIndex = 0;
            this.label3.Text = "My Wishlist";
            // 
            // buttonPost
            // 
            this.buttonPost.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonPost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonPost.FlatAppearance.BorderSize = 0;
            this.buttonPost.ForeColor = System.Drawing.Color.Black;
            this.buttonPost.Location = new System.Drawing.Point(517, 567);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(191, 43);
            this.buttonPost.TabIndex = 22;
            this.buttonPost.Text = "Share your wishlist!";
            this.buttonPost.UseVisualStyleBackColor = false;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.Location = new System.Drawing.Point(588, 71);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "category";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label9.Location = new System.Drawing.Point(329, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "what do you wish for?";
            // 
            // buttonDeleteItem
            // 
            this.buttonDeleteItem.BackColor = System.Drawing.Color.Tomato;
            this.buttonDeleteItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonDeleteItem.Enabled = false;
            this.buttonDeleteItem.FlatAppearance.BorderSize = 0;
            this.buttonDeleteItem.ForeColor = System.Drawing.Color.Black;
            this.buttonDeleteItem.Location = new System.Drawing.Point(1120, 505);
            this.buttonDeleteItem.Name = "buttonDeleteItem";
            this.buttonDeleteItem.Size = new System.Drawing.Size(81, 34);
            this.buttonDeleteItem.TabIndex = 25;
            this.buttonDeleteItem.Text = "delete";
            this.buttonDeleteItem.UseVisualStyleBackColor = false;
            this.buttonDeleteItem.Click += new System.EventHandler(this.buttonDeleteItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonStatistics);
            this.panel1.Controls.Add(this.panelWorkouts);
            this.panel1.Controls.Add(this.buttonAddWorkout);
            this.panel1.Location = new System.Drawing.Point(609, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 145);
            this.panel1.TabIndex = 86;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(625, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 27);
            this.label10.TabIndex = 0;
            this.label10.Text = "My Workouts";
            // 
            // buttonAddWorkout
            // 
            this.buttonAddWorkout.BackColor = System.Drawing.Color.LightYellow;
            this.buttonAddWorkout.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonAddWorkout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddWorkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddWorkout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddWorkout.Location = new System.Drawing.Point(497, 39);
            this.buttonAddWorkout.Name = "buttonAddWorkout";
            this.buttonAddWorkout.Size = new System.Drawing.Size(116, 35);
            this.buttonAddWorkout.TabIndex = 87;
            this.buttonAddWorkout.Text = "Add Workout";
            this.buttonAddWorkout.UseVisualStyleBackColor = false;
            this.buttonAddWorkout.Click += new System.EventHandler(this.buttonAddWorkout_Click);
            // 
            // birthdayLabel
            // 
            this.birthdayLabel.AutoSize = true;
            this.birthdayLabel.Location = new System.Drawing.Point(391, 107);
            this.birthdayLabel.Name = "birthdayLabel";
            this.birthdayLabel.Size = new System.Drawing.Size(0, 24);
            this.birthdayLabel.TabIndex = 80;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(391, 64);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(0, 24);
            this.emailLabel.TabIndex = 81;
            // 
            // panelWorkouts
            // 
            this.panelWorkouts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWorkouts.Location = new System.Drawing.Point(3, 4);
            this.panelWorkouts.Name = "panelWorkouts";
            this.panelWorkouts.Size = new System.Drawing.Size(488, 137);
            this.panelWorkouts.TabIndex = 88;
            // 
            // buttonStatistics
            // 
            this.buttonStatistics.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonStatistics.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatistics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStatistics.Location = new System.Drawing.Point(511, 83);
            this.buttonStatistics.Name = "buttonStatistics";
            this.buttonStatistics.Size = new System.Drawing.Size(88, 29);
            this.buttonStatistics.TabIndex = 89;
            this.buttonStatistics.Text = "statistics";
            this.buttonStatistics.UseVisualStyleBackColor = false;
            this.buttonStatistics.Click += new System.EventHandler(this.buttonStatistics_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(245, 28);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(132, 130);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            this.pictureBoxProfile.Click += new System.EventHandler(this.pictureBoxProfile_Click);
            // 
            // eventsPictureBox
            // 
            this.eventsPictureBox.Image = global::BasicFacebookFeatures.Properties.Resources.events_icon;
            this.eventsPictureBox.InitialImage = global::BasicFacebookFeatures.Properties.Resources.events_icon;
            this.eventsPictureBox.Location = new System.Drawing.Point(18, 585);
            this.eventsPictureBox.Name = "eventsPictureBox";
            this.eventsPictureBox.Size = new System.Drawing.Size(49, 48);
            this.eventsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.eventsPictureBox.TabIndex = 73;
            this.eventsPictureBox.TabStop = false;
            this.eventsPictureBox.Click += new System.EventHandler(this.eventsPictureBox_Click);
            // 
            // photosPicture
            // 
            this.photosPicture.Image = global::BasicFacebookFeatures.Properties.Resources.photos_icon__2_;
            this.photosPicture.InitialImage = global::BasicFacebookFeatures.Properties.Resources.photos_icon__2_;
            this.photosPicture.Location = new System.Drawing.Point(18, 426);
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
            this.postsPicture.Location = new System.Drawing.Point(18, 506);
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
            this.friendsPicture.Location = new System.Drawing.Point(18, 346);
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
            this.likedPicture.Location = new System.Drawing.Point(18, 269);
            this.likedPicture.Name = "likedPicture";
            this.likedPicture.Size = new System.Drawing.Size(49, 45);
            this.likedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.likedPicture.TabIndex = 59;
            this.likedPicture.TabStop = false;
            this.likedPicture.Click += new System.EventHandler(this.likedPicture_Click);
            // 
            // groupsPicture
            // 
            this.groupsPicture.Image = global::BasicFacebookFeatures.Properties.Resources.groups_icon;
            this.groupsPicture.InitialImage = global::BasicFacebookFeatures.Properties.Resources.groups_icon;
            this.groupsPicture.Location = new System.Drawing.Point(18, 193);
            this.groupsPicture.Name = "groupsPicture";
            this.groupsPicture.Size = new System.Drawing.Size(49, 48);
            this.groupsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.groupsPicture.TabIndex = 58;
            this.groupsPicture.TabStop = false;
            this.groupsPicture.Click += new System.EventHandler(this.groupsPicture_Click);
            // 
            // pictureBoxPets
            // 
            this.pictureBoxPets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPets.Location = new System.Drawing.Point(741, 439);
            this.pictureBoxPets.Name = "pictureBoxPets";
            this.pictureBoxPets.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxPets.TabIndex = 16;
            this.pictureBoxPets.TabStop = false;
            // 
            // pictureBoxShopping
            // 
            this.pictureBoxShopping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxShopping.Location = new System.Drawing.Point(1001, 439);
            this.pictureBoxShopping.Name = "pictureBoxShopping";
            this.pictureBoxShopping.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxShopping.TabIndex = 15;
            this.pictureBoxShopping.TabStop = false;
            // 
            // pictureBoxActivities
            // 
            this.pictureBoxActivities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxActivities.Location = new System.Drawing.Point(479, 439);
            this.pictureBoxActivities.Name = "pictureBoxActivities";
            this.pictureBoxActivities.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxActivities.TabIndex = 14;
            this.pictureBoxActivities.TabStop = false;
            // 
            // pictureBoxFood
            // 
            this.pictureBoxFood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFood.Location = new System.Drawing.Point(218, 439);
            this.pictureBoxFood.Name = "pictureBoxFood";
            this.pictureBoxFood.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxFood.TabIndex = 13;
            this.pictureBoxFood.TabStop = false;
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
            this.Text = "Facebook App";
            this.tabControl1.ResumeLayout(false);
            this.feedTab.ResumeLayout(false);
            this.feedTab.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            this.wishlistTab.ResumeLayout(false);
            this.wishlistTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.photosPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postsPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendsPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.likedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShopping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFood)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage feedTab;
        private System.Windows.Forms.CheckBox rememberMe_CheckBox;
        private System.Windows.Forms.PictureBox groupsPicture;
        private System.Windows.Forms.PictureBox likedPicture;
        private System.Windows.Forms.PictureBox photosPicture;
        private System.Windows.Forms.PictureBox postsPicture;
        private System.Windows.Forms.PictureBox friendsPicture;
        private System.Windows.Forms.Button groupsButton;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Button friendsButton;
        private System.Windows.Forms.Button pagesButton;
        private System.Windows.Forms.Button albumsButton;
        private System.Windows.Forms.Button postsButton;
        private System.Windows.Forms.ListBox DataListBox;
        private System.Windows.Forms.TableLayoutPanel DataPanel;
        private System.Windows.Forms.Button eventsButton;
        private System.Windows.Forms.PictureBox eventsPictureBox;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button videoButton;
        private System.Windows.Forms.Button addPostButton;
        private System.Windows.Forms.Button addPictureButton;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.TabPage wishlistTab;
        private System.Windows.Forms.CheckedListBox checkedListBoxShopping;
        private System.Windows.Forms.CheckedListBox checkedListBoxPets;
        private System.Windows.Forms.CheckedListBox checkedListBoxActivities;
        private System.Windows.Forms.CheckedListBox checkedListBoxFood;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonAddPhoto;
        private System.Windows.Forms.PictureBox pictureBoxPets;
        private System.Windows.Forms.PictureBox pictureBoxShopping;
        private System.Windows.Forms.PictureBox pictureBoxActivities;
        private System.Windows.Forms.PictureBox pictureBoxFood;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonDeleteItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonAddWorkout;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label birthdayLabel;
        private System.Windows.Forms.Button buttonStatistics;
        private System.Windows.Forms.Panel panelWorkouts;
    }
}

