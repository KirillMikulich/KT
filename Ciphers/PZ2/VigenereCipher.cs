using Ciphers.Constants;
using System;

namespace Ciphers.PZ2
{
    public static class VigenereCipher
    {

        public static string Encrypt(string text, string key, string lang = "en")
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

                    int indexWord = FindChar(text[i].ToString(), lang);

                    int indexKey = FindChar(key[j].ToString(), lang);

                    if (indexWord != -1 && indexKey != -1)
                        cipherText += GetNewChar(indexWord, indexKey, lang);
                    else
                        cipherText += text[i];

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

        public static string Decrypt(string text, string key, string lang = "en")
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

                    int indexKey = FindChar(key[j].ToString(), lang);

                    string[] row = GetRow(indexKey, lang);
                    int index = Array.IndexOf(row, text[i].ToString());

                    if (index != -1)
                        cipherText += (lang == "en" ? VigenereAlphabet.AlphabetEn : VigenereAlphabet.AlphabetRus)[index];

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
        private static string[] GetRow(int row, string lang)
        {
            string[] row_res = new string[(lang == "en" ? 26 : 32)];

            string[,] matrix = (lang == "en" ? VigenereAlphabet.TabulaRectaEn : VigenereAlphabet.TabulaRectaRu);

            for (int i = 0; i < (lang == "en" ? 26 : 32); i++)
            {
                row_res[i] = matrix[row, i];
            }

            return row_res;
        }

        private static string GetNewChar(int i, int j, string lang)
        {
            if (lang == "en") return VigenereAlphabet.TabulaRectaEn[i, j];
            else return VigenereAlphabet.TabulaRectaRu[i, j];
        }

        private static int FindChar(string symbol, string lang)
        {
            if (lang == "en") return Array.IndexOf(VigenereAlphabet.AlphabetEn, symbol);
            else return Array.IndexOf(VigenereAlphabet.AlphabetRus, symbol);
        }
    }
}
