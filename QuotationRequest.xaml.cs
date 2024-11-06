using IAB251_ASS2.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace IAB251_WPF_ASS2
{
    public partial class QuotationRequestWindow : Page
    {
        private readonly CustomerManager customerManager;
        private readonly QuotationManager quotationManager;



        public QuotationRequestWindow(CustomerManager customerManager, QuotationManager quotationManager)
        {
            InitializeComponent();
            this.customerManager = customerManager;
            this.quotationManager = App.QuotationManager;
        }

        private void SubmitRequest_Click(object sender, RoutedEventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(SourceTextBox.Text) ||
                string.IsNullOrWhiteSpace(DestinationTextBox.Text) ||
                string.IsNullOrWhiteSpace(ContainerQuantityTextBox.Text) ||
                string.IsNullOrWhiteSpace(GoodsTypeTextBox.Text) ||
                WidthComboBox.SelectedItem == null ||  // Check if an option is selected
                string.IsNullOrWhiteSpace(HeightTextBox.Text))
            {
                MessageTextBlock.Text = "All fields are required!";
                return;
            }

            // Parse container quantity
            if (!int.TryParse(ContainerQuantityTextBox.Text, out int containerQuantity))
            {
                MessageTextBlock.Text = "Container Quantity must be a valid number.";
                return;
            }

            // Retrieve logged-in customer
            var loggedInCustomer = customerManager.IsLoggedIn ? customerManager.GetCustomerByEmail(customerManager.CurrentUserEmail) : null;

            // Debug: Check if loggedInCustomer and CurrentUserEmail are correct
            Console.WriteLine($"Attempting to retrieve customer for email: {customerManager.CurrentUserEmail}");
            if (loggedInCustomer != null)
            {
                Console.WriteLine($"Retrieved Customer: {loggedInCustomer.FirstName}, {loggedInCustomer.LastName}");
            }
            else
            {
                Console.WriteLine("No logged-in customer found.");
            }

            //combo boxes
            string selectedWidth = ((ComboBoxItem)WidthComboBox.SelectedItem).Content.ToString();
            string selectedPort = ((ComboBoxItem)PortComboBox.SelectedItem).Content.ToString();
            string selectedPack = ((ComboBoxItem)PackingComboBox.SelectedItem).Content.ToString();


            // Create a new QuotationRequest instance
            var request = new QuotationRequest
            {
                RequestID = GenerateRequestID(),
                CustomerInfo = loggedInCustomer,
                Source = SourceTextBox.Text,
                Destination = DestinationTextBox.Text,
                ContainerQuantity = containerQuantity,
                GoodsType = GoodsTypeTextBox.Text,
                Width = selectedWidth,  // Use the selected width value from ComboBox
                Height = HeightTextBox.Text,
                PortType = selectedPort,
                PackingType = selectedPack,
                QuarantineDetails = QuarantineDetailsTextBox.Text,
                FumigationDetails = FumigationDetailsTextBox.Text,
                Status = "Pending"
            };

            // debugging to check if works
            Console.WriteLine("Quotation Request Created:");
            Console.WriteLine($"RequestID: {request.RequestID}");
            Console.WriteLine($"CustomerInfo: {loggedInCustomer?.FirstName}, {loggedInCustomer?.LastName}");
            Console.WriteLine($"Source: {request.Source}");
            Console.WriteLine($"Destination: {request.Destination}");
            Console.WriteLine($"Container Quantity: {request.ContainerQuantity}");
            Console.WriteLine($"Goods Type: {request.GoodsType}");
            Console.WriteLine($"Width: {request.Width}");
            Console.WriteLine($"Height: {request.Height}");
            Console.WriteLine($"Port Type: {request.PortType}");
            Console.WriteLine($"Packing Type: {request.PackingType}");
            Console.WriteLine($"Quarantine Details: {request.QuarantineDetails}");
            Console.WriteLine($"Fumigation Details: {request.FumigationDetails}");
            Console.WriteLine($"Status: {request.Status}");
            Console.WriteLine($"Message: {request.Message}");

            // Add to quotation manager
            quotationManager.AddQuotationRequest(request);
            Console.WriteLine($"Quotation Request added: RequestID: {request.RequestID}, Status: {request.Status}");


            // tranform quotation request to quotation
            quotationManager.RequestToQuotation(request);

            // Clear form and show success message
            ClearForm();
            MessageTextBlock.Text = "Quotation request submitted successfully!";
        }

        private void ClearForm()
        {
            SourceTextBox.Clear();
            DestinationTextBox.Clear();
            ContainerQuantityTextBox.Clear();
            GoodsTypeTextBox.Clear();
            //WidthComboBox.Clear();
            HeightTextBox.Clear();
            //PortTypeTextBox.Clear();
            //PackingTypeTextBox.Clear();
            QuarantineDetailsTextBox.Clear();
            FumigationDetailsTextBox.Clear();
            MessageTextBlock.Text = string.Empty;
        }

        

        private int GenerateRequestID()
        {
            // Implement a method to generate unique Request IDs
            return new Random().Next(1, 1000);
        }
    }
}
