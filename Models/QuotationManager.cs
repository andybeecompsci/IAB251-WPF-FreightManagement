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
        private List<Quotation> quotations = new List<Quotation>();
        
        //make list of pending quotations 
        public List<Quotation> GetPendingRequests()
        {
            return quotations.Where(r => r.Status == "Pending").ToList();
        }


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
        public void AcceptQuotationRequest(int requestNumber)
        {
            var request = quotations.FirstOrDefault(r => r.QuotationNumber == requestNumber);
            if (request != null)
            {
                request.Status = "Accepted";
            }
        }

        // rejects quotation and updates status to Rejected
        public void RejectQuotationRequest(int requestNumber, string message)
        {
            var request = quotations.FirstOrDefault(r => r.QuotationNumber == requestNumber);
            if (request != null)
            {
                request.Status = "Rejected";
                
                // add something to send message to customer when they login next
                //message;
            }
        }
    }
}
