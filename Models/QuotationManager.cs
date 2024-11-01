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
        public void AddQuotationRequest( QuotationRequest qRequest) //needs to be fleshed out 
        {
            quotationRequests.Add(qRequest);
        }

        //retrive quotation request by ID
        public QuotationRequest GetQuotationRequest( int id )
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
            return quotations;
        }

        // add quotation
        public void AddQuotation(Quotation quotation)
        {
            quotations.Add(quotation);
        }

        public Quotation RequestToQuotation (QuotationRequest request)
        {

            int quotationnumber = request.RequestID;
            string clientname = $"{request.CustomerInfo.FirstName} {request.CustomerInfo.LastName}";
            string clientemail = $"{request.CustomerInfo.EmailAddress}";
            DateTime dateissue = DateTime.Now;
            string status = request.Status;
            string containertype = request.Width;
            //> 5 ? "40" : "20"; // Assuming larger container for higher quantity
            string scope = $"{request.GoodsType}{request.PortType}, {request.PackingType}, {request.QuarantineDetails}, {request.FumigationDetails}";

            //decimal baseCharge = containertype == "40" ? 2000m : 1000m;
            decimal charges =  0;//baseCharge * request.ContainerQuantity;
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
                charges,
                depotcharges,
                lclcharges
            );

            // Add quotation to list
            AddQuotation(quotation);
            return quotation;
        }

        // retreive quotation by number
        public Quotation QuotationByNumber(int quotationNumber)
        {
            return quotations.FirstOrDefault(q => q.QuotationNumber == quotationNumber);
        }

        // accepts quotation and updates status to Accepted
        public void AcceptQuotationRequest(int requestID)
        {
            var request = quotationRequests.FirstOrDefault(r => r.RequestID == requestID);
            if (request != null)
            {
                request.Status = "Accepted";
            }
        }

        // rejects quotation and updates status to Rejected
        public void RejectQuotationRequest(int requestID, string message)
        {
            var request = quotationRequests.FirstOrDefault(r => r.RequestID == requestID);
            if (request != null)
            {
                request.Status = "Rejected";
                
                // add something to send message to customer when they login next
                //message;
            }
        }
    }
}
