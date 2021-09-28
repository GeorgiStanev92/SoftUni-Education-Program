using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, double> rarityByPlant = new Dictionary<string, double>();

            Dictionary<string, List<double>> ratingByPlant = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine().Split("<->");

                string plantName = parts[0];
                double rarity = double.Parse(parts[1]);

                rarityByPlant[plantName] = rarity;

                if (!ratingByPlant.ContainsKey(plantName))
                {
                    ratingByPlant[plantName] = new List<double>();
                }
            }
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Exhibition")
                {
                    break;
                }

                string[] commandParts = line.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandParts[0];

                if (command == "Rate")
                {
                    string[] arg = commandParts[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    if (arg.Length != 2)
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    string plant = arg[0];
                    double rating = double.Parse(arg[1]);

                    if (!ratingByPlant.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    ratingByPlant[plant].Add(rating);
                }
                else if (command == "Reset")
                {
                    string plant = commandParts[1];

                    if (!ratingByPlant.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    ratingByPlant[plant].Clear();
                }
                else if (command == "Update")
                {
                    string[] arg = commandParts[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                    if (arg.Length != 2)
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    string plant = arg[0];
                    double newRarity = double.Parse(arg[1]);

                    if (!rarityByPlant.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    rarityByPlant[plant] = newRarity;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

           Dictionary<string,double> sorted = rarityByPlant
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x =>
                {
                    List<double> ratings = ratingByPlant[x.Key];

                    if (ratings.Count == 0)
                    {
                        return 0;
                    }
                    return ratings.Average();
                })
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in sorted)
            {
                string plantName = plant.Key;
                double rarity = plant.Value;
                double rating = 0;

                List<double> ratings = ratingByPlant[plant.Key];

                if (ratings.Count != 0)
                {
                    rating = ratings.Average();
                }

                Console.WriteLine($"- {plantName}; Rarity: {rarity}; Rating: {rating:F2}");
            }
        }
    }
}
