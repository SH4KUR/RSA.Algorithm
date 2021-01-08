using System;
using System.Collections.Generic;
using System.Text;

namespace RSA.AlgoLibrary
{
    public readonly struct RsaPrivateKey
    {
        public RsaPrivateKey(int d, int n)
        {
            D = d;
            N = n;
        }

        public int D { get; }
        public int N { get; }
    }

    
    public readonly struct RsaPublicKey
    {
        public RsaPublicKey(int e, int n)
        {
            E = e;
            N = n;
        }

        public int E { get; }
        public int N { get; }
    }
}
