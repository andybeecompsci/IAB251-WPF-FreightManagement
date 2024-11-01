using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.ComponentModel.DataAnnotations;

namespace IAB251_ASS2.Models
{
    public class QuotationRequest
    {
        //i2
        ////[Required(ErrorMessage = "required")]
        
        //public int RequestID { get; set; } //LOWKEY NEEDS TO BE GENERATED, NO FORM NEEDED
        //[Required(ErrorMessage = "required")]
        //public Customer CustomerInfo { get; set; } // LINK THIS W LOG IN DATA FOR FIRST AND LAST NAME
        //[Required(ErrorMessage = "required")]
        //public string Source { get; set; }
        //[Required(ErrorMessage = "required")]
        //public string Destination { get; set; }
        //[Required(ErrorMessage = "required")]
        //public int ContainerQuantity { get; set; }
        //[Required(ErrorMessage = "required")]
        //public string NaturePackage { get; set; } // ??????????????????????
        //[Required(ErrorMessage = "required")]
        //public List<string> NatureJob { get; set; } = new List<string>(); //holding import/export, packing/unpacking, quarantine info NEED TO BE DONE

        // COMMENTED OUT ABOVE TO MAKE IT MORE COMPATIBLE - TALK TO SULLY ABOUT CHANGES
        
        //quotation request

        //info
        public int RequestID { get; set; } 
        public Customer CustomerInfo { get; set; } 
        public string Source { get; set; }
        public string Destination { get; set; }
        public int ContainerQuantity { get; set; }

        //Nature of Package
        public string GoodsType {  get; set; }
        public string Width { get; set; }
        public string Height { get; set; }

        // Nature of Job
        // split into Import/Export, Packing/Unpacking, Quarantine Details, Fumigation Details
        public string PortType { get; set; }
        public string PackingType { get; set; }
        public string QuarantineDetails { get; set; }
        public string FumigationDetails { get; set; }

        //status
        public string Status { get; set; } = "Pending";


        //message
        public string Message { get; set; } = string.Empty;


        public QuotationRequest() { } //paramaterless constructor to avoid errorrs

        //request contents
        public QuotationRequest(int requestID, Customer customerInfo, string source, string destination, int containerQuantity,
                                string goodsType, string width, string height, string portType, string packingType, string quarantineDetails,
                                string fumigationDetails, string status)
        {
            RequestID = requestID;
            CustomerInfo = customerInfo;
            Source = source;
            Destination = destination;
            ContainerQuantity = containerQuantity;

            //nature of package
            GoodsType = goodsType;
            Width = width;
            Height = height;

            //nature of job
            PortType = portType;
            PackingType = packingType;
            QuarantineDetails = quarantineDetails;
            FumigationDetails = fumigationDetails;

            //status
            Status = status;
        }

        // set status of customer quotation and any rejection message
        public void UpdateStatus(string newStatus, string message = "")
        {
            Status = newStatus;
            if (newStatus == "Rejected")
            {
                Message = message;
            }
        }


        // display formatted NatureJob as a single string 
        public string NatureJobDescription => string.Join(", ", NatureJob);
    }
}
