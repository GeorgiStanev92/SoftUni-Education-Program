using System;
using System.Linq;

namespace Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int[] number1 = new int[lines];
            int[] number2 = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    number1[i] = numbers[0];
                    number2[i] = numbers[1];
                }
                else
                {
                    number1[i] = numbers[1];
                    number2[i] = numbers[0];
                }
            }
            Console.WriteLine(string.Join(" ", number1));
            Console.WriteLine(string.Join(" ", number2));
        }
    }
}
