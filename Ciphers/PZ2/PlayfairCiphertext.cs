using System;

namespace Ciphers.PZ2
{
    public static class PlayfairCiphertext
    {
        private static string[,] cipherAlphabetArray =
        {
              //0  //1  //2  //3  //4  //5  //6
            { "р", "о", "з", "у", "м", "а", "б" }, //0
            { "в", "г", "д", "е", "ё", "ж", "и" }, //1
            { "й", "к", "л", "н", "п", "с", "т" }, //2
            { "ф", "х", "ц", "ч", "ш", "щ", "ъ" }, //3
            { "ы", "ь", "э", "ю", "я", "1", " " }  //4 //Дополнительные символы не должны совпадать
        };

        private static int _n = 4;
        private static int _m = 6;

        public static string EncryptDecrypt(string text, bool isEncrypt = true)
        {
            string cipherText = null;

            if (!string.IsNullOrEmpty(text))
            {
                text = SetEvenString(text.ToLower());

                for (int i = 0; i < text.Length;)
                {
                    for (int j = 1; j < text.Length;)
                    {
                        string symbolA = text[i].ToString();
                        string symbolB = text[j].ToString();

                        (int iA, int jA) = FindItem(symbolA);
                        (int iB, int jB) = FindItem(symbolB);
                        (int niA, int njA, int niB, int njB) = GetNewSymbols(iA, jA, iB, jB, isEncrypt);

                        cipherText += $"{cipherAlphabetArray[niA, njA]}{cipherAlphabetArray[niB, njB]}";

                        i += 2;
                        j += 2;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid string");
                Environment.Exit(0);
            }

            return cipherText;
        }

        private static (int iA, int jA, int iB, int jB) GetNewSymbols(int iA, int jA, int iB, int jB, bool isEncrypt = true)
        {
            if (iA == iB && jA != jB)
            {
                jA = FixColumn(isEncrypt ? ++jA : --jA);
                jB = FixColumn(isEncrypt ? ++jB : --jB);

            }
            else if (iA != iB && jA == jB)
            {
                iA = FixRow(isEncrypt ? ++iA : --iA);
                iB = FixRow(isEncrypt ? ++iB : --iB);
            }
            else if (iA != iB && jA != jB)
            {
                int j = jA;
                jA = jB;
                jB = j;
            }

            return (iA, jA, iB, jB);
        }


        private static int FixColumn(int index)
        {
            if (index > _m) return index - _m;
            if (index < 0) return index + _m;
            return index;
        }

        private static int FixRow(int index)
        {
            if (index > _n) return index - _n;
            if (index < 0) return index + _n;
            return index;
        }


        private static (int n, int m) FindItem(string symbol)
        {
            for (int i = 0; i <= _n; i++)
                for (int j = 0; j <=_m; j++)
                    if (cipherAlphabetArray[i, j] == symbol)
                        return (i, j);

            Console.WriteLine("Invalid symbol in orginal string");
            Environment.Exit(0);

            return (0, 0);
        }

        private static string SetEvenString(string text)
        {
            if (text.Length % 2 != 0)
                text += "1";

            return text;
        }
    }
}
