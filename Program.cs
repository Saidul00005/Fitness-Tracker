using System;
using System.Windows.Forms;

namespace FitnessTracker
{
    /// <summary>
    /// Main entry point for the Fitness Tracker application
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create user manager instance
            UserManager userManager = new UserManager();

            // Start with login form
            Application.Run(new LoginForm(userManager));
        }
    }
}