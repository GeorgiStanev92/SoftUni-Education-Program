using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int element = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                {
                    int idx = i - 1;
                    numbers[idx] = numbers[i];
                }
                numbers[numbers.Length - 1] = element;
            }
            foreach (var element in numbers)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
