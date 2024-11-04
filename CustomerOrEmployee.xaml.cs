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
    public partial class CustomerOrEmployee : Window
    {
        private static CustomerManager _customerManager = new CustomerManager();
        //employee version of this ^^^ goes here
        public CustomerOrEmployee()
        {
            _customerManager = new CustomerManager();
            //employee version of this ^^^ goes here

            InitializeComponent();
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(_customerManager, new QuotationManager());
            mainWindow.Show();
            this.Close();
        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            var EmployeeWindow = new CustomerLogin(_customerManager);

            EmployeeWindow.Show();

        }
    }
}
