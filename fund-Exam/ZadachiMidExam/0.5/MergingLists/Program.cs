using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> nums2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>(nums1.Count + nums2.Count);

            int limit = Math.Min(nums2.Count, nums1.Count);

            for (int i = 0; i < limit; i++)
            {
                result.Add(nums1[i]);
                result.Add(nums2[i]);
            }

            if (nums1.Count != nums2.Count)
            {
                if (nums1.Count > nums2.Count)
                {
                    result.AddRange(GetRemindingList(nums1, nums2));
                }
                else
                {
                    result.AddRange(GetRemindingList(nums2, nums1));
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }

        private static List<int> GetRemindingList(List<int> longerList, List<int> shorterList)
        {
            if (longerList.Count <= shorterList.Count)
            {
                throw new ArgumentException();
            }

            List<int> numbers = new List<int>();

            for (int i = shorterList.Count; i < longerList.Count; i++)
            {
                numbers.Add(longerList[i]);
            }
            return numbers;
        }
    }
}
