using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagementSystem.Entities;
using CouriermanagementSystem.Util;
using System.Data.SqlClient;

namespace CourierManagementSystem.BuisnessLayer.Repository
{
    public class CourierService
    {
        public void InsertEmployee(Employees employee)
        {
            using (SqlConnection connection = DBConnection.GetDBConnection())
            {
                string query = "INSERT INTO Employees (Name, Email, ContactNumber, Role, Salary) VALUES (@Name, @Email, @ContactNumber, @Role, @Salary)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", employee.EmployeeName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                command.Parameters.AddWithValue("@Role", employee.Role);
                command.Parameters.AddWithValue("@Salary", employee.Salary);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employees employee)
        {
            using (SqlConnection connection = DBConnection.GetDBConnection())
            {
                string query = "UPDATE Employees SET Email = @Email, ContactNumber = @ContactNumber, Role = @Role, Salary = @Salary WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                command.Parameters.AddWithValue("@Role", employee.Role);
                command.Parameters.AddWithValue("@Salary", employee.Salary);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = DBConnection.GetDBConnection())
            {
                string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Employees GetEmployeeById(int employeeId)
        {
            using (SqlConnection connection = DBConnection.GetDBConnection())
            {
                string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", employeeId);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Employees
                        {
                            EmployeeID = (int)reader["EmployeeID"],
                            EmployeeName = (string)reader["Name"],
                            Email = (string)reader["Email"],
                            ContactNumber = (long)reader["ContactNumber"],
                            Role = (string)reader["Role"],
                            Salary = (double)reader["Salary"]
                        };
                    }
                }
            }
            return null; 
        }
    }
}
