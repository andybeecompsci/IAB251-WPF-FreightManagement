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
        private EmployeeManager _employeeManager;
        private static CustomerManager _customerManager = new CustomerManager(); //delete this 


        public EmployeeMainWindow(EmployeeManager employeeManager)
        {
            InitializeComponent();
            _employeeManager = employeeManager;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new CustomerRegistration(_customerManager);
            registerWindow.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new CustomerLogin(_customerManager);
            loginWindow.Show();
        }
    }
}
