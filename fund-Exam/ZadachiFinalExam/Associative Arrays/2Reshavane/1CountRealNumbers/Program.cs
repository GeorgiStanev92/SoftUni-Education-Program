using System;
using System.Collections.Generic;
using System.Linq;

namespace _1CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> sorted = new SortedDictionary<double, int>();

            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            foreach (var number in numbers)
            {
                if (sorted.ContainsKey(number))
                {
                    sorted[number]++;
                }
                else
                {
                    sorted.Add(number, 1);
                }
            }
            foreach (var number in sorted)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
