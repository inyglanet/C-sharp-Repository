using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingSimilarAddress
{
    internal class SimilarAddress
    {
        static void Main(string[] args)

        {
            string[] addresses = { "123 Main St", "123 Main Street", "456 Elm St", "123 Main St.", "789 Oak Ave" };
            string targetAddress = "123 Main St";

            Console.WriteLine("Similar addresses to: " + targetAddress);
            FindSimilarAddresses(addresses, targetAddress);
            Console.ReadLine();
        }

        public static void FindSimilarAddresses(string[] addresses, string targetAddress)
        {
            foreach (string address in addresses)
            {
                if (AreAddressesSimilar(address, targetAddress))
                {
                    Console.WriteLine(address);
                }
            }
        }

        public static bool AreAddressesSimilar(string address1, string address2)
        {
            return address1.Replace("St", "Street").Replace(".", "").Trim().Equals(address2.Replace("St", "Street").Replace(".", "").Trim(), StringComparison.OrdinalIgnoreCase);
        }
        
    }
}
