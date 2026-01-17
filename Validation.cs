using System;
using System.Text.RegularExpressions;

namespace FitnessTracker
{
    /// <summary>
    /// Handles validation for user inputs
    /// </summary>
    public static class Validation
    {
        /// <summary>
        /// Validates username - letters and numbers only
        /// </summary>
        public static bool ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return false;
            }

            // Check if username contains only letters and numbers
            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            return regex.IsMatch(username);
        }

        /// <summary>
        /// Validates password - must be 12 characters with at least 1 lowercase and 1 uppercase
        /// </summary>
        public static bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Check length is 12
            if (password.Length != 12)
            {
                return false;
            }

            // Check for at least one lowercase letter
            bool hasLowercase = false;
            bool hasUppercase = false;

            foreach (char c in password)
            {
                if (char.IsLower(c))
                {
                    hasLowercase = true;
                }
                if (char.IsUpper(c))
                {
                    hasUppercase = true;
                }
            }

            return hasLowercase && hasUppercase;
        }

        /// <summary>
        /// Validates numeric input for metrics
        /// </summary>
        public static bool ValidateNumericInput(string input, out double value)
        {
            if (double.TryParse(input, out value))
            {
                return value >= 0;
            }
            return false;
        }

        /// <summary>
        /// Gets validation error message for username
        /// </summary>
        public static string GetUsernameError()
        {
            return "Username must contain only letters and numbers.";
        }

        /// <summary>
        /// Gets validation error message for password
        /// </summary>
        public static string GetPasswordError()
        {
            return "Password must be exactly 12 characters long and contain at least one lowercase and one uppercase letter.";
        }
    }
}