using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int[] train = new int[n];

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int people = int.Parse(Console.ReadLine());

                sum += people;
                train[i] = people;
            }
            Console.WriteLine(string.Join(" ", train));
            Console.WriteLine(sum);
        }
    }
}
