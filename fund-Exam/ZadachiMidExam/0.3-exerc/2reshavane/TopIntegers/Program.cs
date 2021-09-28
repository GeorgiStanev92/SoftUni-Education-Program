using System;
using System.Linq;

namespace TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNumber = nums[i];
                bool topNumber = true;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    int rightNumber = nums[j];

                    if (currentNumber <= rightNumber)
                    {
                        topNumber = false;
                        break;
                    }
                }
                if (topNumber)
                {
                    Console.Write($"{currentNumber} ");
                }
            }
        }
    }
}
