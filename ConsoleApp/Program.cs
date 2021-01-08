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
            Console.WriteLine($" private key: {privateKey[0]}, {privateKey[1]}");
            Console.WriteLine($" public key: {publicKey[0]}, {publicKey[1]}");

            Console.Write("Hash number: ");
            var number = int.Parse(Console.ReadLine() ?? string.Empty);

            var encrypt = rsa.Encrypt(number);
            var decrypt = rsa.Decrypt(encrypt);

            Console.WriteLine($"encrypt: {encrypt}");
            Console.WriteLine($"decrypt: {decrypt}");

            Console.Write("\n Press <ENTER>: ");
            Console.ReadLine();
        }
    }
}
