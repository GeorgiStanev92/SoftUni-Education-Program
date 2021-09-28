using System;
using System.Linq;

namespace ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < input.Length / 2; i++)
            {
                var oldElement = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = oldElement;
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
