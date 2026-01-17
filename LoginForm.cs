using System;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessTracker
{
    public partial class LoginForm : Form
    {
        private UserManager userManager;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegister;
        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;

        public LoginForm(UserManager manager)
        {
            userManager = manager;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Fitness Tracker - Login";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title Label
            lblTitle = new Label
            {
                Text = "Fitness Tracker",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(100, 20),
                Size = new Size(200, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Username Label
            lblUsername = new Label
            {
                Text = "Username:",
                Location = new Point(50, 80),
                Size = new Size(100, 20)
            };

            // Username TextBox
            txtUsername = new TextBox
            {
                Location = new Point(150, 78),
                Size = new Size(180, 20)
            };

            // Password Label
            lblPassword = new Label
            {
                Text = "Password:",
                Location = new Point(50, 120),
                Size = new Size(100, 20)
            };

            // Password TextBox
            txtPassword = new TextBox
            {
                Location = new Point(150, 118),
                Size = new Size(180, 20),
                PasswordChar = '*'
            };

            // Login Button
            btnLogin = new Button
            {
                Text = "Login",
                Location = new Point(80, 180),
                Size = new Size(100, 30)
            };
            btnLogin.Click += BtnLogin_Click;

            // Register Button
            btnRegister = new Button
            {
                Text = "Register",
                Location = new Point(200, 180),
                Size = new Size(100, 30)
            };
            btnRegister.Click += BtnRegister_Click;

            // Add controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnRegister);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            string errorMessage;
            User user = userManager.Login(username, password, out errorMessage);

            if (user != null)
            {
                MessageBox.Show($"Welcome, {user.Username}!", "Login Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open main form
                MainForm mainForm = new MainForm(user);
                this.Hide();
                mainForm.ShowDialog();
                this.Show();

                // Clear fields
                txtUsername.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show(errorMessage, "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            string errorMessage;
            bool success = userManager.RegisterUser(username, password, out errorMessage);

            if (success)
            {
                MessageBox.Show("Registration successful! You can now log in.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show(errorMessage, "Registration Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}