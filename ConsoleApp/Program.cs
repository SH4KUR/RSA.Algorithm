using System;
using RSA.AlgoLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RsaAlgorithm rsa = new RsaAlgorithm();
            
            uint[] publicKey = rsa.GetPublicKeyEN();
            uint[] privateKey = rsa.GetPrivateKeyDN();

            uint E = publicKey[0];
            uint D = privateKey[0];
            uint N = publicKey[1];

            Console.WriteLine($"\n {rsa.GetArgumentsTempFunc()}");
            Console.WriteLine($" Private key: {D}, {N}");
            Console.WriteLine($" Public key: {E}, {N}");

            Console.Write("\n Enter for encrypt: ");
            int input = int.Parse(Console.ReadLine() ?? string.Empty);

            ulong encrypt = rsa.EncryptMessage((ulong)input);
            ulong decrypt = rsa.DecryptMessage(encrypt);

            Console.WriteLine($"\n Encrypt: {encrypt}");
            Console.WriteLine($" Decrypt: {decrypt}");

            Console.Write("\n Press <ENTER>: ");
            Console.ReadLine();
        }
    }
}
