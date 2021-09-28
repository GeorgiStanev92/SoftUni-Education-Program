using System;

namespace _4PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                PrintNumbers(i);
            }

            for (int j = num -1; j > 0; j--)
            {
                PrintNumbers(j);
            }
        }

        static void PrintNumbers(int limit) 
        {
            for (int i = 1; i <= limit; i++)
            {
                Console.Write($"{i} ");
            }
            
            Console.WriteLine();
        }
    }
}
