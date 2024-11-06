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
    /// Interaction logic for EmployeeLogin.xaml
    /// </summary>
    public partial class EmployeeLogin : Page
    {
        private EmployeeManager employeeManager;
        public EmployeeLogin(EmployeeManager manager)
        {
            InitializeComponent();
            employeeManager = App.EmployeeManager;
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailAddresstxt.Text) || string.IsNullOrWhiteSpace(Passwordtxt.Password))
            {
                Messagetxt.Text = "Email and password are required!";
                return;
            }

            bool isLoggedIn = employeeManager.ValidateLogin(EmailAddresstxt.Text, Passwordtxt.Password);

            if (isLoggedIn)
            {
                Messagetxt.Text = "Login successful!";
                var employeeMainWindow = new EmployeeMainWindow(employeeManager);

                //navigate to page
                var mainwindow = (NewMainWindow)Application.Current.MainWindow;
                mainwindow.NavigateToPage(employeeMainWindow);
            }
            else
            {
                Messagetxt.Text = "Invalid email or password.";
            }
        }
    }
}
