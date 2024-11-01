using IAB251_ASS2.Models;
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
        private static CustomerManager _customerManager = new CustomerManager();

        public static CustomerManager CustomerManager => _customerManager;

    }
}
