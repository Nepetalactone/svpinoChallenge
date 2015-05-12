using System;
using System.Collections.Generic;

namespace svpino1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> testList = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                testList.Add(rand.Next());
            }

            Console.WriteLine(WhileSum(testList));
            Console.WriteLine(ForSum(testList));
            Console.WriteLine(RecursionSum(testList));
            Console.ReadKey();
        }

        private static int WhileSum(List<int> testList)
        {
            int i = 0;
            int sum = 0;

            while (i < testList.Count)
            {
                sum += testList[i];
                i++;
            }

            return sum;
        }

        private static int ForSum(List<int> testList)
        {
            int sum = 0;
            for (int i = 0; i < testList.Count; i++)
            {
                sum += testList[i];
            }
            return sum;
        }

        private static int RecursionSum(List<int> testList)
        {
            int sum = 0;

            if (testList.Count == 0)
            {
                return sum;
            }

            sum += testList[0];

            testList.RemoveAt(0);

            return sum + RecursionSum(testList);
        }
    }
}
