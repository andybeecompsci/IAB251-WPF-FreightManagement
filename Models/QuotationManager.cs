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



        // store quotations in a list
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
    }
}
