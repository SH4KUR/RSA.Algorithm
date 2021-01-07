using System;
using System.Collections.Generic;
using System.Linq;
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

        public static int ChoosePublicKeyExponent(int totient)
        {
            var possiblePublicKeyExponentList = GetAllPossiblePublicKeyExponentList(totient);
            var e = GetRandomPossiblePublicKeyExponent(possiblePublicKeyExponentList);

            return e;
        }

        private static List<int> GetAllPossiblePublicKeyExponentList(int totient)
        {
            var divisorsOfTotientList = GetAllDivisorsList(totient);
            var possiblePublicKeyExponentList = new List<int>();

            for (var i = 2; i < totient; i++)
            {
                if (IsPrimeNumber(i) && !divisorsOfTotientList.Contains(i))
                {
                    possiblePublicKeyExponentList.Add(i);
                }
            }

            return possiblePublicKeyExponentList;
        }

        private static List<int> GetAllDivisorsList(int number)
        {
            var divisorsList = new List<int>();

            for (var i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    divisorsList.Add(i);
                }
            }

            return divisorsList;
        }

        private static int GetRandomPossiblePublicKeyExponent(List<int> possiblePublicKeyExponentList)
        {
            var random = new Random();

            var randomPossibleNumberIndex = random.Next(0, possiblePublicKeyExponentList.Count - 1);
            var e = possiblePublicKeyExponentList[randomPossibleNumberIndex];

            return e;
        }
    }
}
