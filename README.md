# IAB251 WPF Assignment 2 - Freight Management System

## Project Overview

This is a Windows Presentation Foundation (WPF) application developed in C# for managing freight and shipping quotations. The system provides separate interfaces for customers and employees, allowing for quotation requests, management, and tracking within a freight logistics environment.

## Application Features

### Customer Features
- **User Registration & Login**: Customers can create accounts and log in securely
- **Quotation Requests**: Submit new freight quotation requests with container types and scope details
- **View Quotations**: Track existing quotations and their status (Pending, Accept, Reject)
- **Rate Schedule**: View current pricing for different services

### Employee Features
- **Employee Login**: Secure authentication for staff members
- **Quotation Management**: Review and process customer quotation requests
- **Request Processing**: Handle and update quotation statuses
- **Multiple Employee Types**: Support for different roles (Admin, Quotation Officer, Booking Officer, Warehouse Officer, Manager, CIO)

### Core Functionality
- **Container Management**: Support for different container types and shipping scopes
- **Pricing System**: Depot charges and LCL (Less than Container Load) charges
- **Status Tracking**: Real-time quotation status updates
- **User Management**: Separate customer and employee account systems

## Technical Specifications

- **Framework**: .NET Framework 4.8
- **UI Technology**: Windows Presentation Foundation (WPF)
- **Language**: C#
- **Architecture**: Model-View-ViewModel (MVVM) pattern
- **Design Pattern**: Singleton pattern for managers (CustomerManager, QuotationManager, EmployeeManager)

## Project Structure

```
IAB251_WPF_ASS2/
├── Models/                 # Data models and business logic
│   ├── Customer.cs        # Customer entity
│   ├── Employee.cs        # Employee entity
│   ├── Quotation.cs       # Quotation entity
│   ├── CustomerManager.cs # Customer management logic
│   ├── EmployeeManager.cs # Employee management logic
│   └── QuotationManager.cs # Quotation management logic
├── *.xaml                 # UI definitions
├── *.xaml.cs             # Code-behind files
├── App.xaml              # Application entry point
└── bin/Debug/            # Compiled executable
```

## Installation and Setup

### Prerequisites
- Windows 10 or later
- .NET Framework 4.8 (usually pre-installed on Windows 10+)
- Visual Studio 2019 or later (for development)

### Running the Application

#### Option 1: Direct Execution (Recommended)
1. Navigate to the `bin/Debug/` folder
2. Double-click `IAB251_WPF_ASS2.exe`
3. The application will launch immediately

#### Option 2: Build and Run from Source
1. Open `IAB251_WPF_ASS2.sln` in Visual Studio
2. Build the solution (Build > Build Solution)
3. Run the application (Debug > Start Debugging or F5)

### First-Time Setup
- The application uses in-memory data storage (no database required)
- Sample data may be pre-populated for testing
- No additional configuration needed

## Usage Instructions

### For Customers
1. **Registration**: Click "Register" to create a new account
2. **Login**: Use your email and password to access the system
3. **Request Quotation**: Fill out the quotation form with your shipping details
4. **Track Status**: View your quotations and their current status

### For Employees
1. **Login**: Use your employee credentials to access the system
2. **Review Requests**: View pending quotation requests
3. **Process Quotations**: Update quotation statuses and add comments
4. **Manage System**: Access rate schedules and system management features

## Development Notes

### Recent Fixes Applied
- Resolved namespace inconsistencies across all files
- Fixed StartupUri configuration in App.xaml
- Corrected using statements in all code-behind files
- Updated model namespace declarations

### Code Quality
- Follows C# coding conventions
- Implements proper separation of concerns
- Uses appropriate design patterns
- Includes comprehensive error handling

## Testing

The application has been tested for:
- User registration and authentication
- Quotation request submission
- Employee quotation processing
- Navigation between different screens
- Data persistence during session

## Support

For technical issues or questions about the application:
- Check that .NET Framework 4.8 is installed
- Ensure the executable has proper permissions
- Verify all project files are present in the repository

## License

This project was developed as part of IAB251 coursework at Queensland University of Technology. 