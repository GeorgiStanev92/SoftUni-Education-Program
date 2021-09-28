using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> bomb = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int bombNumber = bomb[0];
            int bombPower = bomb[1];

            while (true)
            {
                int index = numbers.IndexOf(bombNumber);

                if (index == -1)
                {
                    break;
                }

                int startIndex = index - bombPower;

                if (startIndex < 0)
                {
                    startIndex = 0;
                }
                int count = 2 * bombPower + 1;

                if (count >= numbers.Count - startIndex)
                {
                    count = numbers.Count - startIndex;
                }
                numbers.RemoveRange(startIndex, count);
            }
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}
