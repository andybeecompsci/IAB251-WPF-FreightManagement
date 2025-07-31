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
    public partial class MainWindow : Page
    {
        private CustomerManager _customerManager;
        private QuotationManager _quotationManager; 


        public MainWindow(CustomerManager customerManager, QuotationManager quotationManager)
        {
            InitializeComponent();
            _customerManager = App.CustomerManager;
            _quotationManager = App.QuotationManager;
            DataContext = App.CustomerManager; // Bind CustomerManager to the DataContext
        }

        private void LogoutButton(object sender, RoutedEventArgs e)
        {
            _customerManager.Logout();
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new CustomerRegistration(_customerManager);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(registerWindow);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new CustomerLogin(_customerManager);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(loginWindow);
        }

        private void RequestQuotation_Click(object sender, RoutedEventArgs e)
        {
            var customerManager = new CustomerManager(); 
            var quotationManager = new QuotationManager(); // Initialize QuotationManager
            var requestWindow = new QuotationRequestWindow(App.CustomerManager, App.QuotationManager);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(requestWindow);
        }

        private void ViewQuotation_Click(Object sender, RoutedEventArgs e)
        {
            var customerManager = new CustomerManager();
            var quotationManager = new QuotationManager(); // Initialize QuotationManager
            var viewWindow = new CustomerQuotationView(App.QuotationManager, App.CustomerManager.CurrentUserEmail);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(viewWindow);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(new CustomerOrEmployee());
        }



    }
}