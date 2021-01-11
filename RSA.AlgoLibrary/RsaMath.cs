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
        /// Calculate modulus for the keys
        /// </summary>
        /// <remarks>Function: n = p * q</remarks>
        /// <param name="p">First random prime number</param>
        /// <param name="q">Second random prime number</param>
        /// <returns>Calculated modulus for the private and public keys</returns>
        public static int CalculateModulusForKeys(int p, int q)
        {
            var n = p * q;
            return n;
        }

        /// <summary>
        /// Calculate Euler's totient
        /// </summary>
        /// <remarks>Function: f(n) = (p - 1) * (q - 1)</remarks>
        /// <param name="p">First random prime number</param>
        /// <param name="q">Second random prime number</param>
        /// <returns>Euler's totient function value</returns>
        public static int CalculateEulersTotientFunction(int p, int q)
        {
            int totient = (p - 1) * (q - 1);
            return totient;
        }

        /// <summary>
        /// Choose a public key exponent
        /// </summary>
        /// <remarks>Conditions: (1) E is greater than 1 and less then f(n); (2) E is co-prime to f(n)</remarks>
        /// <param name="totient">Euler's totient function value</param>
        /// <returns>Public key exponent</returns>
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

        /// <summary>
        /// Calculate private key exponent to satisfy the congruence relation:
        /// </summary>
        /// <remarks>(d * e) % f(n) = 1</remarks>
        /// <param name="e">Public key exponent</param>
        /// <param name="totient">Euler's totient function value</param>
        /// <returns>Private key exponent</returns>
        public static int CalculatePrivateKeyExponent(int e, int totient)
        {
            int d = 1;

            while ((d * e) % totient != 1)
            {
                d++;
            }

            return d;
        }

        /// <summary>
        /// Encrypt <c>int</c> message by public key
        /// </summary>
        /// <remarks>Encrypt: m^e % n</remarks>
        /// <param name="inputMessage">M - <c>int</c> message</param>
        /// <param name="publicKeyExponent">Public key exponent (E)</param>
        /// <param name="publicKeyModulus">Public key modulus</param>
        /// <returns>Encrypted <c>int</c> message</returns>
        public static int EncryptMessage(int inputMessage, int publicKeyExponent, int publicKeyModulus)
        {
            int encryptedMessage = CalculateEncryptDecryptMessage(inputMessage, publicKeyExponent, publicKeyModulus);
            return encryptedMessage;
        }

        /// <summary>
        /// Decrypt <c>int</c> message by private key
        /// </summary>
        /// <remarks>Decrypt: c^d % n</remarks>
        /// <param name="inputMessage">C - encrypted <c>int</c> message</param>
        /// <param name="privateKeyExponent">Private key exponent (E)</param>
        /// <param name="privateKeyModulus">Private key modulus</param>
        /// <returns>Decrypted <c>int</c> message</returns>
        public static int DecryptMessage(int inputMessage, int privateKeyExponent, int privateKeyModulus)
        {
            int decryptedMessage = CalculateEncryptDecryptMessage(inputMessage, privateKeyExponent, privateKeyModulus);
            return decryptedMessage;
        }

        private static int CalculateEncryptDecryptMessage(int inputMessage, int keyExponent, int modulus)
        {
            // More memory-intensive way

            // BigInteger pow = BigInteger.Pow(inputMessage, keyExponent);
            // int outputMessage = (int)(pow % modulus);

            int outputMessage = 1;

            for (int i = 0; i < keyExponent; i++)
            {
                outputMessage *= inputMessage;
                outputMessage %= modulus;
            }

            return outputMessage;
        }
    }
}
