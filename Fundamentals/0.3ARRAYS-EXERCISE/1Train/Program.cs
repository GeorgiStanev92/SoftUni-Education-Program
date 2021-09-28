using System;
using System.Linq;

namespace _1Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());

            int[] train = new int[wagons];
            int sum = 0;

            for (int i = 0; i < wagons; i++)
            {
                int people = int.Parse(Console.ReadLine());

                train[i] = people;
                sum += people;
            }

            Console.WriteLine(string.Join(' ', train));
            Console.WriteLine(sum);
        }
    }
}
