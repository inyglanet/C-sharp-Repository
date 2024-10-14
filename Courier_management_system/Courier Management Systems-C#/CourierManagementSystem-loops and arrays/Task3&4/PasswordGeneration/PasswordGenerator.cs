using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierPasswordGeneration
{
    internal class PasswordGenerator
    {
        private const int PasswordLength = 10;
        private static readonly Random Random = new Random();
        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string NumberChars = "0123456789";
        private const string SpecialChars = "!@#$%&*_-.";

        private char GetRandomChar()
        {
            string mixedup = UppercaseChars + LowercaseChars + NumberChars + SpecialChars;
            return mixedup[Random.Next(mixedup.Length)];
        }

        public string GeneratePassword()
        {
            var passwordChars = new char[PasswordLength];
            passwordChars[0] = UppercaseChars[Random.Next(UppercaseChars.Length)];
            passwordChars[1] = LowercaseChars[Random.Next(LowercaseChars.Length)];
            passwordChars[2] = NumberChars[Random.Next(NumberChars.Length)];
            passwordChars[3] = SpecialChars[Random.Next(SpecialChars.Length)];

            for (int i = 4; i < PasswordLength; i++)
            {
                passwordChars[i] = GetRandomChar();
            }

            return new string(passwordChars);
        }
    }
}
