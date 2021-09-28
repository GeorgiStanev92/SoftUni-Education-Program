using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNum = nums[i];

                for (int j = i + 1; j < nums.Length; j++)
                {
                    int rightNum = nums[j];

                    if (currentNum + rightNum == num)
                    {
                        Console.WriteLine($"{currentNum} {rightNum}");
                        break;
                    }
                }
            }
        }
    }
}
