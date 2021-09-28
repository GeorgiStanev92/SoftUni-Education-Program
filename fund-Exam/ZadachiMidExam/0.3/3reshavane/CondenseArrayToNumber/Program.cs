using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] condense = new int[nums.Length - 1];

            if (nums.Length == 1)
            {
                Console.WriteLine(nums[0]);
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < condense.Length - i; j++)
                {
                    condense[j] = nums[j] + nums[j + 1];
                }
                nums = condense;
            }
            Console.WriteLine(condense[0]);
        }
    }
}
