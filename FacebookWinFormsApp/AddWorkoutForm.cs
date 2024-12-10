using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class AddWorkoutForm : Form
    {
        private bool m_CategoryChanged;
        private bool m_DateTimeChanged;
        private bool m_CaloriesChanged;
        private bool m_DurationChanged;
        private readonly DataGridView r_WorkoutTable;
        private readonly WorkoutManager r_WorkoutManager;
        public AddWorkoutForm(DataGridView workoutTable, WorkoutManager workoutManager)
        {
            InitializeComponent();
            this.r_WorkoutTable = workoutTable;
            this.r_WorkoutManager = workoutManager;
        }
        private void comboBoxWorkoutCategory_TextChanged(object sender, EventArgs e)
        {
            m_CategoryChanged = true;
            enableAddWorkoutButton();
        }
        private void dateTimePickerWorkout_ValueChanged(object sender, EventArgs e)
        {
            m_DateTimeChanged = true;
            enableAddWorkoutButton();
        }
        private void numericUpDownCalories_ValueChanged(object sender, EventArgs e)
        {
            m_CaloriesChanged = true;
            enableAddWorkoutButton();
        }
        private void numericUpDownDuration_ValueChanged(object sender, EventArgs e)
        {
            m_DurationChanged = true;
            enableAddWorkoutButton();
        }
        private void enableAddWorkoutButton()
        {
            buttonAddWorkout.Enabled = m_DurationChanged && m_CaloriesChanged && m_DateTimeChanged && m_CategoryChanged;
        }
        private void buttonAddWorkout_Click(object sender, EventArgs e)
        {
            if (dateTimePickerWorkout.Value.Date > DateTime.Today)
            {
                MessageBox.Show("The workout date cannot be in the future.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Workout newWorkout = new Workout(
                numericUpDownDuration.Value,
                comboBoxWorkoutCategory.Text,
                dateTimePickerWorkout.Value,
                numericUpDownCalories.Value
            );

            if (r_WorkoutManager.Workouts == null)
            {
                r_WorkoutManager.Workouts = new List<Workout>();
            }
            r_WorkoutManager.Workouts.Add(newWorkout);

            r_WorkoutTable.Rows.Add(newWorkout.Category, newWorkout.Duration, newWorkout.Calories, newWorkout.DateTime.ToShortDateString());

            this.Close();
        }
    }
}