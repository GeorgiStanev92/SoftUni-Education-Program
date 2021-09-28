using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class StartUp
    {
        static void Main()
        {
            int[] liliesSqeuence = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] rosesSequence = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> liliesStack = new Stack<int>(liliesSqeuence);
            Queue<int> rosesQueue = new Queue<int>(rosesSequence);

            int wreathsCounter = 0;
            int leftFlowers = 0;
            int operationsCount = rosesQueue.Count();
            for (int i = 0; i < operationsCount; i++)
            {
                int lilies = liliesStack.Peek();
                int roses = rosesQueue.Peek();
                if (lilies + roses == 15)
                {
                    wreathsCounter++;
                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                }
                else if (lilies + roses > 15)
                {
                    while (true)
                    {
                        lilies -= 2;
                        if (lilies + roses == 15)
                        {
                            wreathsCounter++;
                            liliesStack.Pop();
                            rosesQueue.Dequeue();
                            break;
                        }
                        else if (lilies + roses < 15)
                        {
                            leftFlowers += lilies + roses;
                            liliesStack.Pop();
                            rosesQueue.Dequeue();
                            break;
                        }
                    }
                }
                else
                {
                    leftFlowers += lilies + roses;
                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                }
            }
            if (leftFlowers >= 15)
            {
                var leftOvers = leftFlowers / 15;
                wreathsCounter += leftOvers;
            }
            if (wreathsCounter >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCounter} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCounter} wreaths more!");
            }
        }
    }
}