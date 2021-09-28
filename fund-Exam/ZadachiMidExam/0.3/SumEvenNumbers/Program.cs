using System;
using System.Linq;

namespace SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int even = 0;

            for (int i = 0; i < numbers.Length; i++)
            {

                if (numbers[i] % 2 == 0)
                {
                    even += numbers[i];
                }
            }

            Console.WriteLine(even);
        }
    }
}
