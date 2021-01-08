using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace RSA.AlgoLibrary
{
    public static class RsaMath
    {   
        public static uint GeneratePrimeNumber(int maxPrimeNumber)
        {
            Random random = new Random();
            uint number;

            do
            {
                number = (uint) random.Next(2, maxPrimeNumber);
            } while (!IsPrimeNumber(number));

            return number;
        }

        private static bool IsPrimeNumber(uint number)
        {
            bool result = true;

            for (uint i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                }
            }

            return result;
        }

        public static uint CalculateEulersTotientFunction(uint p, uint q)
        {
            uint totient = (p - 1) * (q - 1);
            return totient;
        }

        public static uint ChoosePublicKeyExponent(uint totient)
        {
            List<uint> possiblePublicKeyExponentList = GetAllPossiblePublicKeyExponentList(totient);
            uint e = GetRandomPossiblePublicKeyExponent(possiblePublicKeyExponentList);

            return e;
        }

        private static List<uint> GetAllPossiblePublicKeyExponentList(uint totient)
        {
            List<uint> divisorsOfTotientList = GetAllDivisorsList(totient);
            List<uint> possiblePublicKeyExponentList = new List<uint>();

            for (uint i = 2; i < totient; i++)
            {
                if (IsPrimeNumber(i) && !divisorsOfTotientList.Contains(i))
                {
                    possiblePublicKeyExponentList.Add(i);
                }
            }

            return possiblePublicKeyExponentList;
        }

        private static List<uint> GetAllDivisorsList(uint number)
        {
            List<uint> divisorsList = new List<uint>();

            for (uint i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    divisorsList.Add(i);
                }
            }

            return divisorsList;
        }

        private static uint GetRandomPossiblePublicKeyExponent(List<uint> possiblePublicKeyExponentList)
        {
            Random random = new Random();

            int randomPossibleNumberIndex = random.Next(0, possiblePublicKeyExponentList.Count - 1);
            uint e = possiblePublicKeyExponentList[randomPossibleNumberIndex];

            return e;
        }

        public static uint CalculatePrivateKeyExponent(uint e, uint totient)
        {
            uint d = 1;

            while ((d * e) % totient != 1)
            {
                d++;
            }

            return d;
        }

        public static ulong CalculateEncryptDecryptMessage(ulong inputMessage, uint keyExponent, uint modulus)
        {
            BigInteger pow = 1;
            for (int i = 0; i < keyExponent; i++)
            {
                pow *= inputMessage;
            }
            ulong decrypt = (ulong)(pow % modulus);

            return decrypt;
        }
    }
}
