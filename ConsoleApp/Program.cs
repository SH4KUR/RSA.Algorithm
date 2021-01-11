using System;
using RSA.AlgoLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n --- RSA.ALGORITHM ---\n");

            RsaAlgorithm rsa = new RsaAlgorithm();
            
            RsaPublicKey publicKey = rsa.GetPublicKeyEN();
            RsaPrivateKey privateKey = rsa.GetPrivateKeyDN();

            Console.WriteLine($" * Private key: {privateKey.D}, {privateKey.N}");
            Console.WriteLine($" * Public key: {publicKey.E}, {publicKey.N}");

            int input;
            do
            {
                Console.Write("\n - Enter for encrypt/decrypt (1 - 10000): ");
                input = int.Parse(Console.ReadLine() ?? string.Empty);
            } while (input < 1 || input > 10000);

            int encrypt = rsa.EncryptMessage(input);
            int decrypt = rsa.DecryptMessage(encrypt);

            Console.WriteLine($"\n * Encrypt: {encrypt}");
            Console.WriteLine($" * Decrypt: {decrypt}");

            Console.Write("\n --- Press <ENTER>: ");
            Console.ReadLine();
        }
    }
}
