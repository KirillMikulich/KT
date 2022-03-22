using System;
using System.Linq;

namespace RPC
{
    public static class TabularRoutingCipher
    {
        public static string Encrypting(string text, int n, int m)
        {
            string cipherText = null;
            string[,] cipherArray = new string[n, m];

            if (!string.IsNullOrEmpty(text))
            {
                text = RemoveSpaces(text);//Зменяем пробелы на _
                text = IsLengthStringEqualLengthMatrix(text, n, m);// Првоеряем что бы было четкное колво элементов

                int i = 0, j = 0;
                text.ToLower().ToList().ForEach(s => //преобразуем к нижнему регистру, потом в массив, и переписываем в массив
                {
                    if (j >= m)
                    {
                        j = 0;
                        i++;
                    }
                    cipherArray[i, j] = s.ToString();
                    j++;
                });


                for (j = 0; j < m; j++)
                    for (i = 0; i < n; i++)
                        cipherText += cipherArray[i, j];
            }
            else
            {
                Console.WriteLine("Invalid string");
                Environment.Exit(0);
            }

            return cipherText;
        }

        public static string Decrypting(string text, int n, int m)
        {
            string cipherText = null;
            string[,] cipherArray = new string[n, m];

            if (!string.IsNullOrEmpty(text))
            {
                text = IsLengthStringEqualLengthMatrix(text, n, m);

                for(int j=0, k=0; j<m; j++)
                    for(int i=0; i<n; i++)
                    {
                        cipherArray[i, j] = text[k].ToString();
                        k++;
                    }

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        cipherText += cipherArray[i, j];

            }
            else
            {
                Console.WriteLine("Invalid string");
                Environment.Exit(0);
            }

            return cipherText;
        }

        private static string RemoveSpaces(string text)
        {
            return text.Replace(' ', '_');
        }

        private static string IsLengthStringEqualLengthMatrix(string text, int n, int m)
        {
            if (n*m > text.Length)
                for(int i=0; i<= ((n*m) - text.Length); i++)
                    text += "_";

            if (n * m < text.Length)
            {
                Console.WriteLine("Invalid array size");
                Environment.Exit(0);
            }

            return text;        
        }

    }
}
