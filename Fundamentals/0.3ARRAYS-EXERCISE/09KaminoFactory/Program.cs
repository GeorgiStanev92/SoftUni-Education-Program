using System;
using System.Linq;

namespace _09KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int bestSequenceSize = 0;
            int bestSequenceStartingIndex = 0;
            int bestSequenceSum = 0;
            int[] bestSequence = new int[size];
            int bestSample = 1;

            int sample = 0;

            while (true)
            {
                string line = Console.ReadLine();
                sample += 1;

                if (line == "Clone them!")
                {
                    break;
                }

                int[] sequence = line
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int sequenceSum = 0;

                foreach (var number in sequence)
                {
                    sequenceSum += number;
                }

                for (int i = 0; i < sequence.Length; i++)
                {
                    int currentNumber = sequence[i];
                    
                    if (currentNumber == 0)
                    {
                        continue;
                    }

                    int currentSequenceBestSize = 1;

                    for (int j = 0; j < sequence.Length; j++)
                    {
                        if (currentNumber == sequence[j])
                        {
                            currentSequenceBestSize += 1;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (currentSequenceBestSize > bestSequenceSize)
                    {
                        bestSequenceSize = currentSequenceBestSize;
                        bestSequenceStartingIndex = i;
                        bestSequenceSum = sequenceSum;
                        bestSequence = sequence;
                        bestSample = sample;
                    }
                    else if (currentSequenceBestSize == bestSequenceSize)
                    {
                        if (i < bestSequenceStartingIndex)
                        {
                            bestSequenceSize = currentSequenceBestSize;
                            bestSequenceStartingIndex = i;
                            bestSequenceSum = sequenceSum;
                            bestSequence = sequence;
                            bestSample = sample;
                        }
                        else if (i == bestSequenceStartingIndex
                            && sequenceSum > bestSequenceSum)
                        {
                            bestSequenceSize = currentSequenceBestSize;
                            bestSequenceStartingIndex = i;
                            bestSequenceSum = sequenceSum;
                            bestSequence = sequence;
                            bestSample = sample;
                        }
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(" ",bestSequence));
        }
    }
}
