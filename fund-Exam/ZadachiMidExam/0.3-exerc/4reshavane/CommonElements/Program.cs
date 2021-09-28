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

            foreach (var firstelement in line1)
            {
                foreach (var secondElement in line2)
                {
                    if (firstelement == secondElement)
                    {
                        Console.Write($"{firstelement} ");
                    }
                }
            }
        }
    }
}
