using System;
using System.Collections.Generic;

namespace FitnessTracker
{
    /// <summary>
    /// Represents a user in the fitness tracking system
    /// </summary>
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public double CalorieGoal { get; set; }
        public List<Activity> Activities { get; set; }
        public int FailedLoginAttempts { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Activities = new List<Activity>();
            FailedLoginAttempts = 0;
            CalorieGoal = 0;
        }

        /// <summary>
        /// Calculates total calories burned from all activities
        /// </summary>
        public double GetTotalCaloriesBurned()
        {
            double total = 0;
            foreach (Activity activity in Activities)
            {
                total += activity.CalculateCalories();
            }
            return total;
        }

        /// <summary>
        /// Checks if user has achieved their calorie goal
        /// </summary>
        public bool HasAchievedGoal()
        {
            return GetTotalCaloriesBurned() >= CalorieGoal;
        }
    }
}
