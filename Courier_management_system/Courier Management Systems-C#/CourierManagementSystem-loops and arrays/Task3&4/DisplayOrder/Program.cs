using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayOrderofCustomers
{
    struct Order
    {
        public int OrderId;
        public string ProductName;
        public decimal Price;
    }
    struct Customer
    {
        public int CustomerId;
        public string CustomerName;
        public List<Order> Orders;

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                CustomerId = 1,
                CustomerName = "John Doe",
                Orders = new List<Order>
                {
                    new Order { OrderId = 101, ProductName = "Laptop", Price = 999.99m },
                    new Order { OrderId = 102, ProductName = "Mouse", Price = 25.50m }
                }
            },
            new Customer
            {
                CustomerId = 2,
                CustomerName = "Jane Smith",
                Orders = new List<Order>
                {
                    new Order { OrderId = 201, ProductName = "Keyboard", Price = 45.00m }
                }
            }
        };

            Console.WriteLine("enter the customer Id");
            int displayCustomerId = Convert.ToInt32(Console.ReadLine()); 

            foreach (var customer in customers)
            {
                if (customer.CustomerId == displayCustomerId)
                {
                    Console.WriteLine($"Orders for {customer.CustomerName}:");
                    for (int i = 0; i < customer.Orders.Count; i++)
                    {
                        Console.WriteLine($"Order ID: {customer.Orders[i].OrderId}, Product: {customer.Orders[i].ProductName}, Price: {customer.Orders[i].Price}");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
