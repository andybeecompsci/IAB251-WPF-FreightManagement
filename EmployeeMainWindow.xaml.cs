using IAB251_ASS2.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace IAB251_WPF_ASS2
{
    /// <summary>
    /// Interaction logic for EmployeeMainWindow.xaml
    /// </summary>
    public partial class EmployeeMainWindow : Page
    {
        private static EmployeeManager _employeeManager;
        private QuotationManager _quotationManager;

        public EmployeeMainWindow(EmployeeManager employeeManager)
        {
            InitializeComponent();
            _employeeManager = employeeManager;
            _quotationManager = new QuotationManager();
            DataContext = _employeeManager; // Bind EmployeeManager to the DataContexts
        }

        private void LogoutButton(object sender, RoutedEventArgs e)
        {
            _employeeManager.SetLoggedInStatus(false);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new EmployeeRegistration(_employeeManager);

            // Navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(registerWindow);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new EmployeeLogin(_employeeManager);

            // Navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(loginWindow);
        }

        private void ViewAllQuotations_Click(object sender, RoutedEventArgs e)
        {
            var quotationViewWindow = new QuotationView(_quotationManager, _employeeManager);

            // Navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(quotationViewWindow);
        }

        private void ViewRateSchedule_Click(object sender, RoutedEventArgs e)
        {
            // Use the existing _quotationManager and _employeeManager
            var rateScheduleViewWindow = new RateSchedule(_quotationManager, _employeeManager);

            // Navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(rateScheduleViewWindow);
        }

        private void PrepareQuotations_Click(object sender, RoutedEventArgs e)
        {
            var requestViewWindow = new OfficerRequestView(_quotationManager, _employeeManager);

            // Navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(requestViewWindow);
        }
    }
}
