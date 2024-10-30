// RateSchedule.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class RateSchedule
{
    public string ContainerType { get; set; }
    public decimal BasicRate { get; set; }
    public decimal DepotCharges { get; set; }
    public decimal LCLDeliveryCharges { get; set; }

    // Static method to simulate retrieving rate data from memory
    public static List<RateSchedule> GetRates()
    {
        return new List<RateSchedule>
        {
            new RateSchedule { ContainerType = "Standard 20ft", BasicRate = 1000, DepotCharges = 150, LCLDeliveryCharges = 300 },
            new RateSchedule { ContainerType = "Standard 40ft", BasicRate = 1500, DepotCharges = 200, LCLDeliveryCharges = 350 },
            new RateSchedule { ContainerType = "Refrigerated 20ft", BasicRate = 2000, DepotCharges = 300, LCLDeliveryCharges = 450 },
            new RateSchedule { ContainerType = "Refrigerated 40ft", BasicRate = 2500, DepotCharges = 350, LCLDeliveryCharges = 500 }
        };
    }
}
