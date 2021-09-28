using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                bool topNumber = true;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int rightNumber = numbers[j];

                    if (number <= rightNumber)
                    {
                        topNumber = false;
                        break;
                    }
                }
                if (topNumber)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
