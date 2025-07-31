using System.Windows;
using System.Windows.Controls;
using IAB251_WPF_ASS2.Models;

namespace IAB251_WPF_ASS2
{
    /// <summary>
    /// Interaction logic for CustomerQuotationView.xaml
    /// </summary>
    public partial class CustomerQuotationView : Page
    {
        private readonly QuotationManager _quotationManager;
        private readonly string _customerEmail;

        public CustomerQuotationView(QuotationManager quotationManager, string customerEmail)
        {
            InitializeComponent();
            _quotationManager = quotationManager;
            _customerEmail = customerEmail;

            // Automatically load quotations for this customer
            LoadQuotations();
        }

        // Loads quotations specific to the customer
        private void LoadQuotations()
        {
            // Retrieve and display quotations for the customer in the DataGrid
            QuotationGridView.ItemsSource = _quotationManager.GetQuotationsForCustomer(_customerEmail);
        }

        // Handle Proceed button click
        private void ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuotationGridView.SelectedItem is Quotation selectedQuotation)
            {
                string message = MessageTextBox.Text;
                _quotationManager.UpdateQuotationStatus(selectedQuotation.QuotationNumber, "Proceed", message);
                MessageBox.Show("You have chosen to proceed with this quotation.");
                LoadQuotations(); // Refresh DataGrid to show updated status
            }
            else
            {
                MessageBox.Show("Please select a quotation to proceed.");
            }
        }

        // Handle Reject button click
        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (QuotationGridView.SelectedItem is Quotation selectedQuotation)
            {
                string message = MessageTextBox.Text;
                _quotationManager.UpdateQuotationStatus(selectedQuotation.QuotationNumber, "Rejected", message);
                MessageBox.Show("You have rejected this quotation.");
                LoadQuotations(); // Refresh DataGrid to show updated status
            }
            else
            {
                MessageBox.Show("Please select a quotation to reject.");
            }
        }

        // Handle Back button click to navigate back to the previous customer page
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var customerMainWindow = new MainWindow(App.CustomerManager, App.QuotationManager);

            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(customerMainWindow);
        }
    }
}
