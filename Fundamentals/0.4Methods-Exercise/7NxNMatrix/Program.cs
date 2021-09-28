using System;

namespace _7NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Matrix(num);
        }

        private static void Matrix(int num)
        {
            for (int row = 0; row < num; row++)
            {
                for (int col = 0; col < num; col++)
                {
                    Console.Write($"{num} ");
                }

                Console.WriteLine();
            }
        }
    }
}
