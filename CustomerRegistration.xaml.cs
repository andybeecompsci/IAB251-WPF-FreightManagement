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
    /// Interaction logic for CustomerRegistration.xaml
    /// </summary>
    public partial class CustomerRegistration : Page
    {
        private CustomerManager customerManager;

        public CustomerRegistration(CustomerManager manager)
        {
            InitializeComponent();
            customerManager = manager;
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            // Validate the input fields
            if (string.IsNullOrWhiteSpace(FirstNametxt.Text) ||
                string.IsNullOrWhiteSpace(LastNametxt.Text) ||
                string.IsNullOrWhiteSpace(EmailAddresstxt.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumbertxt.Text) ||
                string.IsNullOrWhiteSpace(Addresstxt.Text) ||
                string.IsNullOrWhiteSpace(Passwordtxt.Password))
            {
                Messagetxt.Text = "All fields are required!";
                return;
            }

            // Create a new Customer instance with the input data
            Customer newCustomer = new Customer
            {
                FirstName = FirstNametxt.Text,
                LastName = LastNametxt.Text,
                EmailAddress = EmailAddresstxt.Text,
                PhoneNumber = PhoneNumbertxt.Text,
                Address = Addresstxt.Text,
                Password = Passwordtxt.Password
            };

            // Add the customer to CustomerManager
            customerManager.AddCustomer(newCustomer);

            // Clear the form and display a success message
            ClearForm();
            Messagetxt.Text = "Registration successful!";
        }

        private void ClearForm()
        {
            FirstNametxt.Clear();
            LastNametxt.Clear();
            EmailAddresstxt.Clear();
            PhoneNumbertxt.Clear();
            Addresstxt.Clear();
            Passwordtxt.Clear();
            Messagetxt.Text = string.Empty;
        }
    }
}