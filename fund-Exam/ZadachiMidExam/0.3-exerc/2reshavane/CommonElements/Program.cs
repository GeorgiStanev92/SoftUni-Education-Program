using System;
using System.Linq;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] input2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var firstElement in input1)
            {
                foreach (var secondElement in input2)
                {
                    if (firstElement == secondElement)
                    {
                        Console.Write($"{secondElement} ");
                    }
                }
            }
        }
    }
}
