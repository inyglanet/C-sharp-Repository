using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOrderStatus
{
    internal class CheckStatus
    {
        static void Main(string[] args)
        {
            
            string Status= Console.ReadLine();
            if (Status =="Processing")
            {
                Console.WriteLine("Your order is in process");
            }
            else if(Status == "Delivered")
            {
                Console.WriteLine("Your order has been delivered");
            }
            else if(Status == "Cancelled")
            {
                Console.WriteLine("Your order has been cancelled");
            }
            else
            {
                Console.WriteLine("No information about this order");
            }
            Console.ReadKey();
        }
    }
}
