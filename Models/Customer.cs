//using System.ComponentModel.DataAnnotations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_ASS2.Models
{
    public class Customer
    {
        //customer attributes
        

        //[Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Email Address is required")]
        public string EmailAddress { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        public string Password {  get; set; }

        //[Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public string Company { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with customer login attributes.
        /// </summary>
        /// <param name="firstName">customer first name.</param>
        /// <param name="lastName">customer family name .</param>
        /// <param name="emailAddress">customer email address.</param>
        /// <param name="password">customer password.</param>
        /// <param name="phoneNumber">customer phone number.</param>
        /// <param name="address">customer street address.</param>
        /// <param name="company">customer company (optional).</param>

        //empty instantiation
        public Customer() { }

        public Customer(string firstName, string lastName, String emailAddress, String password, String phoneNumber, String address, String company )
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Password = password;
            PhoneNumber = phoneNumber;
            Address = address;
            Company = company;
            

        }

        

    }
}
