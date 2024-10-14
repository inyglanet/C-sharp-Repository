using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CourierManagementSystem.Entities;
using CourierManagementSystem.BuisnessLayer.Repository;
using CourierManagementSystem.BuisnessLayer.Services;
using CourierManagementSystem.Exceptions;
using CouriermanagementSystem.Util;

namespace CourierServiceApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICourierUserService courierUserService = new CourierUserService();
            ICourierAdminService courierAdminService = new CourierAdminService();
            CourierService courierService = new CourierService();

            try
            {
                // Admin adds a new courier staff member
                Employees newEmployee = new Employees
                {
                    EmployeeName = "Tanmay Chocksey",
                    Email = "tanmay@example.com",
                    ContactNumber = 1234567890,
                    Role = "Courier",
                    Salary = 5000
                };
                int employeeId = courierAdminService.AddCourierStaff(newEmployee);
                courierService.InsertEmployee(newEmployee); 
                Console.WriteLine($"Added new courier staff with ID: {employeeId}");

                // User places a new order
                Courier courier = new Courier
                {
                    CourierID = 101,
                    SenderName = "Iny",
                    SenderAddress = "123, Dhaniya Street",
                    ReceiverName = "Stanio",
                    ReceiverAddress = "456, Gobi Avenue",
                    Weight = 7,
                    Status = "In Transit",
                    DeliveryDate = DateTime.Now.AddDays(2),
                    UserID = employeeId
                };

                string trackingNumber = courierUserService.PlaceOrder(courier);
                Console.WriteLine($"Order placed. Tracking number: {trackingNumber}");

                // Check order status
                string status = courierUserService.GetOrderStatus(trackingNumber);
                Console.WriteLine($"Order status: {status}");

                // Cancel the order
                bool cancelResult = courierUserService.CancelOrder(trackingNumber);
                Console.WriteLine($"Order canceled: {cancelResult}");
            }
            catch (TrackingNumberNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidEmployeeIdException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("End of transaction.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
