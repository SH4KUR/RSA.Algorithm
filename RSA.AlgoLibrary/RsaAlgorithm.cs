using System;
using System.Numerics;

namespace RSA.AlgoLibrary
{
    public class RsaAlgorithm
    {
        private const int MAX_PRIME_NUMBER = 100;

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

        public ulong EncryptMessage(ulong input)
        {
            ulong encrypt = RsaMath.CalculateEncryptDecryptMessage(input, _e, _n);
            return encrypt;
        }

        public ulong DecryptMessage(ulong encryptInput)
        {
            ulong decrypt = RsaMath.CalculateEncryptDecryptMessage(encryptInput, _d, _n);
            return decrypt;
        }
    }
}
