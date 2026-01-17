# ?? Fitness Tracker

A Windows desktop application built with C# and Windows Forms that helps users track their fitness activities and monitor progress toward their personal calorie-burning goals.

## ?? Table of Contents

- [Features](#features)
- [Project Structure](#project-structure)
- [Requirements](#requirements)
- [Installation & Setup](#installation--setup)
- [How to Run](#how-to-run)
- [Usage Guide](#usage-guide)
- [Technical Details](#technical-details)
- [Project Architecture](#project-architecture)

---

## ? Features

### User Management
- **User Registration**: Create new accounts with secure password validation
- **User Authentication**: Login system with multiple failed attempt protection
- **Password Security**: Passwords must be exactly 12 characters with at least 1 lowercase and 1 uppercase letter

### Activity Tracking
- **Multiple Activity Types**:
  - ?? **Walking**: Track steps, distance, and time
  - ?? **Swimming**: Track laps, time, and heart rate
- **Smart Calorie Calculation**: Each activity type has its own calorie-burning formula
- **Activity History**: View all logged activities with timestamps

### Goal Management
- **Set Personal Goals**: Define custom calorie-burning targets
- **Progress Tracking**: Monitor total calories burned vs. your goal
- **Goal Status Display**: Instant feedback on whether you've achieved your daily goal

### Dashboard Features
- **Activity View**: Visual display of all logged activities
- **Real-time Statistics**: Total calories burned calculation
- **Progress Form**: Detailed view of your fitness progress

---

## ?? Project Structure

```
Fitness Tracker/
??? Program.cs                 # Application entry point
??? LoginForm.cs              # User authentication UI
??? MainForm.cs               # Main dashboard UI
??? ProgressForm.cs           # Progress tracking UI
??? User.cs                   # User class model
??? Activity.cs               # Activity base class and implementations
??? UserManager.cs            # User authentication/registration logic
??? Validation.cs             # Input validation utilities
??? Fitness Tracker.csproj    # Project configuration
```

### Class Overview

**User.cs**
- Stores user credentials and activity history
- Calculates total calories burned
- Tracks goal achievement status

**Activity.cs**
- Abstract base class for all fitness activities
- Walking class: calculates calories using steps and distance
- Swimming class: calculates calories using laps, time, and heart rate

**UserManager.cs**
- Manages user registration and login
- Validates usernames and passwords
- Tracks failed login attempts (max 3 attempts)

**Validation.cs**
- Username validation (letters and numbers only)
- Password validation (12 characters, mixed case required)

---

## ?? Requirements

- **Operating System**: Windows 7 or later
- **IDE**: Visual Studio 2017 or later (Community Edition works fine)
- **.NET Framework**: .NET Framework 4.7.2 or later
- **RAM**: Minimum 4 GB
- **Disk Space**: ~100 MB

### Dependencies
- Windows Forms (included with .NET Framework)
- System libraries (no external NuGet packages required)

---

## ?? Installation & Setup

### Step 1: Clone or Download the Project

If you have Git installed:

```bash
git clone https://github.com/Saidul00005/Fitness-Tracker.git
cd "Fitness Tracker"
```

Or download the project as a ZIP file and extract it.

### Step 2: Open in Visual Studio

1. Launch **Visual Studio**
2. Click on **File** ? **Open** ? **Project/Solution**
3. Navigate to the project folder and select **Fitness Tracker.csproj**
4. Click **Open**

### Step 3: Restore Project

Visual Studio should automatically restore the project. If not:
1. Right-click on the project in **Solution Explorer**
2. Select **Rebuild Solution** (or press `Ctrl + Alt + F7`)

---

## ?? How to Run

### Running from Visual Studio

1. **Build the Project**:
   - Press `Ctrl + Shift + B` or go to **Build** ? **Build Solution**
   - Ensure there are no compilation errors

2. **Run the Application**:
   - Press `F5` or click the **Play** button in the toolbar
   - The Login window will appear

3. **Stop the Application**:
   - Press `Shift + F5` or close the application window

### Running the Compiled Application

1. Navigate to: `bin\Debug\` folder (or `bin\Release\` for Release build)
2. Double-click **Fitness Tracker.exe** to run the application

---

## ?? Usage Guide

### 1?? First Time Setup - Registration

1. When you launch the app, you'll see the **Login Form**
2. Click the **Register** button
3. Enter your credentials:
   - **Username**: Alphanumeric characters only (e.g., `john123`)
   - **Password**: Exactly 12 characters with at least 1 uppercase and 1 lowercase (e.g., `Password123X`)
4. Click **Register** to create your account
5. You'll be redirected to login

### 2?? Login to Your Account

1. Enter your **Username** and **Password**
2. Click **Login**
3. If login fails 3 times, you'll receive a security warning
4. Upon successful login, the **Dashboard** opens

### 3?? Set Your Calorie Goal

1. In the **Dashboard**, enter your desired **Calorie Goal**
2. Click **Set Goal** to save it
3. Your goal is now active and will display in the status area

### 4?? Add Activities

1. Select an **Activity Type** from the dropdown:
   - **Walking**: Enter steps, distance (km), and time (minutes)
   - **Swimming**: Enter laps, time (minutes), and average heart rate

2. Enter the three metrics for your activity
3. Click **Add Activity**
4. Your activity is added to the history and calories are calculated automatically

### 5?? Monitor Your Progress

1. View the **Total Calories Burned** in the dashboard
2. Check if you've **Achieved Your Goal** (status will display)
3. Click **View Progress** to see detailed statistics in the Progress Form
4. All activities with timestamps are displayed in the activity list

---

## ??? Technical Details

### Calorie Calculation Formulas

**Walking Activity**

```
Calories = (Steps × 0.04) + (Distance × 50)
```

**Swimming Activity**

```
Calories = (Laps × 30) + (Time × 8) + (Heart Rate × 0.5)
```

### Password Requirements

- **Length**: Exactly 12 characters
- **Character Types**: At least 1 lowercase, at least 1 uppercase
- **Example Valid**: `MyPassword21`, `SecurePass99`, `TestLogin123`

### Security Features

- Failed login attempt tracking (max 3 attempts)
- Username uniqueness validation
- Password strength requirements
- Session-based user data management

---

## ??? Project Architecture

### Design Patterns Used

1. **Object-Oriented Programming (OOP)**
   - Abstract classes and inheritance for activity types
   - Encapsulation with properties and methods

2. **Separation of Concerns**
   - `UserManager` handles authentication logic
   - `Validation` handles input validation
   - `User` and `Activity` handle data models
   - Forms handle UI/UX

3. **Windows Forms UI Pattern**
   - Dynamic control generation in `InitializeComponent()`
   - Event-driven architecture for user interactions

### Data Flow

```
Program.cs (Entry Point)
    ?
UserManager (Created)
    ?
LoginForm (User Authentication)
    ?
MainForm (Dashboard - Activity Tracking)
    ?
ProgressForm (Optional - View Progress)
```

---

## ?? Troubleshooting

| Issue | Solution |
|-------|----------|
| **Build fails with compiler errors** | Ensure .NET Framework 4.7.2 is installed; Right-click project ? Properties ? Target Framework |
| **Password validation error** | Password must be exactly 12 characters with uppercase and lowercase letters |
| **Cannot add activity** | Ensure all three metric fields are filled with numeric values |
| **Login locked after 3 attempts** | Wait for app restart or clear application cache |
| **Application won't open** | Try running as Administrator; Check Windows compatibility mode settings |

---

## ?? Example Workflow

```
1. Register: Username = "john123", Password = "MyPassword21"
2. Login with credentials
3. Set Goal = 500 calories
4. Add Walking Activity:
   - Steps: 5000
   - Distance: 2.5 km
   - Time: 30 minutes
   - Result: (5000 × 0.04) + (2.5 × 50) = 325 calories
5. Add Swimming Activity:
   - Laps: 10
   - Time: 45 minutes
   - Heart Rate: 130 bpm
   - Result: (10 × 30) + (45 × 8) + (130 × 0.5) = 620 calories
6. Total Calories: 945 ? Goal Achieved! ?
```

---

## ?? Contributing

If you'd like to improve this project, feel free to:
1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

---

## ?? License

This project is open source and available on GitHub at [Saidul00005/Fitness-Tracker](https://github.com/Saidul00005/Fitness-Tracker)

---

## ?? Author

Created by **Saidul00005**

---

## ?? Tips for Enhancement

Future improvements could include:
- ?? Database integration for data persistence
- ?? Chart and graph visualization of progress
- ?? Mobile companion app
- ? Reminder notifications
- ?? Multiple goal types (steps, distance, etc.)
- ?? Weekly/monthly statistics
- ?? Dark mode UI option

---

## ? FAQ

**Q: Can I run this on macOS or Linux?**  
A: This application uses Windows Forms and requires Windows. For cross-platform support, you would need to refactor to use a framework like MAUI or WPF.

**Q: Is my data saved between sessions?**  
A: Currently, user data is stored in memory and lost when the application closes. Consider implementing a database for persistence.

**Q: Can I change the password requirements?**  
A: Yes! Modify the `Validation.cs` file to adjust password complexity rules.

**Q: Can I add more activity types?**  
A: Yes! Create new classes that inherit from the `Activity` base class and implement the `CalculateCalories()` method.

---

**Happy Tracking! ????? Stay fit and achieve your goals!**
