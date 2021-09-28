using System;
using System.Collections.Generic;
using System.Linq;

namespace _3LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> Legendary = new Dictionary<string, int>()
            {
                {"shards", 0},
                {"motes", 0},
                {"fragments", 0}
            };

            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();

            string weapon = string.Empty;
            bool isRunning = true;

            while (isRunning)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < parts.Length; i+= 2)
                {
                    int quantity = int.Parse(parts[i]);
                    string mats = parts[i + 1].ToLower();

                    if (Legendary.ContainsKey(mats))
                    {
                        Legendary[mats] += quantity;

                        if (Legendary[mats] >= 250)
                        {
                            weapon = mats;
                            Legendary[mats] -= 250;
                            isRunning = false;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(mats))
                        {
                            junk[mats] += quantity;
                        }
                        else
                        {
                            junk.Add(mats, quantity);
                        }
                    }
                }
            }
            if (weapon == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (weapon == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (weapon == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            Dictionary<string, int> sortedLegendary = Legendary
                .OrderByDescending(i => i.Value)
                .ThenBy(i => i.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedLegendary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
