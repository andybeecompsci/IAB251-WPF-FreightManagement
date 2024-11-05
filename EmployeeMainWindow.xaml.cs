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
    public partial class EmployeeMainWindow : Window
    {
        private static EmployeeManager _employeeManager = new EmployeeManager();
        private QuotationManager _quotationManager = new QuotationManager();


        public EmployeeMainWindow(EmployeeManager employeeManager)
        {
            InitializeComponent();
            _employeeManager = employeeManager;
            _quotationManager = new QuotationManager();
            DataContext = _employeeManager; // Bind EmployeeManager to the DataContext
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new EmployeeRegistration(_employeeManager);
            registerWindow.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new EmployeeLogin(_employeeManager);
            loginWindow.Show();
        }

        private void ViewAllQuotations_Click(object sender, RoutedEventArgs e)
        {
            var employeeManager = new EmployeeManager();
            var quotationManager = new QuotationManager(); // Initialize QuotationManager
            var quotationviewWindow = new QuotationView(_quotationManager, _employeeManager);
            quotationviewWindow.Show();
        }

        private void ViewRateSchedule_Click(object sender, RoutedEventArgs e)
        {
            //var employeeManager = new EmployeeManager();
            //var quotationManager = new QuotationManager(); // Initialize QuotationManager
            var ratescheduleviewWindow = new RateSchedule();
            ratescheduleviewWindow.Show();
        }

        private void PrepareQuotations_Click(object sender, RoutedEventArgs e)
        {
            var employeeManager = new EmployeeManager();
            var quotationManager = new QuotationManager(); // Initialize QuotationManager
            var requestviewWindow = new OfficerRequestView(_quotationManager, _employeeManager);
            requestviewWindow.Show();
        }
    }
}
