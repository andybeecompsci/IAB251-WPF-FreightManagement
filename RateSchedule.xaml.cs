using IAB251_ASS2.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace IAB251_WPF_ASS2
{
    public partial class RateSchedule : Page
    {
        public static List<Rate> Rates { get; private set; }
        private QuotationManager _quotationManager;
        private EmployeeManager _employeeManager;

        public RateSchedule(QuotationManager quotationManager, EmployeeManager employeeManager)
        {
            InitializeComponent();
            _quotationManager = quotationManager;
            _employeeManager = employeeManager;
            LoadRateSchedule();
        }

        private void LoadRateSchedule()
        {
            Rates = new List<Rate>
            {
                new Rate { Type = "Walf Booking Fee", TwentyFtFee = "$60", FortyFtFee = "$70" },
                new Rate { Type = "Lift on/Lift Off", TwentyFtFee = "$80", FortyFtFee = "$120" },
                new Rate { Type = "Fumigation", TwentyFtFee = "$220", FortyFtFee = "$280" },
                new Rate { Type = "LCL Delivery Depot", TwentyFtFee = "$400", FortyFtFee = "$500" },
                new Rate { Type = "Tailgate Inspection", TwentyFtFee = "$120", FortyFtFee = "$160" },
                new Rate { Type = "Storage Fee", TwentyFtFee = "$240", FortyFtFee = "$300" },
                new Rate { Type = "Facility Fee", TwentyFtFee = "$70", FortyFtFee = "$100" },
                new Rate { Type = "Walf Inspection", TwentyFtFee = "$60", FortyFtFee = "$90" },
                new Rate { Type = "GST", TwentyFtFee = "10%", FortyFtFee = "10%" }
            };

            RateScheduleExtractData.ItemsSource = Rates;
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }

    public class Rate
    {
        public string Type { get; set; }
        public string TwentyFtFee { get; set; }
        public string FortyFtFee { get; set; }
    }
}
