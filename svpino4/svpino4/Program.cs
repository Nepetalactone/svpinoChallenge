using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace svpino4
{
    class Program
    {
        private static int max = 0;
        static void Main(string[] args)
        {
            //Brute forces the correct solution by creating a tree which contains all possible combinations
            //and manually comparing them
            List<int> numbers = new List<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            TreeNode<int> root = new TreeNode<int>(0);

            GenerateTree(root, numbers, new int[numbers.Count], 0);
            Console.WriteLine(max);
            Console.ReadKey();
        }

        private static void GenerateTree(TreeNode<int> parent, List<int> numbers, int[] currentValueArray, int depth)
        {
            if (numbers.Count == 0)
            {
                int currentValue = NumberArrayToNumber(currentValueArray);
                max = max > currentValue ? max : currentValue;
            }
            else
            {
                foreach (int num in numbers)
                {
                    currentValueArray[depth] = num;
                    TreeNode<int> leaf = new TreeNode<int>(num);
                    parent.AddLeaf(leaf);

                    List<int> leafNumbers = numbers.Select(n => n).ToList();
                    leafNumbers.RemoveAt(numbers.IndexOf(num));

                    GenerateTree(leaf, leafNumbers, currentValueArray, depth + 1);
                    parent.RemoveLeaf(leaf);
                }
            }
        }

        private static int NumberArrayToNumber(IEnumerable<int> numbers)
        {
            StringBuilder builder = new StringBuilder();
            foreach (int num in numbers)
            {
                builder.Append(num);
            }
            return Int32.Parse(builder.ToString());
        }
    }
}
