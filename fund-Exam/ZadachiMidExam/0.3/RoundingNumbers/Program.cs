using System;
using System.Linq;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i] = 0;
                }

                Console.WriteLine($"{nums[i]} => {(int)Math.Round(nums[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
