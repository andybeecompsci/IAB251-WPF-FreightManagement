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
    /// Interaction logic for QuotationView.xaml
    /// </summary>
    /// 
    public partial class QuotationView : Window
    {
        private QuotationManager quotationManager;
        private EmployeeManager employeeManager;
        public QuotationView(QuotationManager quotationManager, EmployeeManager employeeManager)
        {
            InitializeComponent();
            this.quotationManager = quotationManager;
            this.employeeManager = employeeManager; 

            // bind the data to grid
            QuotationGridView.ItemsSource = quotationManager.GetQuotations();

            // add something to load sample data maybe?

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var employeeMainWindow = new EmployeeMainWindow(employeeManager);
            employeeMainWindow.Show();
            this.Close();
        }

        // button for loading quotations
        private void LoadQuotations(object sender, RoutedEventArgs e)
        {
            // refreshes grid
            QuotationGridView.ItemsSource = null;
            QuotationGridView.ItemsSource = quotationManager.GetQuotations();
        }
    }
}
