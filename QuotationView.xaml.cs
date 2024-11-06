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
    public partial class QuotationView : Page
    {
        private QuotationManager _quotationManager;
        private EmployeeManager _employeeManager;
        public QuotationView(QuotationManager quotationManager, EmployeeManager employeeManager)
        {
            InitializeComponent();
            _quotationManager = App.QuotationManager;
            _employeeManager = App.EmployeeManager;

            // bind the data to grid
            QuotationGridView.ItemsSource = _quotationManager.GetQuotations(); 
            // add something to load sample data maybe?

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var employeeMainWindow = new EmployeeMainWindow(_employeeManager);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(employeeMainWindow);
        }

        // button for loading quotations
        private void LoadQuotations(object sender, RoutedEventArgs e)
        {
            // refreshes grid
            QuotationGridView.ItemsSource = null;
            QuotationGridView.ItemsSource = _quotationManager.GetQuotations(); //changed from GetQuotations 
        }
    }
}
