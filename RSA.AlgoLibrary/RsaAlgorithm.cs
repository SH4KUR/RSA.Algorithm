using System;
using System.Numerics;

namespace RSA.AlgoLibrary
{
    public class RsaAlgorithm
    {
        /// <summary>
        /// Maximum value for generated primes
        /// </summary>
        private const int MAX_PRIMES_VALUE = 200;

        /// <summary>
        /// Minimum value for generated primes
        /// </summary>
        private const int MIN_PRIMES_VALUE = 100;
        

        /// <summary>
        /// Modulus for the Public and the Private keys
        /// </summary>
        public int N { get; private set; }

        /// <summary>
        /// Public key exponent
        /// </summary>
        public int E { get; private set; }

        /// <summary>
        /// Private key exponent
        /// </summary>
        public int D { get; private set; }

        
        /// <summary>
        /// First random prime number
        /// </summary>
        private int _p;

        /// <summary>
        /// Second random prime number
        /// </summary>
        private int _q;

        /// <summary>
        /// Euler's totient function value
        /// </summary>
        private int _totient;

        
        public RsaAlgorithm()
        {
            GeneratePQ();
            CalculateN();
            CalculateTotient();
            ChooseE();
            CalculateD();
        }
        
        /// <summary>
        /// Generate random primes: P and Q
        /// </summary>
        private void GeneratePQ()
        {
            do
            {
                _p = RsaMath.GeneratePrimeNumber(MIN_PRIMES_VALUE, MAX_PRIMES_VALUE);
                _q = RsaMath.GeneratePrimeNumber(MIN_PRIMES_VALUE, MAX_PRIMES_VALUE);
            } while (_p == _q);
        }

        /// <summary>
        /// Calculate modulus for public and private keys
        /// </summary>
        private void CalculateN()
        {
            N = RsaMath.CalculateModulusForKeys(_p, _q);
        }

        /// <summary>
        /// Calculate Euler's totient function
        /// </summary>
        private void CalculateTotient()
        {
            _totient = RsaMath.CalculateEulersTotientFunction(_p, _q);
        }

        /// <summary>
        /// Choose public key exponent
        /// </summary>
        private void ChooseE()
        {
            E = RsaMath.ChoosePublicKeyExponent(_totient);
        }

        /// <summary>
        /// Calculate private key exponent
        /// </summary>
        private void CalculateD()
        {
            D = RsaMath.CalculatePrivateKeyExponent(E, _totient);
        }

        /// <summary>
        /// Get private RSA Key
        /// </summary>
        /// <returns>RsaPrivateKey Struct</returns>
        public RsaPrivateKey GetPrivateKeyDN()
        {
            RsaPrivateKey privateKey = new RsaPrivateKey(D, N);
            return privateKey;
        }

        /// <summary>
        /// Get public RSA Key
        /// </summary>
        /// <returns>RsaPublicKey Struct</returns>
        public RsaPublicKey GetPublicKeyEN()
        {
            RsaPublicKey publicKey = new RsaPublicKey(E, N);
            return publicKey;
        }

        /// <summary>
        /// Encrypt <c>int</c> message
        /// </summary>
        /// <param name="message">Message</param>
        /// <returns>Encrypted message</returns>
        public int EncryptMessage(int message)
        {
            int encrypted = RsaMath.EncryptMessage(message, E, N);
            return encrypted;
        }

        /// <summary>
        /// Decrypt <c>int</c> message
        /// </summary>
        /// <param name="encryptedMessage">Encrypted message</param>
        /// <returns>Decrypted message</returns>
        public int DecryptMessage(int encryptedMessage)
        {
            int decrypted = RsaMath.DecryptMessage(encryptedMessage, D, N);
            return decrypted;
        }
    }
}
