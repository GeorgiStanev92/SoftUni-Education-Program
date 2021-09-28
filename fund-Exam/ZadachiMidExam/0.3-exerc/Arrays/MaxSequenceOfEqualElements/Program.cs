using System;
using System.Linq;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bestSequenceSize = 0;
            int bestSequenceNumber = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNumber = nums[i];
                int sequenceSize = 1;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    int rightNumber = nums[j];

                    if (currentNumber == rightNumber)
                    {
                        sequenceSize += 1;
                    }
                    else
                    {
                        break;
                    }
                }

                if (sequenceSize > bestSequenceSize)
                {
                    bestSequenceSize = sequenceSize;
                    bestSequenceNumber = currentNumber;
                }
            }

            for (int i = 0; i < bestSequenceSize; i++)
            {
                Console.Write($"{bestSequenceNumber} ");
            }
        }
    }
}
