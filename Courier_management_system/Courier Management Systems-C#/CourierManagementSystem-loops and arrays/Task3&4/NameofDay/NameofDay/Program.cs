using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameofDayUsingSwitchCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of the day you want to display");
            int day_of_week=Convert.ToInt32(Console.ReadLine());
            switch(day_of_week){
                case 1:day_of_week = 1;
                    Console.WriteLine("Monday");
                    break;
                case 2:day_of_week = 2;
                    Console.WriteLine("Tuesday");
                    break;
                case 3:day_of_week = 3;
                    Console.WriteLine("Wednesday");
                    break;
                case 4:day_of_week = 4;
                    Console.WriteLine("Thursday");
                    break;
                case 5:day_of_week = 5;
                    Console.WriteLine("Friday");
                    break;
                case 6:day_of_week = 6;
                    Console.WriteLine("Saturday");
                    break;
                case 7:day_of_week = 7;
                    Console.WriteLine("Sunday");
                    break;

            }
        }

    }
}
