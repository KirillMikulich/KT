using Ciphers;
using System;

namespace KT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PZ2();
        }

        static void PZ2()
        {
            string originalText = "Микулич Кирилл Александрович";
            int n = 3;
            int m = 10;
            string cipherText = TabularRoutingCipher.Encrypting(originalText, n, m);
            string text = TabularRoutingCipher.Decrypting(cipherText, n, m);

            Console.WriteLine($"Original text: {originalText}\nCipher text: {cipherText}\nDecrypt text: {text}");
        }
    }
}
