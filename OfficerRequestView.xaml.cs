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
    /// Interaction logic for OfficerRequestView.xaml
    /// </summary>
    public partial class OfficerRequestView : Window
    {
        
        private QuotationManager quotationManager;
        public OfficerRequestView()
        {
            InitializeComponent();
            quotationManager = new QuotationManager();

            // bind quotation requests to grid
            RequestDataGrid.ItemsSource = quotationManager.GetPendingRequests();

            // maybe load example data ??

        }

        // accept quotation request
        private void AcceptRequest(object sender, RoutedEventArgs e)
        {
            if (RequestDataGrid.SelectedItem is QuotationRequest selectedRequest)
            {
                quotationManager.AcceptQuotationRequest(selectedRequest.RequestID);
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
                quotationManager.RejectQuotationRequest(selectedRequest.RequestID, message);
                RefreshDataGrid();
                Messagetxt.Text = "Request rejected";
                rejectMessagetxt.Clear();
            }
            else
            {
                Messagetxt.Text = "Select a request to reject";
            }
        }


        // refresh grid view
        private void RefreshDataGrid()
        {
            RequestDataGrid.ItemsSource = null;
            RequestDataGrid.ItemsSource = quotationManager.GetPendingRequests();
        }
    }
}
