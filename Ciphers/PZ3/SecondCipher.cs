using Ciphers.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciphers.PZ3
{
    public static class SecondCipher
    {
        private static int m = 17;
        private static int a = 10;
        private static int b = 11;
        private static List<int> key = PseudoRandomNumberGenerators.Generate(m, a, b, 11, 8);
        public static string EncryptDecrypt(string text)
        {
            string cipherText = null;

            if (!string.IsNullOrEmpty(text))
            {

                text = text.ToUpper();
                var asciiTextArray = Encoding.ASCII.GetBytes(text);
                byte[] ciphetBytes = new byte[8];
                List<int> list = new List<int>();
                for (int i = 0; i < 8; i++)
                {
                    list.Add(XOR(asciiTextArray[i], key[i]));
                    ciphetBytes[i] = (byte)XOR(asciiTextArray[i], key[i]);

                }

                cipherText += Encoding.ASCII.GetString(ciphetBytes);
            }
            else
            {
                Console.WriteLine("Invalid string");
                Environment.Exit(0);
            }

            return cipherText;
        }
        private static int XOR(int a, int b)
        {
            return a ^ b;
        }
    }
}
