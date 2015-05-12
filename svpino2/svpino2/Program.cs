using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svpino2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> charList = new List<char>(new[] {'a', 'b', 'c'});
            List<int> intList = new List<int>(new [] {1, 2, 3});

            foreach (var obj in CombineLists(charList, intList))
            {
                Console.WriteLine(obj.ToString());
            }

            Console.ReadKey();
        }

        private static List<object> CombineLists (IList firstList, IList secondList)
        {
            int maxLength = (firstList.Count <= secondList.Count) ? firstList.Count : secondList.Count;
            List<object> objectList = new List<object>();
            //Disregard leftover objects in the longer list
            for (int i = 0; i < maxLength; i++)
            {
                objectList.Add(firstList[i]);
                objectList.Add(secondList[i]);
            }
            return objectList;
        }
    }
}
