using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthentication_task1
{
    internal class Authentication
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Username");
            string userName=Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password=Console.ReadLine();

            string authenticateUsername = "inyglanet";
            string authenticatePassword = "bingo";

            if(authenticateUsername==userName && authenticatePassword == password)
            {
                Console.WriteLine("Login successful ");
            }

            else if(authenticateUsername==userName && authenticatePassword!=password)  
            {
                Console.WriteLine("Incorrect password");
            }
            else 
            {
                Console.WriteLine("Incorrect username");
            }

            Console.ReadKey();


        }
    }
}
