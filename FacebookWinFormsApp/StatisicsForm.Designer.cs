namespace BasicFacebookFeatures
{
    partial class StatisicsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.amountTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.caloriesTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.caloriesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1.SuspendLayout();
            this.amountTab.SuspendLayout();
            this.caloriesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caloriesChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.amountTab);
            this.tabControl1.Controls.Add(this.caloriesTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(551, 540);
            this.tabControl1.TabIndex = 0;
            // 
            // amountTab
            // 
            this.amountTab.Controls.Add(this.timeChart);
            this.amountTab.Controls.Add(this.label1);
            this.amountTab.Location = new System.Drawing.Point(4, 25);
            this.amountTab.Name = "amountTab";
            this.amountTab.Padding = new System.Windows.Forms.Padding(3);
            this.amountTab.Size = new System.Drawing.Size(543, 511);
            this.amountTab.TabIndex = 0;
            this.amountTab.Text = "By Amount";
            this.amountTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(151, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "How Many Times\r\n Do You Workout Each Month?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // caloriesTab
            // 
            this.caloriesTab.Controls.Add(this.label2);
            this.caloriesTab.Controls.Add(this.caloriesChart);
            this.caloriesTab.Location = new System.Drawing.Point(4, 25);
            this.caloriesTab.Name = "caloriesTab";
            this.caloriesTab.Padding = new System.Windows.Forms.Padding(3);
            this.caloriesTab.Size = new System.Drawing.Size(543, 511);
            this.caloriesTab.TabIndex = 1;
            this.caloriesTab.Text = "By Calories";
            this.caloriesTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(168, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 54);
            this.label2.TabIndex = 2;
            this.label2.Text = "How Many Calories\r\n Do You Burn Each Month?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // caloriesChart
            // 
            chartArea4.Name = "ChartArea1";
            this.caloriesChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.caloriesChart.Legends.Add(legend4);
            this.caloriesChart.Location = new System.Drawing.Point(6, 70);
            this.caloriesChart.Name = "caloriesChart";
            this.caloriesChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Calories";
            this.caloriesChart.Series.Add(series4);
            this.caloriesChart.Size = new System.Drawing.Size(558, 435);
            this.caloriesChart.TabIndex = 0;
            this.caloriesChart.Text = "chart2";
            // 
            // timeChart
            // 
            chartArea3.Name = "ChartArea1";
            this.timeChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.timeChart.Legends.Add(legend3);
            this.timeChart.Location = new System.Drawing.Point(6, 70);
            this.timeChart.Name = "timeChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Amount";
            this.timeChart.Series.Add(series3);
            this.timeChart.Size = new System.Drawing.Size(558, 435);
            this.timeChart.TabIndex = 2;
            this.timeChart.Text = "chart2";
            // 
            // StatisicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 564);
            this.Controls.Add(this.tabControl1);
            this.Name = "StatisicsForm";
            this.Text = "Statisics By Month";
            this.tabControl1.ResumeLayout(false);
            this.amountTab.ResumeLayout(false);
            this.amountTab.PerformLayout();
            this.caloriesTab.ResumeLayout(false);
            this.caloriesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caloriesChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage amountTab;
        private System.Windows.Forms.TabPage caloriesTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart caloriesChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart timeChart;
    }
}