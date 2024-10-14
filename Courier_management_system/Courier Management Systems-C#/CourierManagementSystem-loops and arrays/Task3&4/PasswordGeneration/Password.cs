using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierPasswordGeneration
{
    internal class Password
    {
        
        public static void Main(string[] args)
        {
            PasswordGenerator generator = new PasswordGenerator();
            string password = generator.GeneratePassword();
            Console.WriteLine($"Generated Password: {password}");
            Console.ReadKey();
        }
    }
}

