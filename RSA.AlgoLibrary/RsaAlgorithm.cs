﻿using System;

namespace RSA.AlgoLibrary
{
    public class RsaAlgorithm
    {
        private const int MAX_PRIME_NUMBER = 30;

        private int _p;         // prime number
        private int _q;         // prime number
        private int _n;         // modulus for the public key and the private keys
        private int _totient;   // Euler's totient function
        private int _e;         // public key exponent
        private int _d;         // private key exponent

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

        public int[] GetPrivateKeyDN()
        {
            var privateKey = new[] { _d, _n };
            return privateKey;
        }

        public int[] GetPublicKeyEN()
        {
            var publicKey = new[] { _e, _n };
            return publicKey;
        }

        public long Encrypt(int number)     // TODO: FIX
        {
            long pow = 1;
            for (var i = 0; i < _e; i++)
            {
                pow *= number;
            }
            var encrypt = pow % _n;

            return encrypt;
        }

        public long Decrypt(long encryptNumber)     // TODO: FIX
        {
            long pow = 1;
            for (var i = 0; i < _d; i++)
            {
                pow *= encryptNumber;
            }
            var decrypt = pow % _n;

            return decrypt;
        }
    }
}
