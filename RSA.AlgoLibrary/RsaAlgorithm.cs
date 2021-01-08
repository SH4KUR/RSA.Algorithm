using System;

namespace RSA.AlgoLibrary
{
    public class RsaAlgorithm
    {
        private const int MAX_PRIME_NUMBER = 30;

        private uint _p;         // prime number
        private uint _q;         // prime number
        private uint _n;         // modulus for the public key and the private keys
        private uint _totient;   // Euler's totient function
        private uint _e;         // public key exponent
        private uint _d;         // private key exponent

        public RsaAlgorithm()
        {
            GeneratePQ();
            SetN();
            CalculateTotient();
            ChooseE();
            CalculateD();
        }

        // TODO: Remove function
        public string GetArgumentsTempFunc() => $"p: {_p}, q: {_q}, n: {_n}, totient: {_totient}, e: {_e}, d: {_d}";

        private void GeneratePQ()
        {
            do
            {
                _p = RsaMath.GeneratePrimeNumber(MAX_PRIME_NUMBER);
                _q = RsaMath.GeneratePrimeNumber(MAX_PRIME_NUMBER);
            } while (_p == _q);
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

        private void CalculateD()
        {
            _d = RsaMath.CalculatePrivateKeyExponent(_e, _totient);
        }

        public uint[] GetPrivateKeyDN()
        {
            uint[] privateKey = new[] { _d, _n };
            return privateKey;
        }

        public uint[] GetPublicKeyEN()
        {
            uint[] publicKey = new[] { _e, _n };
            return publicKey;
        }

        public ulong Encrypt(ulong input)           // TODO: FIX
        {
            ulong pow = 1;
            for (int i = 0; i < _e; i++)
            {
                pow *= input;
            }
            ulong encrypt = pow % _n;

            return encrypt;
        }

        public ulong Decrypt(ulong encryptNumber)     // TODO: FIX
        {
            ulong pow = 1;
            for (int i = 0; i < _d; i++)
            {
                pow *= encryptNumber;
            }
            ulong decrypt = pow % _n;

            return decrypt;
        }
    }
}
