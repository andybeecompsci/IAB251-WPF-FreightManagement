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
        public void AddQuotationRequest(QuotationRequest qRequest) //needs to be fleshed out 
        {
            quotationRequests.Add(qRequest);
        }

        //retrive quotation request by ID
        public QuotationRequest GetQuotationRequest(int id)
        {
            return quotationRequests.FirstOrDefault(r => r.RequestID == id);
        }

        //make quotation request into quotation???



        // ABOVE STUFF NEEDS TO BE COMPATIBLE WITH THE BELOW

        // store quotations in a list

        //make list of pending quotations 
        public List<QuotationRequest> GetPendingRequests()
        {
            return quotationRequests.Where(r => r.Status == "Pending").ToList();
        }

        private List<Quotation> quotations = new List<Quotation>();

        // retreive quotations
        public List<Quotation> GetQuotations()
        {
            GenerateSampleQuotations();
            return quotations;
        }

        // add quotation
        public void AddQuotation(Quotation quotation)
        {
            quotations.Add(quotation);
        }

        public Quotation RequestToQuotation(QuotationRequest request)
        {

            int quotationnumber = request.RequestID;
            string clientname = $"{request.CustomerInfo.FirstName} {request.CustomerInfo.LastName}";
            string clientemail = $"{request.CustomerInfo.EmailAddress}";
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


            Quotation quotation = new Quotation(
                quotationnumber,
                clientname,
                clientemail,
                dateissue,
                status,
                containertype,
                scope,
                depotcharges,
                lclcharges,
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
            var quotationnumber = quotations.FirstOrDefault(r => r.QuotationNumber == requestID);
            if (request != null)
            {
                request.Status = "Accepted";
                quotationnumber.Status = "Accepted";
            }
        }

        // rejects quotation and updates status to Rejected
        public void RejectQuotationRequest(int requestID, string message)
        {
            var request = quotationRequests.FirstOrDefault(r => r.RequestID == requestID);
            var quotationnumber = quotations.FirstOrDefault(r => r.QuotationNumber == requestID);
            if (request != null)
            {
                request.Status = "Rejected";
                quotationnumber.Status = "Rejected";
                quotationnumber.Message = message;
                // add something to send message to customer when they login next
                //message;

            }
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