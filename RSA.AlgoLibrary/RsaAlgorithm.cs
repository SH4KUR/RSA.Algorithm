using System;

namespace RSA.AlgoLibrary
{
    public class RsaAlgorithm
    {
        private const int MAX_PRIME_NUMBER = 100;

        private int _p;
        private int _q;

        public RsaAlgorithm()
        {
            GeneratePQ();
        }

        private void GeneratePQ()
        {
            _p = RsaMath.GeneratePrimeNumber(MAX_PRIME_NUMBER);
            _q = RsaMath.GeneratePrimeNumber(MAX_PRIME_NUMBER);
        }
    }
}
