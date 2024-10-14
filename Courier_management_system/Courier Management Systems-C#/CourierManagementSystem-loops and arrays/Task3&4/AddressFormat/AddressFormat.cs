using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressFormatting_task4
{
    class AddressFormatter
    {
        public string FormatAddress(string street, string city, string state, string zipCode)
        {
            street = CapitalizeWords(street);
            city = CapitalizeWords(city);
            state = state.ToUpper();
            zipCode = FormatZipCode(zipCode);

            return $"{street}, {city}, {state} {zipCode}";
        }

        private string CapitalizeWords(string input)
        {
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }
            return string.Join(" ", words);
        }

        private string FormatZipCode(string zipCode)
        {
            return zipCode.Length == 5 ? zipCode : "Invalid Zip Code";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AddressFormatter formatter = new AddressFormatter();
            string formattedAddress = formatter.FormatAddress("123 main st", "springfield", "il", "62704");
            Console.WriteLine(formattedAddress);
        }
    }
}

