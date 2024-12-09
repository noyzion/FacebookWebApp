using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class AddWorkoutForm : Form
    {
        private bool categoryChanged;
        private bool dateTimeChanged;
        private bool caloriesChanged;
        private bool durationChanged;
        private readonly DataGridView workoutTable;
        private readonly WorkoutManager workoutManager;

        public AddWorkoutForm(DataGridView workoutTable, WorkoutManager workoutManager)
        {
            InitializeComponent();
            this.workoutTable = workoutTable;
            this.workoutManager = workoutManager;
        }

        private void comboBoxWorkoutCategory_TextChanged(object sender, EventArgs e)
        {
            categoryChanged = true;
            enableAddWorkoutButton();
        }

        private void dateTimePickerWorkout_ValueChanged(object sender, EventArgs e)
        {
            dateTimeChanged = true;
            enableAddWorkoutButton();
        }

        private void numericUpDownCalories_ValueChanged(object sender, EventArgs e)
        {
            caloriesChanged = true;
            enableAddWorkoutButton();
        }

        private void numericUpDownDuration_ValueChanged(object sender, EventArgs e)
        {
            durationChanged = true;
            enableAddWorkoutButton();
        }

        private void enableAddWorkoutButton()
        {
            buttonAddWorkout.Enabled = durationChanged && caloriesChanged && dateTimeChanged && categoryChanged;
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

            if (workoutManager.Workouts == null)
            {
                workoutManager.Workouts = new List<Workout>();
            }
            workoutManager.Workouts.Add(newWorkout);

            workoutTable.Rows.Add(newWorkout.Category, newWorkout.Duration, newWorkout.Calories, newWorkout.DateTime.ToShortDateString());

            this.Close();
        }
    }
}
