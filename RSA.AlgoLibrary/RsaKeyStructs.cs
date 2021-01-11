using System;
using System.Collections.Generic;
using System.Text;

namespace RSA.AlgoLibrary
{
    /// <summary>
    /// Private RSA Key
    /// </summary>
    public readonly struct RsaPrivateKey
    {
        public RsaPrivateKey(int d, int n)
        {
            D = d;
            N = n;
        }

        /// <summary>
        /// Private key exponent
        /// </summary>
        public int D { get; }

        /// <summary>
        /// Private key modulus
        /// </summary>
        public int N { get; }
    }

    /// <summary>
    /// Public RSA Key
    /// </summary>
    public readonly struct RsaPublicKey
    {
        public RsaPublicKey(int e, int n)
        {
            E = e;
            N = n;
        }

        /// <summary>
        /// Public key exponent
        /// </summary>
        public int E { get; }

        /// <summary>
        /// Public key modulus
        /// </summary>
        public int N { get; }
    }
}
