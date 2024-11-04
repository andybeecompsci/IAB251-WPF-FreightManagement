using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_ASS2.Models
{
    public class EmployeeManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isLoggedIn;
        private bool _isLoggedOut = true;
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
        public bool IsLoggedOut
        {
            get => _isLoggedOut;
            private set
            {
                if (_isLoggedOut != value)
                {
                    _isLoggedOut = value;
                    OnPropertyChanged(nameof(IsLoggedOut));
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
            IsLoggedOut = !status;
        }

        // List of customers
        private List<Employee> Employees { get; set; } = new List<Employee>();

        // Add new customer
        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        // Retrieve customer via email
        public Employee GetEmployeeByEmail(string email)
        {
            return Employees.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        // Validate login
        public bool ValidateLogin(string email, string password)
        {
            var employee = GetEmployeeByEmail(email);
            bool isValid = employee != null && employee.Password == password;
            if (isValid)
            {
                SetLoggedInStatus(true);
                CurrentUserEmail = email; //setcurrentuseremail

                //debug
                Console.WriteLine($"CurrentUserEmail set to: {CurrentUserEmail}");  // Debug: Print CurrentUserEmail

            }
            return isValid;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // OLD STUFF

        //// validatation
        //public bool IsLoggedIn { get; private set; } = false;
        //public void SetLoggedInStatus(bool status)
        //{
        //    IsLoggedIn = status;
        //}

        //private List<Employee> employees = new List<Employee>();

        //public void AddEmployee(Employee employee)
        //{
        //    employees.Add(employee);
        //}


    }
}
