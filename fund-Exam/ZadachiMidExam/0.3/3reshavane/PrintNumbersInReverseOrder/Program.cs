using System;
using System.Linq;

namespace PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int[] numbers = new int[input];

            for (int i = 0; i < input; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers[i] = number;
            }

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
