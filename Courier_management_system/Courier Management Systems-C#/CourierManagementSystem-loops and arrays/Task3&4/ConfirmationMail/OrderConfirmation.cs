using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderConfirmationMail
{
    internal class OrderConfirmation
    {
        public string CustomerName { get; set; }
        public string OrderNumber { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }

        public void GenerateEmail()
        {
            Console.WriteLine("Enter customer name");
            CustomerName = Console.ReadLine();
            Console.WriteLine("Enter order number");
            OrderNumber= Console.ReadLine();
            Console.WriteLine("Enter the address");
            DeliveryAddress = Console.ReadLine();
            Console.WriteLine("Enter expected delivery date");
            ExpectedDeliveryDate= Convert.ToDateTime(Console.ReadLine());

            string emailBody = $"Dear {CustomerName},\n\n" + $"Thank you for your order! Here are your order details:\n" +
                               $"Order Number: {OrderNumber}\n" +$"Delivery Address: {DeliveryAddress}\n" +
                               $"Expected Delivery Date: {ExpectedDeliveryDate.ToShortDateString()}\n\n" +
                               $"Best regards";

            Console.WriteLine(emailBody);
        }
    }
}
