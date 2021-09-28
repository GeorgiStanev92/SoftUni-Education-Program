using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < nums.Length; i++)
            {
                int num1 = nums[i];

                for (int j = i + 1; j < nums.Length; j++)
                {
                    int num2 = nums[j];

                    if (num1 + num2 == number)
                    {
                        Console.WriteLine($"{num1} {num2}");
                    }
                }
            }
        }
    }
}
