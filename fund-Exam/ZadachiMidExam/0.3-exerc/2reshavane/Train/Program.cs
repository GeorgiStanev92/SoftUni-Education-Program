using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());

            int sum = 0;
            int[] person = new int[wagons];

            for (int i = 0; i < wagons; i++)
            {
                int people = int.Parse(Console.ReadLine());

                person[i] = people;
                sum += people;
            }
            Console.WriteLine(string.Join(" ", person));
            Console.WriteLine(sum);
        }
    }
}
