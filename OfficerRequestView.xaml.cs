using IAB251_ASS2.Models;
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
    /// <summary>
    /// Interaction logic for OfficerRequestView.xaml
    /// </summary>
    public partial class OfficerRequestView : Window
    {
        
        private QuotationManager quotationManager;
        public OfficerRequestView()
        {
            InitializeComponent();
            quotationManager = new QuotationManager();


        }
    }
}
