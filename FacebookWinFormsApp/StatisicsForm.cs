using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicFacebookFeatures
{
    public partial class StatisicsForm : Form
    {
        private readonly DataGridView workoutTable;

        public StatisicsForm(DataGridView workoutTable)
        {
            InitializeComponent();
            this.workoutTable = workoutTable;
            GenerateWorkoutStatistics();
        }

        private void GenerateWorkoutStatistics()
        {
            Dictionary<int, int> caloriesPerMonth = new Dictionary<int, int>();
            Dictionary<int, int> workoutCountPerMonth = new Dictionary<int, int>();

            foreach (DataGridViewRow row in workoutTable.Rows)
            {
                if (row.Cells["Date"]?.Value != null)
                {
                    DateTime workoutDate = Convert.ToDateTime(row.Cells["Date"].Value);
                    int month = workoutDate.Month;

                    if (workoutCountPerMonth.ContainsKey(month))
                    {
                        workoutCountPerMonth[month]++;
                    }
                    else
                    {
                        workoutCountPerMonth[month] = 1;
                    }

                    if (row.Cells["Calories"]?.Value != null)
                    {
                        int calories = Convert.ToInt32(row.Cells["Calories"].Value);
                        if (caloriesPerMonth.ContainsKey(month))
                        {
                            caloriesPerMonth[month] += calories;
                        }
                        else
                        {
                            caloriesPerMonth[month] = calories;
                        }
                    }
                }
            }

            string[] monthNames = {
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    };

            caloriesChart.Series["Calories"].Points.Clear();
            timeChart.Series["Amount"].Points.Clear();

            foreach (var month in workoutCountPerMonth.Keys
                                      .Union(caloriesPerMonth.Keys)
                                      .Distinct()
                                      .OrderBy(m => m))
            {
                string monthName = monthNames[month - 1];
                int caloriesForMonth = caloriesPerMonth.ContainsKey(month) ? caloriesPerMonth[month] : 0;
                int workoutCountForMonth = workoutCountPerMonth.ContainsKey(month) ? workoutCountPerMonth[month] : 0;

                if (caloriesForMonth > 0)
                {
                    caloriesChart.Series["Calories"].Points.AddXY(monthName, caloriesForMonth);
                }

                if (workoutCountForMonth > 0)
                {
                    timeChart.Series["Amount"].Points.AddXY(monthName, workoutCountForMonth);
                }
            }

            caloriesChart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            timeChart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        }

    }
}
