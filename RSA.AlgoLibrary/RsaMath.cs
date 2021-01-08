using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace RSA.AlgoLibrary
{
    public static class RsaMath
    {
        /// <summary>
        /// Generate random prime number from minimum to maximum values
        /// </summary>
        /// <param name="minPrimeNumber">Minimum value for generated prime number</param>
        /// <param name="maxPrimeNumber">Maximum value for generated prime number</param>
        /// <returns>Generated prime number</returns>
        public static int GeneratePrimeNumber(int minPrimeNumber, int maxPrimeNumber)
        {
            Random random = new Random();
            int number;

            do
            {
                number = random.Next(minPrimeNumber, maxPrimeNumber);
            } while (!IsPrimeNumber(number));

            return number;
        }

        /// <summary>
        /// Checks if the number is prime
        /// </summary>
        /// <param name="number">Checked value</param>
        /// <returns>Return <c>true</c> if the number is prime</returns>
        private static bool IsPrimeNumber(int number)
        {
            bool result = true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// Calculate modulus for the keys by function: <c>n = p * q</c>
        /// </summary>
        /// <param name="p">First random prime number</param>
        /// <param name="q">Second random prime number</param>
        /// <returns>Calculated modulus for the Private and Public keys</returns>
        public static int CalculateModulusForKeys(int p, int q)
        {
            var n = p * q;
            return n;
        }
        
        /// <summary>
        /// Calculate Euler's totient by function: <c>f(n) = (p - 1) * (q - 1)</c>
        /// </summary>
        /// <param name="p">First random prime number</param>
        /// <param name="q">Second random prime number</param>
        /// <returns>Euler's totient function value</returns>
        public static int CalculateEulersTotientFunction(int p, int q)
        {
            int totient = (p - 1) * (q - 1);
            return totient;
        }

        public static int ChoosePublicKeyExponent(int totient)
        {
            List<int> possiblePublicKeyExponentList = GetAllPossiblePublicKeyExponentList(totient);
            int e = GetRandomPossiblePublicKeyExponent(possiblePublicKeyExponentList);

            return e;
        }

        private static List<int> GetAllPossiblePublicKeyExponentList(int totient)
        {
            List<int> divisorsOfTotientList = GetAllDivisorsList(totient);
            List<int> possiblePublicKeyExponentList = new List<int>();

            for (int i = 2; i < totient; i++)
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
            List<int> divisorsList = new List<int>();

            for (int i = 2; i < number; i++)
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
            Random random = new Random();

            int randomPossibleNumberIndex = random.Next(0, possiblePublicKeyExponentList.Count - 1);
            int e = possiblePublicKeyExponentList[randomPossibleNumberIndex];

            return e;
        }

        public static int CalculatePrivateKeyExponent(int e, int totient)
        {
            int d = 1;

            while ((d * e) % totient != 1)
            {
                d++;
            }

            return d;
        }

        public static int CalculateEncryptDecryptMessage(int inputMessage, int keyExponent, int modulus)
        {
            BigInteger pow = 1;
            for (int i = 0; i < keyExponent; i++)
            {
                pow *= inputMessage;
            }
            int outputMessage = (int)(pow % modulus);

            return outputMessage;
        }
    }
}
