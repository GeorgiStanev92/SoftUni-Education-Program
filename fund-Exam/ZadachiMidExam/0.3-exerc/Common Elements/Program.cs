using System;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] input2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var secondElement in input2)
            {
                foreach (var firstElement in input1)
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
