using Ciphers.PZ2;
using Ciphers.PZ3;
using System;
using System.IO;
using System.Text;

namespace KT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PZ3();
        }

        static void PZ2()
        {
            string originalText = "Микулич Кирилл Александрович";
            string originTextEn = "ATTACKATDawn";
            string keyEn = "lemon";
            string key = "КЛЮЧ";
            string langEn = "en";
            string langRu = "ru";

            Console.WriteLine("Task 1. Part 1.1. Route permutation ciphertext");
            int n = 3;
            int m = 10;
            string cipherText = TabularRoutingCipher.Encrypting(originalText, n, m);
            string text = TabularRoutingCipher.Decrypting(cipherText, n, m);
            
            Console.WriteLine($"Original text: {originalText}\nCipher text: {cipherText}\nDecrypt text: {text}");

            Console.WriteLine("\nTask 1. Part 1.2. Playfair Ciphertext");

            string cipherTextPlayfair = PlayfairCiphertext.EncryptDecrypt(originalText);
            string decryptText = PlayfairCiphertext.EncryptDecrypt(cipherTextPlayfair, false);

            Console.WriteLine($"Original text: {originalText}\nCipher text: {cipherTextPlayfair}\nDecrypt text: {decryptText}");

            Console.WriteLine("\nTask 2. Part 1.1. Vigeners cipher");
            string cipherTextEn = VigenereCipher.Encrypt(originTextEn, keyEn, langEn);
            string cipherTextRu = VigenereCipher.Encrypt(originalText, key, langRu);

            string decryptEn = VigenereCipher.Decrypt(cipherTextEn, keyEn, langEn);
            string decryptRu = VigenereCipher.Decrypt(cipherTextRu, key, langRu);

            Console.WriteLine($"Lang - En\nKey = {keyEn} Text = {originTextEn} Cipher = {cipherTextEn} Decrypt = {decryptEn}");
            Console.WriteLine($"Lang - Ru\nKey = {key} Text = {originalText} Cipher = {cipherTextRu} Decrypt = {decryptRu}");

            Console.WriteLine("\nTask 2. Part 1.2. Beaufort cipher");
            string strEncrypt  = BeaufortCipher.Encrypt(originTextEn, keyEn);
            string strDecrypt = BeaufortCipher.Decrypt(strEncrypt, keyEn);

            Console.WriteLine($"Key = {keyEn} Text = {originTextEn} Cipher = {strEncrypt} Decrypt = {strDecrypt}");
        }

        static void PZ3()
        {
            string originalText = "Mikulich"; // Length = 8

            Console.WriteLine("Task 1.");
            string encrypt = StreamingEncryption.Encrypt(originalText);
            string decrypt = StreamingEncryption.Decrypt(encrypt);
            Console.WriteLine($"Text = {originalText} Cipher = {encrypt} Decrypt = {decrypt}");

            Console.WriteLine("Task 2.");
            string encrypt2 = SecondCipher.EncryptDecrypt(originalText);
            string decrypt2 = SecondCipher.EncryptDecrypt(encrypt2);
            Console.WriteLine($"Text = {originalText} Cipher = {encrypt2} Decrypt = {decrypt2}");

            Console.WriteLine("Task 3.");

            using StreamReader reader = new StreamReader(@"C:\Users\k.mikulich\source\repos\KT\File1.txt", Encoding.UTF8);
            string text = reader.ReadToEnd();

            //a = должно бытьвзаимно простым с размером алфавита
            string str = ThirdCipher.Encrypt(text, 4, 4);


            using StreamWriter writer = new StreamWriter(@"C:\Users\k.mikulich\source\repos\KT\File2.txt", false, Encoding.UTF8);
            writer.WriteLine("Encrypt");
            writer.WriteLine(str);

            var str2 = ThirdCipher.Decrypt(str, 4);
            writer.WriteLine("Decrypt");
            foreach (var i in str2)
                writer.WriteLine(i);

            reader.Close();
            writer.Close();
        }
    }
}
