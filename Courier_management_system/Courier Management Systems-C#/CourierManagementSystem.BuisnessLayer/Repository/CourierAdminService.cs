using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;
using CourierManagementSystem.Exceptions;
using CourierManagementSystem.BuisnessLayer.Services;

namespace CourierManagementSystem.BuisnessLayer.Repository
{
    public class CourierAdminService : ICourierAdminService
    {
        private readonly List<Employees> employees = new List<Employees>();
        private static int employeeCounter = 1;

        public int AddCourierStaff(Employees employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Email))
            {
                throw new InvalidEmployeeIdException("Employee ID cannot be null or empty.");
            }
            employee.EmployeeID = employeeCounter++;
            employees.Add(employee);
            return employee.EmployeeID;
        }
    }
}    
