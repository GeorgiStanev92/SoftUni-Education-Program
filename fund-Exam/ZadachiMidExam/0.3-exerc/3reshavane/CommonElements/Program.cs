using System;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line1 = Console.ReadLine()
                .Split();

            string[] line2 = Console.ReadLine()
                .Split();

            foreach (var secondElement in line1)
            {
                foreach (var firstElement in line2)
                {
                    if (firstElement == secondElement)
                    {
                        Console.Write($"{firstElement} ");
                    }
                }
            }
        }
    }
}
