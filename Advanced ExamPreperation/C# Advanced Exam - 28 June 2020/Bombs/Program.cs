using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffect = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bombCasings = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> BombQueue = new Queue<int>(bombEffect);
            Stack<int> BombCasing = new Stack<int>(bombCasings);

            int daturaCounter = 0;
            int cherryCounter = 0;
            int smokeCounter = 0;

            bool allBombs = false;

            while (BombCasing.Count > 0 && BombQueue.Count > 0)
            {
                int effect = BombQueue.Peek();
                int casing = BombCasing.Peek();

                if (effect + casing == 40)
                {
                    daturaCounter++;
                    BombCasing.Pop();
                    BombQueue.Dequeue();
                }
                else if (effect + casing == 60)
                {
                    cherryCounter++;
                    BombCasing.Pop();
                    BombQueue.Dequeue();
                }
                else if (effect + casing == 120)
                {
                    smokeCounter++;
                    BombCasing.Pop();
                    BombQueue.Dequeue();
                }
                else
                {
                    BombCasing.Pop();
                    BombCasing.Push(casing - 5);
                }

                if (daturaCounter >= 3 && cherryCounter >= 3 && smokeCounter >= 3)
                {
                    allBombs = true;
                    break;
                }
            }

            if (allBombs)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (BombQueue.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else if (BombQueue.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", BombQueue)}");

            }

            if (BombCasing.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else if (BombCasing.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", BombCasing)}");

            }

            Console.WriteLine($"Cherry Bombs: {cherryCounter}");
            Console.WriteLine($"Datura Bombs: {daturaCounter}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeCounter}");
        }
    }
}