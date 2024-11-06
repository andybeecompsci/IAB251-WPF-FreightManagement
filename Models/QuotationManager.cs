using IAB251_WPF_ASS2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_ASS2.Models
{
    public class QuotationManager
    {
        private List<QuotationRequest> quotationRequests { get; set; } = new List<QuotationRequest>();

        //add Quotation Request
        public void AddQuotationRequest(QuotationRequest qRequest) 
        {
            quotationRequests.Add(qRequest);

            //debug
            Console.WriteLine("Quotation Request added to manager:");
            Console.WriteLine($"RequestID: {qRequest.RequestID}, Status: {qRequest.Status}, Customer: {qRequest.CustomerInfo?.FirstName} {qRequest.CustomerInfo?.LastName}");
        }

        //retrive quotation request by ID
        public QuotationRequest GetQuotationRequest(int id)
        {
            return quotationRequests.FirstOrDefault(r => r.RequestID == id);
        }


        // store quotations in a list

        //make list of pending quotations 
        public List<QuotationRequest> GetPendingRequests()
        {
            var pendingRequests = quotationRequests.Where(r => r.Status == "Pending").ToList();
            Console.WriteLine($"Retrieved Pending Requests: Pending requests count: {pendingRequests.Count}");
            return pendingRequests;
        }

        private List<Quotation> quotations = new List<Quotation>();

        // retreive quotations
        public List<Quotation> GetQuotations()
        {
            return quotations;
        }

        // add quotation
        public void AddQuotation(Quotation quotation)
        {
            quotations.Add(quotation);
        }

        public Quotation RequestToQuotation(QuotationRequest request)
        {
            // Hardcode charges based on container type
            decimal lclCharges = request.Width == "20" ? 400m : 500m; // $400 for 20ft, $500 for 40ft
            decimal depotCharges = request.Width == "20" ? 1375m : 1782m; // $1375 for 20ft, $1782 for 40ft

            int quotationNumber = request.RequestID;
            string clientName = $"{request.CustomerInfo.FirstName} {request.CustomerInfo.LastName}";
            string clientEmail = request.CustomerInfo.EmailAddress;
            DateTime dateIssued = DateTime.Now;
            string status = request.Status;
            string containerType = request.Width;
            string scope = $"Container Quantity: {request.ContainerQuantity}, Goods Type: {request.GoodsType}, Port Type: {request.PortType}, Packing Type: {request.PackingType}, Quarantine Detail: {request.QuarantineDetails}, Fumigation Details: {request.FumigationDetails}";
            string message = "";


            // Create a new Quotation object with hardcoded charges
            Quotation quotation = new Quotation(
                quotationNumber,
                clientName,
                clientEmail,
                dateIssued,
                status,
                containerType,
                scope,
                depotCharges,
                lclCharges,
                message
            );

            // Add quotation to list
            AddQuotation(quotation);
            return quotation;
        }


        // calculate discount
        public double CalculateDiscount(int containerquantity, string quarantinedetails, string fumigationdetails)
        {
            bool QuarantineRequired = !string.IsNullOrEmpty(quarantinedetails);
            bool FumigationRequired = !string.IsNullOrEmpty(fumigationdetails);

            if (containerquantity > 10 && QuarantineRequired && FumigationRequired)
                return 10.0;
            else if (containerquantity > 5 && QuarantineRequired && FumigationRequired)
                return 5.0;
            else if (containerquantity > 5 && (QuarantineRequired || FumigationRequired))
                return 2.5;
            else
                return 0;
        }

        // apply discount
        public void ApplyDiscount(double discount, int requestID)
        {
            var quotationnumber = quotations.FirstOrDefault(r => r.QuotationNumber == requestID);
            if (discount > 0)
            {
                decimal discountApplied = 1 - ((decimal)discount / 100);
                quotationnumber.DepotCharges *= discountApplied;
                quotationnumber.LCLCharges *= discountApplied;
            }
        }

        // retreive quotation by number // IS THIS NEEDED
        public Quotation QuotationByNumber(int quotationNumber)
        {
            return quotations.FirstOrDefault(q => q.QuotationNumber == quotationNumber);
        }

        // accepts quotation and updates status to Accepted
        public void AcceptQuotationRequest(int requestID)
        {
            var request = quotationRequests.FirstOrDefault(r => r.RequestID == requestID);
            var quotation = quotations.FirstOrDefault(r => r.QuotationNumber == requestID);
            if (request != null && quotation != null)
            {
                request.Status = "Accepted";
                quotation.Status = "Accepted";
                quotation.Message = "Your quotation has been accepted.";
            }
        }
        public List<Quotation> GetQuotationsForCustomer(string customerEmail)
        {
            return quotations.Where(q => q.ClientEmail.Equals(customerEmail, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        // Update quotation status to Proceed or Reject with customer message
        public void UpdateQuotationStatus(int quotationNumber, string status, string message = "")
        {
            var quotation = quotations.FirstOrDefault(q => q.QuotationNumber == quotationNumber);
            if (quotation != null)
            {
                quotation.Status = status;
                quotation.Message = message;
            }
        }

        // rejects quotation and updates status to Rejected
        public void RejectQuotationRequest(int requestID, string message)
        {
            var request = quotationRequests.FirstOrDefault(r => r.RequestID == requestID);
            var quotation = quotations.FirstOrDefault(r => r.QuotationNumber == requestID);
            if (request != null && quotation != null)
            {
                request.Status = "Rejected";
                quotation.Status = "Rejected";
                quotation.Message = message;
            }
        }
    
    }

    public static class RateExtension
    {
        public static decimal GetFeeByContainerSize(this Rate rate, string containerSize)
        {
            // Check if containerSize is "20ft" and select the appropriate fee
            string feeString = containerSize == "20ft" ? rate.TwentyFtFee : rate.FortyFtFee;
            return decimal.Parse(feeString.Trim('$'));  // Remove '$' and parse to decimal
        }
    }
}
