using System;
using System.Linq;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int[] nums1 = new int[lines];
            int[] nums2 = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                int[] number = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    nums1[i] = number[0];
                    nums2[i] = number[1];
                }
                else
                {
                    nums1[i] = number[1];
                    nums2[i] = number[0];
                }
            }
            Console.WriteLine(string.Join(" ", nums1));
            Console.WriteLine(string.Join(" ", nums2));
        }
    }
}
