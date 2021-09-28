using System;
using System.Collections.Generic;
using System.Linq;

namespace _3MergingLists
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

            List<int> numbers = new List<int>(nums1.Count + nums2.Count);
            int limit = Math.Min(nums2.Count, nums1.Count);

            for (int i = 0; i <limit ; i++)
            {
                numbers.Add(nums1[i]);
                numbers.Add(nums2[i]);
            }

            if (nums1.Count != nums2.Count)
            {
                if (nums1.Count > nums2.Count)
                {
                    numbers.AddRange(GetRemindingList(nums1, nums2));
                }
                else
                {
                    numbers.AddRange(GetRemindingList(nums2, nums1));
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
            
        }

        private static List<int> GetRemindingList(List<int> longerList, List<int> shorterList)
        {
            if (longerList.Count <= shorterList.Count)
            {
                throw new ArgumentException();
            }

            List<int> result = new List<int>();

            for (int i = shorterList.Count; i < longerList.Count; i++)
            {
                result.Add(longerList[i]);
            }

            return result;
        }
    }
}
