using IAB251_WPF_ASS2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IAB251_ASS2.Models
{
    public class QuotationManager
    {
        private List<QuotationRequest> quotationRequests = new List<QuotationRequest>();
        private List<Quotation> quotations = new List<Quotation>();

        public void AddQuotationRequest(QuotationRequest qRequest)
        {
            quotationRequests.Add(qRequest);
        }

        public QuotationRequest GetQuotationRequest(int id)
        {
            return quotationRequests.FirstOrDefault(r => r.RequestID == id);
        }

        public List<QuotationRequest> GetPendingRequests()
        {
            return quotationRequests.Where(r => r.Status == "Pending").ToList();
        }

        public List<Quotation> GetQuotations()
        {
            GenerateSampleQuotations();
            return quotations;
        }

        public void AddQuotation(Quotation quotation)
        {
            quotations.Add(quotation);
        }

        public Quotation RequestToQuotation(QuotationRequest request)
        {
            decimal lclCharges = RateSchedule.Rates
                .FirstOrDefault(r => r.Type == "LCL Delivery Depot" && r.Type == request.Width + "ft")?
                .GetFeeByContainerSize(request.Width) ?? 0;

            int quotationnumber = request.RequestID;
            string clientname = $"{request.CustomerInfo.FirstName} {request.CustomerInfo.LastName}";
            string clientemail = request.CustomerInfo.EmailAddress;
            DateTime dateissue = DateTime.Now;
            string status = request.Status;
            string containertype = request.Width;
            string scope = $"Container Quantity: {request.ContainerQuantity}Goods Type: {request.GoodsType}, Port Type: {request.PortType}, Packing Type: {request.PackingType}, " +
                $"Quarantine Detail: {request.QuarantineDetails}, Fumigation Details: {request.FumigationDetails}";
            string message = "";
            // figure out charges
            // NEED FUNCTION FROM RATE SCHEDULE I THINK
            //decimal charges =  0;//baseCharge * request.ContainerQuantity;
            decimal depotcharges = 0; // Assume a fixed depot charge
            decimal lclcharges = 0; // Assume a fixed LCL delivery charge


            decimal gstAmount = depotCharges * 0.10m;  // 10% GST on depot charges

            Quotation quotation = new Quotation(
                request.RequestID,
                $"{request.CustomerInfo.FirstName} {request.CustomerInfo.LastName}",
                request.CustomerInfo.EmailAddress,
                DateTime.Now,
                request.Status,
                request.Width,
                $"Container Quantity: {request.ContainerQuantity}, Goods Type: {request.GoodsType}, Port Type: {request.PortType}, Packing Type: {request.PackingType}, Quarantine Detail: {request.QuarantineDetails}, Fumigation Details: {request.FumigationDetails}",
                depotCharges + gstAmount,  // Including GST in depot charges
                lclCharges,
                ""
            );

            AddQuotation(quotation);
            return quotation;
        }

        public double CalculateDiscount(int containerQuantity, string quarantineDetails, string fumigationDetails)
        {
            bool quarantineRequired = !string.IsNullOrEmpty(quarantineDetails);
            bool fumigationRequired = !string.IsNullOrEmpty(fumigationDetails);

            if (containerQuantity > 10 && quarantineRequired && fumigationRequired)
                return 10.0;
            else if (containerQuantity > 5 && quarantineRequired && fumigationRequired)
                return 5.0;
            else if (containerQuantity > 5 && (quarantineRequired || fumigationRequired))
                return 2.5;
            else
                return 0;
        }

        public void ApplyDiscount(double discount, int requestID)
        {
            var quotation = quotations.FirstOrDefault(q => q.QuotationNumber == requestID);
            if (quotation != null && discount > 0)
            {
                decimal discountFactor = 1 - ((decimal)discount / 100);
                quotation.DepotCharges *= discountFactor;
                quotation.LCLCharges *= discountFactor;
            }
        }

        public void AcceptQuotationRequest(int requestID)
        {
            var request = quotationRequests.FirstOrDefault(r => r.RequestID == requestID);
            var quotation = quotations.FirstOrDefault(q => q.QuotationNumber == requestID);
            if (request != null && quotation != null)
            {
                request.Status = "Accepted";
                quotation.Status = "Accepted";
            }
        }

        public void RejectQuotationRequest(int requestID, string message)
        {
            var request = quotationRequests.FirstOrDefault(r => r.RequestID == requestID);
            var quotation = quotations.FirstOrDefault(q => q.QuotationNumber == requestID);
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

        public void GenerateSampleQuotations()
        {
            quotations.AddRange(new List<Quotation>
            {
                new Quotation(
                    1,
                    "John Doe",
                    "john.doe@example.com",
                    DateTime.Now.AddDays(-10),
                    "Pending",
                    "20ft",
                    "Export - Standard",
                    300m,
                    150m,
                    "Awaiting approval from customer"
                ),
                new Quotation(
                    2,
                    "Jane Smith",
                    "jane.smith@example.com",
                    DateTime.Now.AddDays(-8),
                    "Accepted",
                    "40ft",
                    "Import - Fragile",
                    500m,
                    200m,
                    "Quotation accepted by customer"
                ),
                new Quotation(
                    3,
                    "Alice Brown",
                    "alice.brown@example.com",
                    DateTime.Now.AddDays(-6),
                    "Rejected",
                    "40ft",
                    "Export - Hazardous Materials",
                    600m,
                    250m,
                    "Quotation rejected due to high cost"
                ),
                new Quotation(
                    4,
                    "Bob White",
                    "bob.white@example.com",
                    DateTime.Now.AddDays(-4),
                    "Pending",
                    "20ft",
                    "Import - Standard",
                    300m,
                    150m,
                    "Quotation awaiting review"
                ),
                new Quotation(
                    5,
                    "Carol Black",
                    "carol.black@example.com",
                    DateTime.Now.AddDays(-2),
                    "Accepted",
                    "40ft",
                    "Export - Oversized Items",
                    700m,
                    300m,
                    "Quotation accepted by customer"
                )
            });
        }
    }
}
