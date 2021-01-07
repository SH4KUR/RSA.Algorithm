using System;

namespace RSA.AlgoLibrary
{
    public class RsaAlgorithm
    {
        private const int MAX_PRIME_NUMBER = 100;

        private int _p;         // prime number
        private int _q;         // prime number
        private int _n;         // modulus for the public key and the private keys
        private int _totient;   // Euler's totient function
        private int _e;         // public key exponent

        public RsaAlgorithm()
        {
            GeneratePQ();
            SetN();
            CalculateTotient();
            ChooseE();
        }

        // TODO: Remove function
        public string GetArgumentsTempFunc() => $"p: {_p}, q: {_q}, n: {_n}, totient: {_totient}";

        private void GeneratePQ()
        {
            _p = RsaMath.GeneratePrimeNumber(MAX_PRIME_NUMBER);
            _q = RsaMath.GeneratePrimeNumber(MAX_PRIME_NUMBER);
        }

        private void SetN()
        {
            _n = _p * _q;
        }

        private void CalculateTotient()
        {
            _totient = RsaMath.CalculateEulersTotientFunction(_p, _q);
        }

        private void ChooseE()
        {
            _e = RsaMath.ChoosePublicKeyExponent(_totient);
        }
    }
}
