using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateShippingCost
{
    internal class ShippingCost
    {
        public static double CalculateShippingCost(double weight, double distance)
        {
            double costPerKg = 5.0;
            double costPerKm = 0.5; 

            return (weight * costPerKg) + (distance * costPerKm);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the source address:");
            string sourceAddress = Console.ReadLine();

            Console.WriteLine("Enter the destination address:");
            string destinationAddress = Console.ReadLine();

            Console.WriteLine("Enter the weight of the parcel:");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the distance between the two locations:");
            double distance = Convert.ToDouble(Console.ReadLine());

            double shippingCost = CalculateShippingCost(weight, distance);

            Console.WriteLine($"The shipping cost from {sourceAddress} to {destinationAddress} is: {shippingCost}Rupees");
            Console.ReadKey();
        
        }
    }
}
