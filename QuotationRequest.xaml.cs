using IAB251_ASS2.Models;
using System;
using System.Windows;

namespace IAB251_WPF_ASS2
{
    public partial class QuotationRequestWindow : Window
    {
        private readonly CustomerManager customerManager;
        private readonly QuotationManager quotationManager;

        public QuotationRequestWindow(CustomerManager customerManager, QuotationManager quotationManager)
        {
            InitializeComponent();
            this.customerManager = customerManager;
            this.quotationManager = quotationManager;
        }

        private void SubmitRequest_Click(object sender, RoutedEventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(SourceTextBox.Text) ||
                string.IsNullOrWhiteSpace(DestinationTextBox.Text) ||
                string.IsNullOrWhiteSpace(ContainerQuantityTextBox.Text) ||
                string.IsNullOrWhiteSpace(GoodsTypeTextBox.Text) ||
                string.IsNullOrWhiteSpace(WidthTextBox.Text) ||
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

            // Create a new QuotationRequest instance
            var request = new QuotationRequest
            {
                RequestID = GenerateRequestID(),
                CustomerInfo = customerManager.IsLoggedIn ? customerManager.GetCustomerByEmail(customerManager.CurrentUserEmail) : null,
                Source = SourceTextBox.Text,
                Destination = DestinationTextBox.Text,
                ContainerQuantity = containerQuantity,
                GoodsType = GoodsTypeTextBox.Text,
                Width = WidthTextBox.Text,
                Height = HeightTextBox.Text,
                PortType = PortTypeTextBox.Text,
                PackingType = PackingTypeTextBox.Text,
                QuarantineDetails = QuarantineDetailsTextBox.Text,
                FumigationDetails = FumigationDetailsTextBox.Text,
                Status = "Pending"
            };

            // Add to quotation manager
            quotationManager.AddQuotationRequest(request);

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
            WidthTextBox.Clear();
            HeightTextBox.Clear();
            PortTypeTextBox.Clear();
            PackingTypeTextBox.Clear();
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
