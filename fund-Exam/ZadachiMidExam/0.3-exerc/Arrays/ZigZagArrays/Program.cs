using System;
using System.Linq;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int[] first = new int[lines];
            int[] second = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                int[] number = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int firstNumber = number[0];
                int secondNumber = number[1];

                if (i % 2 == 0)
                {
                    first[i] = firstNumber;
                    second[i] = secondNumber;
                }
                else
                {
                    first[i] = secondNumber;
                    second[i] = firstNumber;
                }
            }

            Console.WriteLine(string.Join(" ",first));
            Console.WriteLine(string.Join(" ",second));
        }
    }
}
