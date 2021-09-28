using System;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int rotations = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < rotations; rotation++)
            {
                string firstElement = input[0];

                for (int i = 1; i < input.Length; i++)
                {
                    int prevIndex = i - 1;
                    input[prevIndex] = input[i];
                }
                input[input.Length - 1] = firstElement;
            }
            foreach (var element in input)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
