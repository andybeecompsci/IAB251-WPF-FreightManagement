using IAB251_WPF_ASS2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IAB251_WPF_ASS2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        // In MainWindow or App.xaml.cs
        //private static CustomerManager _customerManager = new CustomerManager();
        private static CustomerManager _customerManager = CustomerManager.Instance; 

        //public static CustomerManager CustomerManager => _customerManager;
        public static CustomerManager CustomerManager => _customerManager; 


        //single instantiation of quotation manager
        private static QuotationManager _quotationManager = new QuotationManager();
        public static QuotationManager QuotationManager => _quotationManager;

        //single instantiation of employee manager
        private static EmployeeManager _employeeManager = new EmployeeManager();
        public static EmployeeManager EmployeeManager => _employeeManager;



    }
}
