using Ciphers.Constants;
using System;

namespace Ciphers.PZ2
{
    public static class BeaufortCipher
    {
        public static string Encrypt(string text, string key)
        {
            string cipherText = null;

            text = text.ToUpper();
            key = key.ToUpper();

            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(key))
            {
                for (int i = 0, j = 0; i < text.Length; i++)
                {
                    if (text[i] == ' ') continue;
                    if (j >= key.Length) j = 0;

                    
                    int indexWord = FindChar(text[i].ToString());
                    string[] row = GetColumn(indexWord);

                    int indexKey = Array.IndexOf(row, key[j].ToString());

                    if (indexKey != -1)
                    {
                        cipherText += VigenereAlphabet.AlphabetEn[indexKey];
                    }
                    else
                    {
                        Console.WriteLine("Invalid string");
                        Environment.Exit(0);
                    }
                    j++;
                }
            }
            else
            {
                Console.WriteLine("Invalid string");
                Environment.Exit(0);
            }


            return cipherText;
        }


        public static string Decrypt(string text, string key)
        {
            string cipherText = null;

            text = text.ToUpper();
            key = key.ToUpper();

            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(key))
            {
                for (int i = 0, j = 0; i < text.Length; i++)
                {
                    if (text[i] == ' ') continue;
                    if (j >= key.Length) j = 0;


                    int indexWord = FindChar(text[i].ToString());
                    string[] row = GetRow(indexWord);

                    int indexKey = Array.IndexOf(row, key[j].ToString());

                    if (indexKey != -1)
                    {
                        cipherText += VigenereAlphabet.AlphabetEn[indexKey];
                    }
                    else
                    {
                        Console.WriteLine("Invalid string");
                        Environment.Exit(0);
                    }
                    j++;
                }
            }
            else
            {
                Console.WriteLine("Invalid string");
                Environment.Exit(0);
            }


            return cipherText;
        }

        private static string[] GetColumn(int row)
        {
            string[] row_res = new string[26];

            string[,] matrix =  VigenereAlphabet.TabulaRectaEn;

            for (int i = 0; i < 26; i++)
            {
                row_res[i] = matrix[i, row];
            }

            return row_res;
        }

        private static string[] GetRow(int row)
        {
            string[] row_res = new string[26];

            string[,] matrix = VigenereAlphabet.TabulaRectaEn;

            for (int i = 0; i < 26; i++)
            {
                row_res[i] = matrix[row, i];
            }

            return row_res;
        }

        private static int FindChar(string symbol)
        {
            return Array.IndexOf(VigenereAlphabet.AlphabetEn, symbol);
        }
    }
}
