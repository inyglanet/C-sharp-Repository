using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderConfirmationMail
{
    internal class OrderMail
    {
        static void Main(string[] args)
        {
            OrderConfirmation order = new OrderConfirmation();
            string CustomerName = order.CustomerName;
            string OrderNumber = order.OrderNumber;
            string DeliveryAddress = order.DeliveryAddress;
            DateTime ExpectedDeliveryDate = order.ExpectedDeliveryDate;
            order.GenerateEmail();
            Console.ReadKey();
        }
    }
}
