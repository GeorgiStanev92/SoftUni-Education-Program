using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> legenderyItems = new Dictionary<string, int> 
            {
                {"shards", 0 },
                {"fragments", 0 },
                {"motes", 0 },
            };

            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();

            bool isRunning = true;
            string winnerItem = string.Empty;

            while (isRunning)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < parts.Length; i += 2)
                {
                    int quantity = int.Parse(parts[i]);
                    string mats = parts[i + 1].ToLower();

                    if (legenderyItems.ContainsKey(mats))
                    {
                        legenderyItems[mats] += quantity;

                        if (legenderyItems[mats] >= 250)
                        {
                            winnerItem = mats;
                            legenderyItems[mats] -= 250;
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
            if (winnerItem == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (winnerItem == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (winnerItem == "motes")
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            Dictionary<string, int> sortedLegenderyItems = legenderyItems
                .OrderByDescending(i => i.Value)
                .ThenBy(i => i.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sortedLegenderyItems)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

           // Dictionary<string, int> sortedJunk = junk
               // .OrderBy(i => i.Key)
               // .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in junk)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
