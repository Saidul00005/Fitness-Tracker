using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker
{
    /// <summary>
    /// Manages user registration and authentication
    /// </summary>
    public class UserManager
    {
        private List<User> users;
        private const int MAX_FAILED_ATTEMPTS = 3;

        public UserManager()
        {
            users = new List<User>();
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        public bool RegisterUser(string username, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Validate username
            if (!Validation.ValidateUsername(username))
            {
                errorMessage = Validation.GetUsernameError();
                return false;
            }

            // Validate password
            if (!Validation.ValidatePassword(password))
            {
                errorMessage = Validation.GetPasswordError();
                return false;
            }

            // Check if username already exists
            if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                errorMessage = "Username already exists. Please choose a different username.";
                return false;
            }

            // Create and add new user
            User newUser = new User(username, password);
            users.Add(newUser);
            return true;
        }

        /// <summary>
        /// Authenticates a user login attempt
        /// </summary>
        public User Login(string username, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Find user
            User user = users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                errorMessage = "Username not found.";
                return null;
            }

            // Check if account is locked due to failed attempts
            if (user.FailedLoginAttempts >= MAX_FAILED_ATTEMPTS)
            {
                errorMessage = $"Account locked due to {MAX_FAILED_ATTEMPTS} failed login attempts. Please contact support.";
                return null;
            }

            // Verify password
            if (user.Password == password)
            {
                // Reset failed attempts on successful login
                user.FailedLoginAttempts = 0;
                return user;
            }
            else
            {
                // Increment failed attempts
                user.FailedLoginAttempts++;
                int attemptsRemaining = MAX_FAILED_ATTEMPTS - user.FailedLoginAttempts;

                if (attemptsRemaining > 0)
                {
                    errorMessage = $"Incorrect password. You have {attemptsRemaining} attempt(s) remaining.";
                }
                else
                {
                    errorMessage = $"Account locked due to {MAX_FAILED_ATTEMPTS} failed login attempts.";
                }
                return null;
            }
        }

        /// <summary>
        /// Gets user by username
        /// </summary>
        public User GetUser(string username)
        {
            return users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
