using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace BasicFacebookFeatures
{
    public class WorkoutManager
    {
        public List<Workout> Workouts { get; set; }
        private static readonly string[] r_ColumnNames = { "Category", "Duration", "Calories", "Date" };
        public DataGridView InitializeWorkoutTable()
        {
            DataGridView workoutTable = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            foreach (string columnName in r_ColumnNames)
            {
                workoutTable.Columns.Add(columnName, columnName);
            }
            return workoutTable;
        }
        public void FetchWorkoutData(DataGridView i_WorkoutTable)
        {
            i_WorkoutTable.Rows.Clear(); 
            if (Workouts != null)
            {
                foreach (Workout workout in Workouts)
                {
                    i_WorkoutTable.Rows.Add(
                        workout.Category,
                        workout.Duration,
                        workout.Calories,
                        workout.Date.ToString("yyyy-MM-dd")
                    );
                }
            }
        }
    }
}
