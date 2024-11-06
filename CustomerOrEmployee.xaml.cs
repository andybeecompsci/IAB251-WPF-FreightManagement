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
using System.Windows.Shapes;

namespace IAB251_WPF_ASS2
{
    /// <summary>
    /// Interaction logic for CustomerOrEmployee.xaml
    /// </summary>
    public partial class CustomerOrEmployee : Page
    {
        // Management class instances for handling related to customers.
        private static CustomerManager _customerManager = new CustomerManager();

        // Management class instances for handling related to employees.
        private static EmployeeManager _employeeManager = new EmployeeManager();



        public CustomerOrEmployee()
        {
            // Instantiate managers for use in this page.
            _customerManager = new CustomerManager();
            _employeeManager = new EmployeeManager();


            InitializeComponent();
        }

        // Handles the click event for the Customer button
        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            var customermainWindow = new MainWindow(_customerManager, new QuotationManager());

            // navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(customermainWindow);
        }

        // Handles the click event for the Employee button
        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            var employeeManager = new EmployeeManager();
            var employeeMainWindow = new EmployeeMainWindow(employeeManager);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(employeeMainWindow);


        }
        // Handles the click event for the Exit button
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
