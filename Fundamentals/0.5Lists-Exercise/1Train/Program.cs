using System;
using System.Collections.Generic;
using System.Linq;

namespace _2ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int capacityWagon = int.Parse(Console.ReadLine());

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
                    int passengers = int.Parse(parts[1]);

                    wagons.Add(passengers);
                }
                else
                {
                    int passengers = int.Parse(parts[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int currentWagon = wagons[i];

                        if (currentWagon + passengers <= capacityWagon)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
