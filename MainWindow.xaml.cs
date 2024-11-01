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
        private CustomerManager customerManager;
        private QuotationManager quotationManager;

        public MainWindow()
        {
            InitializeComponent();
            customerManager = new CustomerManager();
            DataContext = customerManager; // Bind CustomerManager to the DataContext
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new CustomerRegistration(customerManager);
            registerWindow.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new CustomerLogin(customerManager);
            loginWindow.Show();
        }

        private void RequestQuotation_Click(object sender, RoutedEventArgs e)
        {
            var requestWindow = new QuotationRequestWindow(customerManager, quotationManager);
            requestWindow.Show();
        }
    }
}