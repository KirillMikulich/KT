using System;
using System.Collections.Generic;

namespace Ciphers.Utils
{
    public static class PseudoRandomNumberGenerators
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m">m > 0</param>
        /// <param name="a">0 <= a <= m</param>
        /// <param name="c">0 <= c <= m</param>
        /// <param name="x">0 <= x <= m</param>
        /// <param name="countNumbers"></param>
        /// <returns> list numbers</returns>
        public static List<int> Generate(int m, int a, int c, int x, int countNumbers)
        {
            List<int> numbers = new List<int>();

            if ( m < 0 || a < 0 || a > m || c < 0 || c > m || x < 0 || x > m)
            {
                Console.WriteLine("Invalid m, a, c, x arguments");
                Environment.Exit(0);
            }

            for(int i=0; i< countNumbers; i++)
            {
                x = (a * x + c) % m;
                numbers.Add(x);
            }

            return numbers;
        }
    }
}
