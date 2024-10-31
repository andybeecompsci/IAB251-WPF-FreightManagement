using System;
using System.Collections.Generic;
using System.Linq;
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
