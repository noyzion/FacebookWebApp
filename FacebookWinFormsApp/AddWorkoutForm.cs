using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public AddWorkoutForm(DataGridView workoutTable)
        {
            InitializeComponent();
            this.workoutTable = workoutTable;
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
            Workout newWorkout = new Workout(
                numericUpDownDuration.Value,
                comboBoxWorkoutCategory.Text,
                dateTimePickerWorkout.Value,
                numericUpDownCalories.Value
            );

            workoutTable.Rows.Add(newWorkout.Category, newWorkout.Duration, newWorkout.Calories, newWorkout.DateTime.ToShortDateString());

            this.Close();
        }

    }
}
