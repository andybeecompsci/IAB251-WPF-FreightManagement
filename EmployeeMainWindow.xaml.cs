using IAB251_ASS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IAB251_WPF_ASS2
{
    /// <summary>
    /// Interaction logic for EmployeeMainWindow.xaml
    /// </summary>
    public partial class EmployeeMainWindow : Page
    {
        private static EmployeeManager _employeeManager = new EmployeeManager();
        private QuotationManager _quotationManager = new QuotationManager();

        //testing

        private void LogoutButton(object sender, RoutedEventArgs e)
        {
            _employeeManager.Logout();
        }

        public EmployeeMainWindow(EmployeeManager employeeManager)
        {
            InitializeComponent();
            _employeeManager = employeeManager;
            _quotationManager = new QuotationManager();
            DataContext = _employeeManager; // Bind EmployeeManager to the DataContexts
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new EmployeeRegistration(_employeeManager);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(registerWindow);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new EmployeeLogin(_employeeManager);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(loginWindow);
        }

        private void ViewAllQuotations_Click(object sender, RoutedEventArgs e)
        {
            var employeeManager = new EmployeeManager();
            var quotationManager = new QuotationManager(); // Initialize QuotationManager
            var quotationviewWindow = new QuotationView(_quotationManager, _employeeManager);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(quotationviewWindow);
        }

        private void ViewRateSchedule_Click(object sender, RoutedEventArgs e) // update once jake has pushed
        {
            var employeeManager = new EmployeeManager();
            var quotationManager = new QuotationManager(); // Initialize QuotationManager
            //var ratescheduleviewWindow = new RateSchedule();
      

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            //mainwindow.NavigateToPage(ratescheduleviewWindow);
        }

        private void PrepareQuotations_Click(object sender, RoutedEventArgs e)
        {
            var employeeManager = new EmployeeManager();
            var quotationManager = new QuotationManager(); // Initialize QuotationManager
            var requestviewWindow = new OfficerRequestView(_quotationManager, _employeeManager);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(requestviewWindow);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(new CustomerOrEmployee());
        }
    }
}
