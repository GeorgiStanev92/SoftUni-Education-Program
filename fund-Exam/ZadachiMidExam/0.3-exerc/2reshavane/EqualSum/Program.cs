using System;
using System.Linq;

namespace EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool exist = false;

            for (int i = 0; i < nums.Length; i++)
            {
                int leftSum = 0;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    leftSum += nums[j];
                }

                int rightSum = 0;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    rightSum += nums[j];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                Console.WriteLine("no");
            }
        }
    }
}
