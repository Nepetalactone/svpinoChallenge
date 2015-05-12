using System;
using System.Collections.Generic;
using System.Linq;

namespace svpino5
{
    class Program
    {
        static void Main(string[] args)
        {
            //0 = join numbers, 1 = plus, 2 = minus
            int[] ops = {0, 0, 0, 0, 0, 0, 0, 0 };

            while (!IsMaxOp(ops))
            {
                if (IsOpListCompatible(ops))
                {
                    PrintCombination(ops);
                }
                ops = IterateArray(ops);
            }
            Console.ReadKey();
        }

        private static void PrintCombination(int[] ops)
        {
            for (int i = 1; i < 10; i++)
                    {
                        Console.Write(i);
                        if (i <= 8)
                        {
                            switch (ops[i - 1])
                            {
                                case 1:
                                    Console.Write("+");
                                    break;
                                case 2:
                                    Console.Write("-");
                                    break;
                            }
                        }
                    }
                    Console.WriteLine();
        }

        private static bool IsOpListCompatible(int[] opList)
        {
            List<int> intList = Enumerable.Range(1, 9).ToList();

            //Join numbers
            int j = 0;
            for (int i = 0; i < opList.Length; i++)
            {
                if (opList[i] == 0)
                {
                    String a = intList[j].ToString();
                    String b = intList[j + 1].ToString();
                    intList[j] = int.Parse(a + b);
                    intList.RemoveAt(j + 1);
                }
                else
                {
                    j++;
                }
            }

            //Remove join ops
            int[] newOpList = opList.Where(x => x != 0).ToArray();

            int sum = intList[0];

            for (int i = 0; i < newOpList.Length; i++)
            {
                switch (newOpList[i])
                {
                    case 1:
                        sum += intList[i + 1];
                        break;

                    case 2:
                        sum -= intList[i + 1];
                        break;
                }
            }

            return sum == 100;
        }

        private static int[] IterateArray(int[] opList)
        {
            int x = 0;
            opList[x]++;
            while (x < opList.Length && opList[x] == 3)
            {
                int y = x;
                while (y >= 0)
                {
                    opList[y] = 0;
                    y--;
                }
                if (x + 1 < opList.Length)
                {
                    opList[x + 1]++;
                }
                x++;
            }

            return opList;
        }

        private static bool IsMaxOp(int[] op)
        {
            return op.All(x => x == 2);
        }
    }
}
