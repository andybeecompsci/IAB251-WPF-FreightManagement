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
using System.Security.Cryptography;


namespace IAB251_WPF_ASS2
{
    /// <summary>
    /// Interaction logic for EmployeeRegistration.xaml
    /// </summary>
    public partial class EmployeeRegistration : Window
    {
        private EmployeeManager employeeManager;
        
        public EmployeeRegistration(EmployeeManager manager)
        {
            InitializeComponent();
            employeeManager = manager;
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            // Validate the input fields
            if (string.IsNullOrWhiteSpace(FirstNametxt.Text) ||
                string.IsNullOrWhiteSpace(LastNametxt.Text) ||
                string.IsNullOrWhiteSpace(EmailAddresstxt.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumbertxt.Text) ||
                EmployeeTypetxt.SelectedItem == null ||
                string.IsNullOrWhiteSpace(Addresstxt.Text) ||
                string.IsNullOrWhiteSpace(Passwordtxt.Text))
            {
                Messagetxt.Text = "All fields are required!";
                return;
            }



            // Create a new Employee instance with the input data
            Employee newEmployee = new Employee
            (
                FirstNametxt.Text,
                LastNametxt.Text,
                EmailAddresstxt.Text,
                PhoneNumbertxt.Text,
                EmployeeTypetxt.Text,
                Addresstxt.Text,
                Passwordtxt.Text
            );

            // Add the employee to the EmployeeManager
            employeeManager.AddEmployee(newEmployee);

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
            EmployeeTypetxt.SelectedItem = null;
            Addresstxt.Clear();
            Passwordtxt.Clear();
            Messagetxt.Text = string.Empty;
        }
    }
}
