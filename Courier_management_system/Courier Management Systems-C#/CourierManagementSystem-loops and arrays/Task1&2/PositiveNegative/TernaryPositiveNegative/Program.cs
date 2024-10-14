using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TernaryPositiveNegative
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number");
            int number=Convert.ToInt32(Console.ReadLine());
            string decision = (number > 0) ? "Positive number" : "Negative number";
            Console.WriteLine(decision);
            Console.ReadKey();

        }
    }
}
