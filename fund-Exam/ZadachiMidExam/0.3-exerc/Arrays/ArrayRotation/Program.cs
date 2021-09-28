using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int rotations = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < rotations; rotation++)
            {
                string firstElement = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                {
                    int prevIndex = i - 1;
                    numbers[prevIndex] = numbers[i];
                }

                numbers[numbers.Length - 1] = firstElement;
            }

            foreach (var element in numbers)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
