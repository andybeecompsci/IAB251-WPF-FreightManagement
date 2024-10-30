using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAB251_ASS2.Models
{
    public class EmployeeManager
    {
        // validatation
        public bool IsLoggedIn { get; private set; } = false;
        public void SetLoggedInStatus(bool status)
        {
            IsLoggedIn = status;
        }

        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        //public Employee GetEmployeeByEmail(string email)
        //{
        //    return employees.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        //}

        //public bool ValidateLogin(string email, string password)
        //{
        //    var employee = GetEmployeeByEmail(email);
        //    bool IsValid = employee != null && employee.Password == password;
        //    if (IsValid)
        //    {
        //        SetLoggedInStatus(true);
        //    }
        //    return IsValid;


        //}
    }
}
