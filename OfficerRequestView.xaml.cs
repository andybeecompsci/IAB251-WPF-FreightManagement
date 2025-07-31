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
using System.Windows.Shapes;

namespace IAB251_WPF_ASS2
{
    /// <summary>
    /// Interaction logic for OfficerRequestView.xaml
    /// </summary>
    public partial class OfficerRequestView : Page
    {
        
        private QuotationManager _quotationManager;
        private EmployeeManager _employeeManager;
        private QuotationRequest selectedRequest;
        //private Quotation 
        public double discountPercentage;
        public OfficerRequestView(QuotationManager quotationManager, EmployeeManager employeeManager)
        {
            InitializeComponent();
            _quotationManager = App.QuotationManager;
            _employeeManager = App.EmployeeManager;

            // Bind pending requests to DataGrid
            var pendingRequests = App.QuotationManager.GetPendingRequests(); 
            Console.WriteLine($"Pending requests count: {pendingRequests.Count}"); 
            foreach (var req in pendingRequests) 
            {
                Console.WriteLine($"RequestID: {req.RequestID}, Client: {req.ClientName}, Status: {req.Status}"); 
            }
            RequestDataGrid.ItemsSource = pendingRequests; 

        }


        private void RequestDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RequestDataGrid.SelectedItem is QuotationRequest request)
            {
                selectedRequest = request;

                var currentquotation = App.QuotationManager.QuotationByNumber(selectedRequest.RequestID);
                
                //display charges

                DepotChargesAmount.Text = currentquotation.DepotCharges.ToString("C");
                LCLChargesAmount.Text = currentquotation.LCLCharges.ToString("C");
                TotalChargesAmount.Text = (currentquotation.DepotCharges+ currentquotation.LCLCharges).ToString("C");
                // Calculate and display discount
                discountPercentage = App.QuotationManager.CalculateDiscount(request.ContainerQuantity, request.QuarantineDetails, request.FumigationDetails);
                DiscountAmount.Text = discountPercentage.ToString("0.##") + "%";
            }
        }

        private void DiscountAndAccept(object sender, RoutedEventArgs e)
        {
            if (selectedRequest != null)
            {
                Messagetxt.Text = "Discount applied and quotation accepted";

                //apply discount    
                App.QuotationManager.ApplyDiscount(discountPercentage, selectedRequest.RequestID);

                //update the request status 
                App.QuotationManager.AcceptQuotationRequest(selectedRequest.RequestID);
                RefreshDataGrid();  //refresh the list 
            }
            else
            {
                Messagetxt.Text = "Select a request to accept";
            }
        }

            // accept quotation request
            private void AcceptRequest(object sender, RoutedEventArgs e)
        {
            if (RequestDataGrid.SelectedItem is QuotationRequest selectedRequest)
            {
                App.QuotationManager.AcceptQuotationRequest(selectedRequest.RequestID);
                RefreshDataGrid();
                Messagetxt.Text = "Request accepted";
            }
            else
            {
                Messagetxt.Text = "Select a request to accept";
            }
        }

        // reject quotation request
        private void RejectRequest(object sender, RoutedEventArgs e)
        {
            if (RequestDataGrid.SelectedItem is QuotationRequest selectedRequest)
            {
                string message = rejectMessagetxt.Text;
                if (string.IsNullOrWhiteSpace(message))
                {
                    Messagetxt.Text = "Enter a rejection message";
                    return;
                }
                App.QuotationManager.RejectQuotationRequest(selectedRequest.RequestID, message);
                RefreshDataGrid();
                Messagetxt.Text = "Request rejected";
                rejectMessagetxt.Clear();
            }
            else
            {
                Messagetxt.Text = "Select a request to reject";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var employeeMainWindow = new EmployeeMainWindow(_employeeManager);
            
            //navigate to page
            var mainwindow = (NewMainWindow)Application.Current.MainWindow;
            mainwindow.NavigateToPage(employeeMainWindow);
        }
        // refresh grid view
        private void RefreshDataGrid()
        {
            RequestDataGrid.ItemsSource = null;
            RequestDataGrid.ItemsSource = App.QuotationManager.GetPendingRequests();
        }
    }
}
