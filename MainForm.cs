using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessTracker
{
    public partial class MainForm : Form
    {
        private User currentUser;
        private Label lblWelcome;
        private Label lblGoal;
        private TextBox txtGoal;
        private Button btnSetGoal;
        private GroupBox grpActivities;
        private ComboBox cmbActivityType;
        private TextBox txtMetric1;
        private TextBox txtMetric2;
        private TextBox txtMetric3;
        private Label lblMetric1;
        private Label lblMetric2;
        private Label lblMetric3;
        private Button btnAddActivity;
        private ListBox lstActivities;
        private Label lblTotalCalories;
        private Label lblGoalStatus;
        private Button btnViewProgress;

        public MainForm(User user)
        {
            currentUser = user;
            InitializeComponent();
            UpdateDisplay();
        }

        private void InitializeComponent()
        {
            this.Text = "Fitness Tracker - Dashboard";
            this.Size = new Size(700, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Welcome Label
            lblWelcome = new Label
            {
                Text = $"Welcome, {currentUser.Username}!",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                Size = new Size(400, 25)
            };

            // Goal Setting Section
            Label lblGoalTitle = new Label
            {
                Text = "Calorie Goal:",
                Location = new Point(20, 60),
                Size = new Size(100, 20)
            };

            txtGoal = new TextBox
            {
                Location = new Point(130, 58),
                Size = new Size(100, 20)
            };

            btnSetGoal = new Button
            {
                Text = "Set Goal",
                Location = new Point(240, 56),
                Size = new Size(80, 25)
            };
            btnSetGoal.Click += BtnSetGoal_Click;

            lblGoal = new Label
            {
                Text = $"Current Goal: {currentUser.CalorieGoal} calories",
                Location = new Point(330, 60),
                Size = new Size(300, 20)
            };

            // Activity Input Section
            grpActivities = new GroupBox
            {
                Text = "Add Activity",
                Location = new Point(20, 100),
                Size = new Size(650, 180)
            };

            Label lblActivityType = new Label
            {
                Text = "Activity Type:",
                Location = new Point(15, 30),
                Size = new Size(100, 20)
            };

            cmbActivityType = new ComboBox
            {
                Location = new Point(120, 28),
                Size = new Size(150, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbActivityType.Items.AddRange(new string[]
            {
                "Walking", "Swimming", "Running",
                "Cycling", "Yoga", "Weight Training"
            });
            cmbActivityType.SelectedIndexChanged += CmbActivityType_SelectedIndexChanged;

            lblMetric1 = new Label
            {
                Text = "Metric 1:",
                Location = new Point(15, 70),
                Size = new Size(100, 20)
            };

            txtMetric1 = new TextBox
            {
                Location = new Point(120, 68),
                Size = new Size(150, 20)
            };

            lblMetric2 = new Label
            {
                Text = "Metric 2:",
                Location = new Point(15, 100),
                Size = new Size(100, 20)
            };

            txtMetric2 = new TextBox
            {
                Location = new Point(120, 98),
                Size = new Size(150, 20)
            };

            lblMetric3 = new Label
            {
                Text = "Metric 3:",
                Location = new Point(15, 130),
                Size = new Size(100, 20)
            };

            txtMetric3 = new TextBox
            {
                Location = new Point(120, 128),
                Size = new Size(150, 20)
            };

            btnAddActivity = new Button
            {
                Text = "Add Activity",
                Location = new Point(280, 95),
                Size = new Size(100, 30)
            };
            btnAddActivity.Click += BtnAddActivity_Click;

            grpActivities.Controls.Add(lblActivityType);
            grpActivities.Controls.Add(cmbActivityType);
            grpActivities.Controls.Add(lblMetric1);
            grpActivities.Controls.Add(txtMetric1);
            grpActivities.Controls.Add(lblMetric2);
            grpActivities.Controls.Add(txtMetric2);
            grpActivities.Controls.Add(lblMetric3);
            grpActivities.Controls.Add(txtMetric3);
            grpActivities.Controls.Add(btnAddActivity);

            // Activities List
            Label lblActivitiesList = new Label
            {
                Text = "Recorded Activities:",
                Location = new Point(20, 290),
                Size = new Size(150, 20)
            };

            lstActivities = new ListBox
            {
                Location = new Point(20, 315),
                Size = new Size(650, 150)
            };

            // Progress Display
            lblTotalCalories = new Label
            {
                Text = $"Total Calories Burned: {currentUser.GetTotalCaloriesBurned():F2}",
                Font = new Font("Arial", 11, FontStyle.Bold),
                Location = new Point(20, 480),
                Size = new Size(400, 25)
            };

            lblGoalStatus = new Label
            {
                Text = GetGoalStatusText(),
                Font = new Font("Arial", 10, FontStyle.Regular),
                Location = new Point(20, 510),
                Size = new Size(400, 25)
            };

            btnViewProgress = new Button
            {
                Text = "View Detailed Progress",
                Location = new Point(450, 490),
                Size = new Size(200, 35)
            };
            btnViewProgress.Click += BtnViewProgress_Click;

            // Add all controls to form
            this.Controls.Add(lblWelcome);
            this.Controls.Add(lblGoalTitle);
            this.Controls.Add(txtGoal);
            this.Controls.Add(btnSetGoal);
            this.Controls.Add(lblGoal);
            this.Controls.Add(grpActivities);
            this.Controls.Add(lblActivitiesList);
            this.Controls.Add(lstActivities);
            this.Controls.Add(lblTotalCalories);
            this.Controls.Add(lblGoalStatus);
            this.Controls.Add(btnViewProgress);
        }

        private void CmbActivityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbActivityType.SelectedItem?.ToString();

            switch (selected)
            {
                case "Walking":
                    lblMetric1.Text = "Steps:";
                    lblMetric2.Text = "Distance (km):";
                    lblMetric3.Text = "Time (min):";
                    break;
                case "Swimming":
                    lblMetric1.Text = "Laps:";
                    lblMetric2.Text = "Time (min):";
                    lblMetric3.Text = "Avg Heart Rate:";
                    break;
                case "Running":
                    lblMetric1.Text = "Distance (km):";
                    lblMetric2.Text = "Time (min):";
                    lblMetric3.Text = "Avg Pace (min/km):";
                    break;
                case "Cycling":
                    lblMetric1.Text = "Distance (km):";
                    lblMetric2.Text = "Time (min):";
                    lblMetric3.Text = "Avg Speed (km/h):";
                    break;
                case "Yoga":
                    lblMetric1.Text = "Duration (min):";
                    lblMetric2.Text = "Intensity (1-10):";
                    lblMetric3.Text = "Poses Count:";
                    break;
                case "Weight Training":
                    lblMetric1.Text = "Duration (min):";
                    lblMetric2.Text = "Sets:";
                    lblMetric3.Text = "Avg Weight (kg):";
                    break;
            }
        }

        private void BtnSetGoal_Click(object sender, EventArgs e)
        {
            double goal;
            if (Validation.ValidateNumericInput(txtGoal.Text, out goal) && goal > 0)
            {
                currentUser.CalorieGoal = goal;
                UpdateDisplay();
                MessageBox.Show($"Goal set to {goal} calories!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter a valid positive number for the goal.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAddActivity_Click(object sender, EventArgs e)
        {
            if (cmbActivityType.SelectedItem == null)
            {
                MessageBox.Show("Please select an activity type.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double metric1, metric2, metric3;

            if (!Validation.ValidateNumericInput(txtMetric1.Text, out metric1) ||
                !Validation.ValidateNumericInput(txtMetric2.Text, out metric2) ||
                !Validation.ValidateNumericInput(txtMetric3.Text, out metric3))
            {
                MessageBox.Show("Please enter valid numbers for all metrics.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Activity activity = CreateActivity(cmbActivityType.SelectedItem.ToString());
            if (activity != null)
            {
                activity.Metric1 = metric1;
                activity.Metric2 = metric2;
                activity.Metric3 = metric3;

                currentUser.Activities.Add(activity);
                UpdateDisplay();
                ClearActivityInputs();

                MessageBox.Show($"Activity added! Calories burned: {activity.CalculateCalories():F2}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Activity CreateActivity(string activityType)
        {
            switch (activityType)
            {
                case "Walking": return new Walking();
                case "Swimming": return new Swimming();
                case "Running": return new Running();
                case "Cycling": return new Cycling();
                case "Yoga": return new Yoga();
                case "Weight Training": return new WeightTraining();
                default: return null;
            }
        }

        private void ClearActivityInputs()
        {
            txtMetric1.Clear();
            txtMetric2.Clear();
            txtMetric3.Clear();
        }

        private void UpdateDisplay()
        {
            lblGoal.Text = $"Current Goal: {currentUser.CalorieGoal} calories";
            lblTotalCalories.Text = $"Total Calories Burned: {currentUser.GetTotalCaloriesBurned():F2}";
            lblGoalStatus.Text = GetGoalStatusText();

            lstActivities.Items.Clear();
            foreach (Activity activity in currentUser.Activities)
            {
                lstActivities.Items.Add(
                    $"{activity.ActivityDate:MM/dd/yyyy HH:mm} - {activity.ActivityName} - " +
                    $"{activity.CalculateCalories():F2} calories");
            }
        }

        private string GetGoalStatusText()
        {
            if (currentUser.CalorieGoal == 0)
            {
                return "No goal set yet.";
            }

            if (currentUser.HasAchievedGoal())
            {
                return "🎉 Congratulations! You have achieved your goal!";
            }
            else
            {
                double remaining = currentUser.CalorieGoal - currentUser.GetTotalCaloriesBurned();
                return $"Keep going! {remaining:F2} calories remaining to reach your goal.";
            }
        }

        private void BtnViewProgress_Click(object sender, EventArgs e)
        {
            ProgressForm progressForm = new ProgressForm(currentUser);
            progressForm.ShowDialog();
        }
    }
}
