using System;
using System.Collections.Generic;
using System.Linq;

namespace Third2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guestMenu = 
                new Dictionary<string, List<string>>();
            int unlikeMeals = 0;

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Stop")
                {
                    break;
                }

                string[] parts = line.Split('-', StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                string guest = parts[1];
                string meal = parts[2];

                if (command == "Like")
                {
                    if (!guestMenu.ContainsKey(guest))
                    {
                        guestMenu.Add(guest, new List<string> { meal });
                    }
                    if (!guestMenu[guest].Contains(meal))
                    {
                        guestMenu[guest].Add(meal);
                    }
                }
                else
                {
                    if (!guestMenu.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else if (!guestMenu[guest].Contains(meal))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                    }
                    else
                    {
                        guestMenu[guest].Remove(meal);
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                        unlikeMeals++;
                    }
                }
            }

            Dictionary<string, List<string>> sorted = guestMenu
                .OrderByDescending(g => g.Value.Count)
                .ThenBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Value);

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key}: {string.Join(", ", item.Value)}");
            }
            Console.WriteLine($"Unliked meals: {unlikeMeals}");
        }
    }
}
