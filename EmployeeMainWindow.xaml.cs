using IAB251_WPF_ASS2.Models;
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
        private EmployeeManager _employeeManager;
        private QuotationManager _quotationManager;



        public EmployeeMainWindow(EmployeeManager employeeManager)
        {
            InitializeComponent();
            _employeeManager = App.EmployeeManager;
            _quotationManager = App.QuotationManager;
            DataContext = App.EmployeeManager; // Bind EmployeeManager to the DataContexts
        }
        private void LogoutButton(object sender, RoutedEventArgs e)
        {
            _employeeManager.Logout();
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
            var quotationviewWindow = new QuotationView(_quotationManager, _employeeManager);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(quotationviewWindow);
        }

        private void ViewRateSchedule_Click(object sender, RoutedEventArgs e) // update once jake has pushed
        {
            var ratescheduleviewWindow = new RateSchedule(_quotationManager, _employeeManager);


            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(ratescheduleviewWindow);
        }

        private void PrepareQuotations_Click(object sender, RoutedEventArgs e)
        {
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
