using System;

namespace FitnessTracker
{
    /// <summary>
    /// Base class for all fitness activities
    /// </summary>
    public abstract class Activity
    {
        public string ActivityName { get; set; }
        public double Metric1 { get; set; }
        public double Metric2 { get; set; }
        public double Metric3 { get; set; }
        public DateTime ActivityDate { get; set; }

        public Activity(string name)
        {
            ActivityName = name;
            ActivityDate = DateTime.Now;
        }

        /// <summary>
        /// Abstract method to calculate calories - each activity implements its own formula
        /// </summary>
        public abstract double CalculateCalories();
    }

    // Walking Activity
    public class Walking : Activity
    {
        // Metrics: steps, distance (km), time (minutes)
        public Walking() : base("Walking") { }

        public override double CalculateCalories()
        {
            // Formula: (steps * 0.04) + (distance * 50)
            return (Metric1 * 0.04) + (Metric2 * 50);
        }
    }

    // Swimming Activity
    public class Swimming : Activity
    {
        // Metrics: laps, time (minutes), avg heart rate
        public Swimming() : base("Swimming") { }

        public override double CalculateCalories()
        {
            // Formula: (laps * 30) + (time * 8) + (heart rate * 0.5)
            return (Metric1 * 30) + (Metric2 * 8) + (Metric3 * 0.5);
        }
    }

    // Running Activity
    public class Running : Activity
    {
        // Metrics: distance (km), time (minutes), avg pace (min/km)
        public Running() : base("Running") { }

        public override double CalculateCalories()
        {
            // Formula: (distance * 100) + (time * 10)
            return (Metric1 * 100) + (Metric2 * 10);
        }
    }

    // Cycling Activity
    public class Cycling : Activity
    {
        // Metrics: distance (km), time (minutes), avg speed (km/h)
        public Cycling() : base("Cycling") { }

        public override double CalculateCalories()
        {
            // Formula: (distance * 40) + (time * 7)
            return (Metric1 * 40) + (Metric2 * 7);
        }
    }

    // Yoga Activity
    public class Yoga : Activity
    {
        // Metrics: duration (minutes), intensity (1-10), poses count
        public Yoga() : base("Yoga") { }

        public override double CalculateCalories()
        {
            // Formula: (duration * 3) + (intensity * 15) + (poses * 2)
            return (Metric1 * 3) + (Metric2 * 15) + (Metric3 * 2);
        }
    }

    // Weight Training Activity
    public class WeightTraining : Activity
    {
        // Metrics: duration (minutes), sets completed, avg weight (kg)
        public WeightTraining() : base("Weight Training") { }

        public override double CalculateCalories()
        {
            // Formula: (duration * 6) + (sets * 10) + (weight * 0.5)
            return (Metric1 * 6) + (Metric2 * 10) + (Metric3 * 0.5);
        }
    }
}
