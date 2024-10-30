using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace IAB251_ASS2.Models
{
    public class QuotationRequest
    {
        //i2
        //[Required(ErrorMessage = "required")]
        
        public int RequestID { get; set; } //LOWKEY NEEDS TO BE GENERATED, NO FORM NEEDED
        [Required(ErrorMessage = "required")]
        public Customer CustomerInfo { get; set; } // LINK THIS W LOG IN DATA FOR FIRST AND LAST NAME
        [Required(ErrorMessage = "required")]
        public string Source { get; set; }
        [Required(ErrorMessage = "required")]
        public string Destination { get; set; }
        [Required(ErrorMessage = "required")]
        public int ContainerQuantity { get; set; }
        [Required(ErrorMessage = "required")]
        public string NaturePackage { get; set; } // ??????????????????????
        [Required(ErrorMessage = "required")]
        public List<string> NatureJob { get; set; } = new List<string>(); //holding import/export, packing/unpacking, quarantine info NEED TO BE DONE

        public QuotationRequest() { } //paramaterless constructor to avoid errorrs

        //request contents
        public QuotationRequest(int requestID, Customer customerInfo, string source, string destination, int containerQuantity, List<string> natureJob)
        {
            RequestID = requestID;
            CustomerInfo = customerInfo;
            Source = source;
            Destination = destination;
            ContainerQuantity = containerQuantity;
            NatureJob = natureJob;
        }

    }
}
