using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> numbers2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>(numbers1.Count + numbers2.Count);

            int limit = Math.Min(numbers1.Count, numbers2.Count);

            for (int i = 0; i < limit; i++)
            {
                result.Add(numbers1[i]);
                result.Add(numbers2[i]);
            }

            if (numbers1.Count != numbers2.Count)
            {
                if (numbers1.Count > numbers2.Count)
                {
                    result.AddRange(GetRemindingList(numbers1, numbers2));
                }
                else
                {
                    result.AddRange(GetRemindingList(numbers2, numbers1));
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }    

        private static IEnumerable<int> GetRemindingList(List<int> longerList, List<int> shorterList)
        {
            if (longerList.Count <= shorterList.Count)
            {
                throw new ArgumentException();
            }

            List<int> numbers = new List<int>();

            for (int i = shorterList.Count; i < longerList.Count; i++)
            {
                numbers.Add(longerList[i]);
            }
            return numbers;
        }
    }
}
