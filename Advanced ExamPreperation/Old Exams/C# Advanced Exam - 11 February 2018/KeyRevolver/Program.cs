using System;
using System.Collections.Generic;
using System.Linq;

namespace _11KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGun = int.Parse(Console.ReadLine());

            int[] bullet = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int valueOfInteligence = int.Parse(Console.ReadLine());

            Stack<int> stackOfBullets = new Stack<int>(bullet);
            Queue<int> queueOfLocks = new Queue<int>(locks);

            int count = 0;
            int usedBullets = 0;

            while (stackOfBullets.Count > 0 && queueOfLocks.Count > 0)
            {
                if (stackOfBullets.Peek() <= queueOfLocks.Peek())
                {
                    Console.WriteLine("Bang!");

                    stackOfBullets.Pop();
                    queueOfLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    stackOfBullets.Pop();
                }

                count++;

                if (count == sizeOfGun && stackOfBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }
                usedBullets++;
            }

            if (stackOfBullets.Count >= 0 && queueOfLocks.Count == 0)
            {
                int earned = valueOfInteligence - (usedBullets * priceOfBullet);
                Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${earned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueOfLocks.Count}");
            }
        }
    }
}
