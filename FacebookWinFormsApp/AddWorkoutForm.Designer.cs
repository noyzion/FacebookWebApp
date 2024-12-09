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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxWorkoutCategory = new System.Windows.Forms.ComboBox();
            this.dateTimePickerWorkout = new System.Windows.Forms.DateTimePicker();
            this.buttonAddWorkout = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.numericUpDownDuration = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCalories = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalories)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category:";
            // 
            // comboBoxWorkoutCategory
            // 
            this.comboBoxWorkoutCategory.FormattingEnabled = true;
            this.comboBoxWorkoutCategory.Location = new System.Drawing.Point(101, 109);
            this.comboBoxWorkoutCategory.Name = "comboBoxWorkoutCategory";
            this.comboBoxWorkoutCategory.Size = new System.Drawing.Size(121, 24);
            this.comboBoxWorkoutCategory.TabIndex = 3;
            // 
            // dateTimePickerWorkout
            // 
            this.dateTimePickerWorkout.Location = new System.Drawing.Point(63, 179);
            this.dateTimePickerWorkout.Name = "dateTimePickerWorkout";
            this.dateTimePickerWorkout.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerWorkout.TabIndex = 4;
            // 
            // buttonAddWorkout
            // 
            this.buttonAddWorkout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddWorkout.Location = new System.Drawing.Point(125, 360);
            this.buttonAddWorkout.Name = "buttonAddWorkout";
            this.buttonAddWorkout.Size = new System.Drawing.Size(58, 34);
            this.buttonAddWorkout.TabIndex = 6;
            this.buttonAddWorkout.Text = "Add";
            this.buttonAddWorkout.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Choose workout date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(108, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Add calories:";
            // 
            // numericUpDownDuration
            // 
            this.numericUpDownDuration.Location = new System.Drawing.Point(100, 318);
            this.numericUpDownDuration.Name = "numericUpDownDuration";
            this.numericUpDownDuration.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownDuration.TabIndex = 9;
            this.numericUpDownDuration.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDownCalories
            // 
            this.numericUpDownCalories.Location = new System.Drawing.Point(101, 249);
            this.numericUpDownCalories.Name = "numericUpDownCalories";
            this.numericUpDownCalories.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownCalories.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(121, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Duration:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "Add Workout";
            // 
            // AddWorkoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 411);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownCalories);
            this.Controls.Add(this.numericUpDownDuration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAddWorkout);
            this.Controls.Add(this.dateTimePickerWorkout);
            this.Controls.Add(this.comboBoxWorkoutCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "AddWorkoutForm";
            this.Text = "Add Workout";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxWorkoutCategory;
        private System.Windows.Forms.DateTimePicker dateTimePickerWorkout;
        private System.Windows.Forms.Button buttonAddWorkout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numericUpDownDuration;
        private System.Windows.Forms.NumericUpDown numericUpDownCalories;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}