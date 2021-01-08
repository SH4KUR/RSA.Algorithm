using System;
using RSA.AlgoLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RsaAlgorithm rsa = new RsaAlgorithm();
            
            RsaPublicKey publicKey = rsa.GetPublicKeyEN();
            RsaPrivateKey privateKey = rsa.GetPrivateKeyDN();

            Console.WriteLine($" Private key: {privateKey.D}, {privateKey.N}");
            Console.WriteLine($" Public key: {publicKey.E}, {publicKey.N}");

            Console.Write("\n Enter for encrypt/decrypt: ");
            int input = int.Parse(Console.ReadLine() ?? string.Empty);

            int encrypt = rsa.EncryptMessage(input);
            int decrypt = rsa.DecryptMessage(encrypt);

            Console.WriteLine($"\n Encrypt: {encrypt}");
            Console.WriteLine($" Decrypt: {decrypt}");

            Console.Write("\n Press <ENTER>: ");
            Console.ReadLine();
        }
    }
}
