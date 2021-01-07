using System;
using RSA.AlgoLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsa = new RsaAlgorithm();

            Console.WriteLine(rsa.GetArgumentsTempFunc());
            Console.WriteLine($"private key: {rsa.GetPrivateKeyDN()[0]}, {rsa.GetPrivateKeyDN()[1]}");
            Console.WriteLine($"public key: {rsa.GetPublicKeyEN()[0]}, {rsa.GetPublicKeyEN()[1]}");
        }
    }
}
