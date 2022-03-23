using Ciphers.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ciphers.PZ3
{
    public static class ThirdCipher
    {
        private static int _n = 33; //33 26
        public static string Encrypt(string text, int a, int s)
        {
            string cipherText = null;

            if (!string.IsNullOrEmpty(text))
            {
                text = text.ToUpper();


                for(int i=0; i<text.Length; i++)
                {
                    int index = Array.IndexOf(VigenereAlphabet.AlphabetRus, text[i].ToString());

                    var q = (a * index + s) % _n;
                    cipherText += VigenereAlphabet.AlphabetRus[q];
                }
            }
            else
            {
                Console.WriteLine("Invalid string");
                Environment.Exit(0);
            }

            return cipherText;
        }

        public static List<string> Decrypt(string text, int s)
        {
            List<string> cipherList = new List<string>();
            string cipherText = null;

            if (!string.IsNullOrEmpty(text))
            {
                text = text.ToUpper();

                List<int> a = ModuloReciprocalNumber(_n);

                for(int j =0; j<a.Count; j++)
                {
                    cipherText = null;
                    for (int i = 0; i < text.Length; i++)
                    {
                        int index = Array.IndexOf(VigenereAlphabet.AlphabetRus, text[i].ToString());

                        if (index >= s)
                        {
                            var q = a[j] * (index - s) % _n;
                            cipherText += VigenereAlphabet.AlphabetRus[q];
                        }
                        else
                        {
                            var q = a[j] * (index + _n - s) % _n;
                            cipherText += VigenereAlphabet.AlphabetRus[q];
                        }
                    }
                    cipherList.Add(cipherText);
                }

               
            }
            else
            {
                Console.WriteLine("Invalid string");
                Environment.Exit(0);
            }

            return cipherList;
        }

        private static List<int> ModuloReciprocalNumber(int c)
        {
            List<int> numbers = new List<int>();
            for(int a=0; a< _n; a++)
            {
                for (int i = 0; i < c; i++)
                {
                    if ((a * i) % c == 1 &&  i != 1) numbers.Add(i);
                }
            }

            return numbers.Distinct().ToList();
        }

    }
}
