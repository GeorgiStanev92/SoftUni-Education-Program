using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveNegativesReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n >= 0)
                .ToList();

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] < 0)
                {
                    nums.Remove(nums[i]);
                }
            }
            nums.Reverse();

            if (nums.Count > 0)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
            else
            {
                Console.WriteLine("empty");
            }
            
        }
    }
}
