using System;
using System.Collections.Generic;
using System.Linq;

namespace _1CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> sortedNums = new SortedDictionary<double, int>();

            foreach (var num in nums)
            {
                if (sortedNums.ContainsKey(num))
                {
                    sortedNums[num]++;
                }
                else
                {
                    sortedNums.Add(num, 1);
                }
            }
            foreach (var sortedNum in sortedNums)
            {
                Console.WriteLine($"{sortedNum.Key} -> {sortedNum.Value}");
            }
        }
    }
}
