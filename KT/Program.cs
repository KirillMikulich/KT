using Ciphers.PZ2;
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
            //Console.WriteLine("Task 1. Part 1.1. Route permutation ciphertext");
            string originalText = "Микулич Кирилл Александрович";
            int n = 3;
            int m = 10;
            string cipherText = TabularRoutingCipher.Encrypting(originalText, n, m);
            string text = TabularRoutingCipher.Decrypting(cipherText, n, m);
            
            //Console.WriteLine($"Original text: {originalText}\nCipher text: {cipherText}\nDecrypt text: {text}");

            //Console.WriteLine("\nTask 1. Part 1.2. Playfair Ciphertext");

            string cipherTextPlayfair = PlayfairCiphertext.EncryptDecrypt(originalText);
            string decryptText = PlayfairCiphertext.EncryptDecrypt(cipherTextPlayfair, false);

            //Console.WriteLine($"Original text: {originalText}\nCipher text: {cipherTextPlayfair}\nDecrypt text: {decryptText}");

            Console.WriteLine("\n Task 2. Part 1.1. Vigeners cipher");
            Console.WriteLine("\n Task 2. Part 1.2. Beaufort cipher");
        }
    }
}
