using System;

namespace _01ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            decimal kilometters = meters / 1000M;

            Console.WriteLine($"{kilometters:F2}");
        }
    }
}
