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
            List<int> numbers = new List<int>(new[] { 420, 42, 423 });

            TreeNode<int> root = new TreeNode<int>(0);

            GenerateTree(root, numbers);
            SearchMaximumInTree(root, new int[numbers.Count], 0);

            Console.WriteLine(max);
            Console.ReadKey();
        }

        private static void SearchMaximumInTree(TreeNode<int> parent, int[] numbers, int depth)
        {
            if (parent.GetLeafs() == null)
            {
                int currentValue = NumberArrayToNumber(numbers);
                max = max > currentValue ? max : currentValue;
            }
            else
            {
                foreach (var leaf in parent.GetLeafs())
                {
                    numbers[depth] = leaf.Value;
                    SearchMaximumInTree(leaf, numbers, depth + 1);
                }
            }
        }

        private static void GenerateTree(TreeNode<int> parent, List<int> numbers)
        {
            foreach (int num in numbers)
            {
                TreeNode<int> leaf = new TreeNode<int>(num);
                parent.AddLeaf(leaf);

                List<int> leafNumbers = numbers.Select(n => n).ToList();
                leafNumbers.RemoveAt(numbers.IndexOf(num));

                GenerateTree(leaf, leafNumbers);
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
