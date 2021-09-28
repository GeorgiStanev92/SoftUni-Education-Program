using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());

            int[] people = new int[wagons];

            int sum = 0;

            for (int i = 0; i < wagons; i++)
            {
                int count = int.Parse(Console.ReadLine());

                sum += count;
                people[i] = count;
            }
            Console.WriteLine(string.Join(" ",people));
            Console.WriteLine(sum);
        }
    }
}
