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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // InitializeComponent(); 
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Open the registration form
            var registerWindow = new EmployeeRegistration();
            registerWindow.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a class called LoginWindow for the login form
            var loginWindow = new loginpagename(); // Ensure the LoginWindow class exists
            loginWindow.Show();
        }

        private void RequestQuotation_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a class called QuotationWindow for the quotation form
            var quotationWindow = new Quotationpagename(); // Ensure the QuotationWindow class exists
            quotationWindow.Show();
        }
    }
}
