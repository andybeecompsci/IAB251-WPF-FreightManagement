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
    public partial class CustomerLogin : Page
    {
        private CustomerManager customerManager;
        private QuotationManager quotationManager;

        public CustomerLogin(CustomerManager manager)
        {
            InitializeComponent();
            customerManager = manager;
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailAddresstxt.Text) || string.IsNullOrWhiteSpace(Passwordtxt.Password))
            {
                Messagetxt.Text = "Email and password are required!";
                return;
            }

            bool isLoggedIn = customerManager.ValidateLogin(EmailAddresstxt.Text, Passwordtxt.Password);

            if (isLoggedIn)
            {
                Messagetxt.Text = "Login successful!";
                var customerMainWindow = new MainWindow(customerManager, quotationManager);

                // Navigate to another window or perform other actions on successful login
                var mainwindow = (NewMainWindow)Application.Current.MainWindow;
                mainwindow.NavigateToPage(customerMainWindow);
            }
            else
            {
                Messagetxt.Text = "Invalid email or password.";
            }
        }
    }
}
