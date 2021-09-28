using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line.Split();

                if (parts.Length == 2)
                {
                    int passenger = int.Parse(parts[1]);

                    wagons.Add(passenger);
                }
                else
                {
                    int passenger = int.Parse(parts[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int currentWagon = wagons[i];

                        if (currentWagon + passenger <= maxCapacity)
                        {
                            wagons[i] += passenger;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
