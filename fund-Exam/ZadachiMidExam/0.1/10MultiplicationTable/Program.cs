using System;

namespace _10MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                int sum = i * n;
                Console.WriteLine($"{n} X {i} = {sum}");
            }
        }
    }
}
