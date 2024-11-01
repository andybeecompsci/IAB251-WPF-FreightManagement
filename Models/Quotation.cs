using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_ASS2.Models
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
        public decimal Charges { get; set; }
        public decimal DepotCharges { get; set; }
        public decimal LCLCharges { get; set; } 
        




        public Quotation (int quotationnumber, string clientname, string clientemail, DateTime dateissue, string status, string containertype, string scope, decimal charges, decimal depotcharges, decimal lclcharges)
        {
            QuotationNumber = quotationnumber;
            ClientName = clientname;
            ClientEmail = clientemail;
            DateIssue = dateissue;
            Status = status;
            ContainerType = containertype;
            Scope = scope;
            Charges = charges;
            DepotCharges = depotcharges;
            LCLCharges = lclcharges;
        }



    }
}
