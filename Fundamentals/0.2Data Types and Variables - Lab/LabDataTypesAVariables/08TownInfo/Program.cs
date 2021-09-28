using System;

namespace _08TownInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            double km = double.Parse(Console.ReadLine());

            Console.WriteLine($"Town {town} has population of {population} and area {km} square km.");
        }
    }
}
