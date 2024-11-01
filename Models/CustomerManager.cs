using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_ASS2.Models
{

        public class CustomerManager : INotifyPropertyChanged
        {
            // Event to notify UI of property changes
            public event PropertyChangedEventHandler PropertyChanged;

        private bool _isLoggedIn;
        private string _currentUserEmail;

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            private set
            {
                if (_isLoggedIn != value)
                {
                    _isLoggedIn = value;
                    OnPropertyChanged(nameof(IsLoggedIn));
                }
            }
        }

        // Stores the email of the currently logged-in user
        public string CurrentUserEmail
        {
            get => _currentUserEmail;
            private set
            {
                if (_currentUserEmail != value)
                {
                    _currentUserEmail = value;
                    OnPropertyChanged(nameof(CurrentUserEmail));
                }
            }
        }

        public void SetLoggedInStatus(bool status)
            {
                IsLoggedIn = status;
            }



            // List of customers
            private List<Customer> Customers { get; set; } = new List<Customer>();

            // Add new customer
            public void AddCustomer(Customer customer)
            {
                Customers.Add(customer);
            }

            // Retrieve customer via email
            public Customer GetCustomerByEmail(string email)
            {
                return Customers.FirstOrDefault(c => c.EmailAddress.Equals(email, StringComparison.OrdinalIgnoreCase));
            }

            // Validate login
            public bool ValidateLogin(string email, string password)
            {
                var customer = GetCustomerByEmail(email);
                bool isValid = customer != null && customer.Password == password;
                if (isValid)
                {
                    SetLoggedInStatus(true);
                }
                return isValid;
            }

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


