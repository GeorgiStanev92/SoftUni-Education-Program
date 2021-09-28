using System;
using System.Collections.Generic;
using System.Linq;

namespace zadacha
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] queue = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] stack = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> first = new Queue<int>(queue);
            Stack<int> second = new Stack<int>(stack);

            List<int> claimed = new List<int>();

            while (true)
            {
                if ((first.Peek() + second.Peek()) % 2 == 0)
                {
                    claimed.Add(first.Dequeue() + second.Pop());
                }
                else
                {
                    first.Enqueue(second.Pop());
                }

                if (first.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }

                if (second.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
            }

            if (claimed.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimed.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimed.Sum()}");
            }
        }
    }
}