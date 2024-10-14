using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Entities
{
    public class Employees
    {


        public int EmployeeID {  get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public long ContactNumber { get; set; }
        public string Role { get;set; }
        public double Salary { get;set; }

    }
}
