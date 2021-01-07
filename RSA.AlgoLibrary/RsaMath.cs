using System;
using System.Collections.Generic;
using System.Text;

namespace RSA.AlgoLibrary
{
    public static class RsaMath
    {   
        public static int GeneratePrimeNumber(int maxPrimeNumber)
        {
            var random = new Random();
            int number;

            do
            {
                number = random.Next(2, maxPrimeNumber);
            } while (!IsPrimeNumber(number));

            return number;
        }

        private static bool IsPrimeNumber(int number)
        {
            var result = true;

            for (var i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                }
            }

            return result;
        }

        public static int CalculateEulersTotientFunction(int p, int q)
        {
            var totient = (p - 1) * (q - 1);
            return totient;
        }
    }
}
