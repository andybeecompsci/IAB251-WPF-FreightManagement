
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_ASS2.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // Email will be used as the username
        public string PhoneNumber { get; set; }
        public string EmployeeType { get; set; } // Admin, Quotation Officer, Booking Officer, Warehouse Officer, Manager, or CIO
        public string Address { get; set; }
        public string Password { get; set; }


        public Employee() { }

        public Employee(string firstname, string lastname, string email, string phonenumber, string employeetype, string address, string password)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            PhoneNumber = phonenumber;
            EmployeeType = employeetype;
            Address = address;
            Password = password;

        }

        //public static string Password(string password)
        //{

        //}

        //public void PrintDetails()
        //{
        //    Console.WriteLine($"Driver Details");
        //    Console.WriteLine($"Employee Name:{FirstName}{LastName}");
        //    Console.WriteLine($"Email: {Email}");
        //    Console.WriteLine($"Phone Number: {PhoneNumber}");
        //    Console.WriteLine($"Employee Type: {EmployeeType}");
        //    Console.WriteLine($"Address: {Address}");

        //}
    }
}
