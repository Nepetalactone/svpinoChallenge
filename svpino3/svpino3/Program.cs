using System;
using System.Collections.Generic;
using System.Numerics;

namespace svpino3
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (BigInteger i in Fibonacci(100))
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }

        private static IEnumerable<BigInteger> Fibonacci(int limit)
        {
            List<BigInteger> fibnumbers = new List<BigInteger>(new BigInteger[] { 0, 1 });

            for (int i = 0; i < limit; i++)
            {
                fibnumbers.Add(fibnumbers[fibnumbers.Count - 1] + fibnumbers[fibnumbers.Count - 2]);
            }

            return fibnumbers.ToArray();
        }
    }
}
