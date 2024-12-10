namespace BasicFacebookFeatures
{
    partial class AddWorkoutForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddWorkoutForm));
            this.labelCategory = new System.Windows.Forms.Label();
            this.comboBoxWorkoutCategory = new System.Windows.Forms.ComboBox();
            this.dateTimePickerWorkout = new System.Windows.Forms.DateTimePicker();
            this.buttonAddWorkout = new System.Windows.Forms.Button();
            this.labelChooseDate = new System.Windows.Forms.Label();
            this.labelAddCalories = new System.Windows.Forms.Label();
            this.numericUpDownDuration = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCalories = new System.Windows.Forms.NumericUpDown();
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelAddWorkoutHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalories)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCategory
            // 
            resources.ApplyResources(this.labelCategory, "labelCategory");
            this.labelCategory.Name = "labelCategory";
            // 
            // comboBoxWorkoutCategory
            // 
            this.comboBoxWorkoutCategory.FormattingEnabled = true;
            this.comboBoxWorkoutCategory.Items.AddRange(new object[] {
            resources.GetString("comboBoxWorkoutCategory.Items"),
            resources.GetString("comboBoxWorkoutCategory.Items1"),
            resources.GetString("comboBoxWorkoutCategory.Items2"),
            resources.GetString("comboBoxWorkoutCategory.Items3"),
            resources.GetString("comboBoxWorkoutCategory.Items4"),
            resources.GetString("comboBoxWorkoutCategory.Items5"),
            resources.GetString("comboBoxWorkoutCategory.Items6"),
            resources.GetString("comboBoxWorkoutCategory.Items7"),
            resources.GetString("comboBoxWorkoutCategory.Items8"),
            resources.GetString("comboBoxWorkoutCategory.Items9"),
            resources.GetString("comboBoxWorkoutCategory.Items10"),
            resources.GetString("comboBoxWorkoutCategory.Items11"),
            resources.GetString("comboBoxWorkoutCategory.Items12"),
            resources.GetString("comboBoxWorkoutCategory.Items13"),
            resources.GetString("comboBoxWorkoutCategory.Items14"),
            resources.GetString("comboBoxWorkoutCategory.Items15"),
            resources.GetString("comboBoxWorkoutCategory.Items16"),
            resources.GetString("comboBoxWorkoutCategory.Items17"),
            resources.GetString("comboBoxWorkoutCategory.Items18"),
            resources.GetString("comboBoxWorkoutCategory.Items19"),
            resources.GetString("comboBoxWorkoutCategory.Items20"),
            resources.GetString("comboBoxWorkoutCategory.Items21"),
            resources.GetString("comboBoxWorkoutCategory.Items22"),
            resources.GetString("comboBoxWorkoutCategory.Items23"),
            resources.GetString("comboBoxWorkoutCategory.Items24"),
            resources.GetString("comboBoxWorkoutCategory.Items25")});
            resources.ApplyResources(this.comboBoxWorkoutCategory, "comboBoxWorkoutCategory");
            this.comboBoxWorkoutCategory.Name = "comboBoxWorkoutCategory";
            this.comboBoxWorkoutCategory.TextChanged += new System.EventHandler(this.comboBoxWorkoutCategory_TextChanged);
            // 
            // dateTimePickerWorkout
            // 
            resources.ApplyResources(this.dateTimePickerWorkout, "dateTimePickerWorkout");
            this.dateTimePickerWorkout.Name = "dateTimePickerWorkout";
            this.dateTimePickerWorkout.ValueChanged += new System.EventHandler(this.dateTimePickerWorkout_ValueChanged);
            // 
            // buttonAddWorkout
            // 
            resources.ApplyResources(this.buttonAddWorkout, "buttonAddWorkout");
            this.buttonAddWorkout.Name = "buttonAddWorkout";
            this.buttonAddWorkout.UseVisualStyleBackColor = true;
            this.buttonAddWorkout.Click += new System.EventHandler(this.buttonAddWorkout_Click);
            // 
            // labelChooseDate
            // 
            resources.ApplyResources(this.labelChooseDate, "labelChooseDate");
            this.labelChooseDate.Name = "labelChooseDate";
            // 
            // labelAddCalories
            // 
            resources.ApplyResources(this.labelAddCalories, "labelAddCalories");
            this.labelAddCalories.Name = "labelAddCalories";
            // 
            // numericUpDownDuration
            // 
            resources.ApplyResources(this.numericUpDownDuration, "numericUpDownDuration");
            this.numericUpDownDuration.Name = "numericUpDownDuration";
            this.numericUpDownDuration.ValueChanged += new System.EventHandler(this.numericUpDownDuration_ValueChanged);
            // 
            // numericUpDownCalories
            // 
            resources.ApplyResources(this.numericUpDownCalories, "numericUpDownCalories");
            this.numericUpDownCalories.Name = "numericUpDownCalories";
            this.numericUpDownCalories.ValueChanged += new System.EventHandler(this.numericUpDownCalories_ValueChanged);
            // 
            // labelDuration
            // 
            resources.ApplyResources(this.labelDuration, "labelDuration");
            this.labelDuration.Name = "labelDuration";
            // 
            // labelAddWorkoutHeader
            // 
            resources.ApplyResources(this.labelAddWorkoutHeader, "labelAddWorkoutHeader");
            this.labelAddWorkoutHeader.Name = "labelAddWorkoutHeader";
            // 
            // AddWorkoutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.numericUpDownCalories);
            this.Controls.Add(this.numericUpDownDuration);
            this.Controls.Add(this.labelAddCalories);
            this.Controls.Add(this.labelChooseDate);
            this.Controls.Add(this.buttonAddWorkout);
            this.Controls.Add(this.dateTimePickerWorkout);
            this.Controls.Add(this.comboBoxWorkoutCategory);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.labelAddWorkoutHeader);
            this.Name = "AddWorkoutForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ComboBox comboBoxWorkoutCategory;
        private System.Windows.Forms.DateTimePicker dateTimePickerWorkout;
        private System.Windows.Forms.Button buttonAddWorkout;
        private System.Windows.Forms.Label labelChooseDate;
        private System.Windows.Forms.Label labelAddCalories;
        private System.Windows.Forms.NumericUpDown numericUpDownDuration;
        private System.Windows.Forms.NumericUpDown numericUpDownCalories;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label labelAddWorkoutHeader;
    }
}