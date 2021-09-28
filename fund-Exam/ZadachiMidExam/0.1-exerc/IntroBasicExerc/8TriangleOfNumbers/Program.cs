using System;

namespace _8TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());

            for (short row = 1; row <= n; row++)
            {
                for (short col = 1; col <= row; col++)
                {
                    Console.Write(row + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
