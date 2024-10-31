using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IAB251_WPF_ASS2
{
    public partial class RateSchedule : Window
    {
        
        public RateSchedule()
        {
            InitializeComponent();
            LoadRateSchedule();
        }
        
        private void LoadRateSchedule()
        {
           
            var rates = new List<Rate>
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

            RateScheduleExtractData.ItemsSource = rates;
        }

        
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    
    public class Rate
    {
        public string Type { get; set; }
        public string TwentyFtFee { get; set; }
        public string FortyFtFee { get; set; }
    }
}