using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_WPF_ASS2.Models
{
    public class Quotation
    {
        public int QuotationNumber { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public DateTime DateIssue { get; set; }
        public string Status { get; set; } // must be Accept, Reject or Pending
        public string ContainerType { get; set; }
        public string Scope { get; set; }
        //public decimal Charges { get; set; }
        public decimal DepotCharges { get; set; } = 0m;
        public decimal LCLCharges { get; set; } = 0m;
        public string Message { get; set; }
        //public decimal DiscountedCharges { get; set; }

        




        public Quotation (int quotationnumber, string clientname, string clientemail, 
            DateTime dateissue, string status, string containertype, string scope, decimal depotcharges, decimal lclcharges, string message)
        {
            QuotationNumber = quotationnumber;
            ClientName = clientname;
            ClientEmail = clientemail;
            DateIssue = dateissue;
            Status = status;
            ContainerType = containertype;
            Scope = scope;
            //Charges = charges;
            DepotCharges = depotcharges;
            LCLCharges = lclcharges;
            Message = message;
            //DiscountedCharges = discountedcharges;
        }

    }
}
