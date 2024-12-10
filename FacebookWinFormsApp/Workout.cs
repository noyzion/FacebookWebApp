﻿using System;

namespace BasicFacebookFeatures
{
    public class Workout
    {
        public decimal Duration { get; set; }
        public string Category { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Calories { get; set; }
        public Workout() { }
        public Workout(decimal duration, string catergory, DateTime dateTime, decimal calories)
        {
            Duration = duration;
            Category = catergory;
            DateTime = dateTime;
            Calories = calories;
        }
    }
}