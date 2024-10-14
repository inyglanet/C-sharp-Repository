using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizingOrders_task1
{
    internal class OrderCategorizing
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the wright of the parcel");
            int weight = Convert.ToInt32(Console.ReadLine());
            switch (weight)
            {
                case 1:if(weight < 10);
                    Console.WriteLine("Light");
                    break;
                case 2: if(weight < 60 && weight >10);
                    Console.WriteLine("Medium");
                    break;
                case 3: if(weight > 60 );
                    Console.WriteLine("Heavy");
                    break;
            }
            Console.ReadKey();
        }
    }
}
