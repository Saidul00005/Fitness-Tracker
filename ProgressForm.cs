using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessTracker
{
    public partial class ProgressForm : Form
    {
        private User currentUser;
        private RichTextBox txtReport;

        public ProgressForm(User user)
        {
            currentUser = user;
            InitializeComponent();
            GenerateReport();
        }

        private void InitializeComponent()
        {
            this.Text = "Progress Report";
            this.Size = new Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label
            {
                Text = $"Progress Report for {currentUser.Username}",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                Size = new Size(500, 30)
            };

            txtReport = new RichTextBox
            {
                Location = new Point(20, 60),
                Size = new Size(640, 350),
                ReadOnly = true,
                Font = new Font("Consolas", 10)
            };

            Button btnClose = new Button
            {
                Text = "Close",
                Location = new Point(280, 420),
                Size = new Size(100, 30)
            };
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(lblTitle);
            this.Controls.Add(txtReport);
            this.Controls.Add(btnClose);
        }

        private void GenerateReport()
        {
            txtReport.Clear();

            txtReport.AppendText("╔════════════════════════════════════════════════════════════╗\n");
            txtReport.AppendText("                    FITNESS PROGRESS REPORT                     \n");
            txtReport.AppendText("╚════════════════════════════════════════════════════════════╝\n\n");

            txtReport.AppendText($"Username: {currentUser.Username}\n");
            txtReport.AppendText($"Report Date: {DateTime.Now:MMMM dd, yyyy HH:mm}\n\n");

            txtReport.AppendText("────────────────────────────────────────────────────────────\n");
            txtReport.AppendText("GOAL SUMMARY\n");
            txtReport.AppendText("────────────────────────────────────────────────────────────\n");
            txtReport.AppendText($"Calorie Goal:         {currentUser.CalorieGoal:F2} calories\n");
            txtReport.AppendText($"Total Burned:         {currentUser.GetTotalCaloriesBurned():F2} calories\n");

            if (currentUser.CalorieGoal > 0)
            {
                double percentage = (currentUser.GetTotalCaloriesBurned() / currentUser.CalorieGoal) * 100;
                txtReport.AppendText($"Progress:             {percentage:F1}%\n");

                if (currentUser.HasAchievedGoal())
                {
                    txtReport.AppendText("Status:               ✓ GOAL ACHIEVED!\n");
                }
                else
                {
                    double remaining = currentUser.CalorieGoal - currentUser.GetTotalCaloriesBurned();
                    txtReport.AppendText($"Remaining:            {remaining:F2} calories\n");
                    txtReport.AppendText("Status:               In Progress\n");
                }
            }
            else
            {
                txtReport.AppendText("Status:               No goal set\n");
            }

            txtReport.AppendText("\n────────────────────────────────────────────────────────────\n");
            txtReport.AppendText("ACTIVITY BREAKDOWN\n");
            txtReport.AppendText("────────────────────────────────────────────────────────────\n");
            txtReport.AppendText($"Total Activities:     {currentUser.Activities.Count}\n\n");

            if (currentUser.Activities.Count > 0)
            {
                // Count activities by type
                var activityCounts = new System.Collections.Generic.Dictionary<string, int>();
                var activityCalories = new System.Collections.Generic.Dictionary<string, double>();

                foreach (Activity activity in currentUser.Activities)
                {
                    string name = activity.ActivityName;
                    double calories = activity.CalculateCalories();

                    if (!activityCounts.ContainsKey(name))
                    {
                        activityCounts[name] = 0;
                        activityCalories[name] = 0;
                    }

                    activityCounts[name]++;
                    activityCalories[name] += calories;
                }

                txtReport.AppendText("Activity Type         Count    Total Calories\n");
                txtReport.AppendText("─────────────────────────────────────────────\n");

                foreach (var kvp in activityCounts)
                {
                    txtReport.AppendText($"{kvp.Key,-20} {kvp.Value,5}    {activityCalories[kvp.Key],10:F2}\n");
                }

                txtReport.AppendText("\n────────────────────────────────────────────────────────────\n");
                txtReport.AppendText("RECENT ACTIVITIES\n");
                txtReport.AppendText("────────────────────────────────────────────────────────────\n");

                int displayCount = Math.Min(10, currentUser.Activities.Count);
                for (int i = currentUser.Activities.Count - 1; i >= currentUser.Activities.Count - displayCount; i--)
                {
                    Activity activity = currentUser.Activities[i];
                    txtReport.AppendText($"\n{activity.ActivityDate:MM/dd/yyyy HH:mm} - {activity.ActivityName}\n");
                    txtReport.AppendText($"  Calories Burned: {activity.CalculateCalories():F2}\n");
                }
            }
            else
            {
                txtReport.AppendText("\nNo activities recorded yet.\n");
            }

            txtReport.AppendText("\n────────────────────────────────────────────────────────────\n");
            txtReport.AppendText("Keep up the great work!\n");
            txtReport.AppendText("────────────────────────────────────────────────────────────\n");
        }
    }
}
