using System;
using RSA.AlgoLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsa = new RsaAlgorithm();
            var publicKey = rsa.GetPublicKeyEN();
            var privateKey = rsa.GetPrivateKeyDN();

            Console.WriteLine($"\n {rsa.GetArgumentsTempFunc()}");
            Console.WriteLine($" Private key: {privateKey[0]}, {privateKey[1]}");
            Console.WriteLine($" Public key: {publicKey[0]}, {publicKey[1]}");

            Console.Write("\n Enter for encrypt: ");
            var input = int.Parse(Console.ReadLine() ?? string.Empty);

            var encrypt = rsa.Encrypt(input);
            var decrypt = rsa.Decrypt(encrypt);

            Console.WriteLine($"\n Encrypt: {encrypt}");
            Console.WriteLine($" Decrypt: {decrypt}");

            Console.Write("\n Press <ENTER>: ");
            Console.ReadLine();
        }
    }
}
