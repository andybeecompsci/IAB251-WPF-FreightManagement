using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_ASS2.Models
{
    public class CustomerManager
    {
        //login validation
        public bool IsLoggedIn { get; private set; } = false;
        public void SetLoggedInStatus(bool status)
        {
            IsLoggedIn = status;
        }



        //list of customers
        private List<Customer> Customers { get; set; } = new List<Customer>();

        //add new customer
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        //retrieve customer via email
        public Customer GetCustomerByEmail(string email)
        {
            return Customers.FirstOrDefault(c => c.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase));

        }

        //validate login 
        public bool ValidateLogin(string email, string password)
        {
            var customer = GetCustomerByEmail(email);
            bool IsValid = customer != null && customer.Password == password;
            if (IsValid)
            {
                SetLoggedInStatus(true);
            }
            return IsValid;
            

        }

    }
}
