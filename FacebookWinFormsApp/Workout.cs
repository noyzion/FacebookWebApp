using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class Workout
    {
        public int Duration { get; set; }
        public string Catergory { get; set; }
        public DateTime DateTime { get; set; }
        public int Calories { get; set; }
        public Workout() { }
        public Workout(int duration, string catergory, DateTime dateTime, int calories)
        {
            Duration = duration;
            Catergory = catergory;
            DateTime = dateTime;
            Calories = calories;
        }

    }
}
