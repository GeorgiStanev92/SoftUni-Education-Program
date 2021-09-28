using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] itemQuality = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            Dictionary<string, Dictionary<string, long>> summuryWin = new Dictionary<string, Dictionary<string, long>>
            {
                {"GOLD", new Dictionary<string, long>()},
                {"GEM", new Dictionary<string, long>()},
                {"CASH", new Dictionary<string, long>()}
            };


            long currentCapacity = 0;

            for (int i = 0; i < itemQuality.Length; i++)
            {
                string upperInput = itemQuality[i].ToUpper();

                if (i % 2 == 0)
                {
                    if (upperInput.Length <= 2)
                    {
                        continue;
                    }
                    if (upperInput == "GOLD")
                    {
                        var quantity = long.Parse(itemQuality[i + 1]);

                        if (currentCapacity + quantity > bagCapacity)
                        {
                            break;
                        }

                        currentCapacity += quantity;


                        if (!summuryWin["GOLD"].ContainsKey(itemQuality[i]))
                        {
                            summuryWin["GOLD"].Add(itemQuality[i], 0);
                        }
                        summuryWin["GOLD"][itemQuality[i]] += quantity;

                    }
                    else if (upperInput.Length == 3)
                    {
                        var quantity = long.Parse(itemQuality[i + 1]);
                        if (summuryWin["GEM"].Values.Sum() >= summuryWin["CASH"].Values.Sum() + quantity)
                        {

                            if (currentCapacity + quantity > bagCapacity)
                            {
                                break;
                            }

                            currentCapacity += quantity;


                            if (!summuryWin["CASH"].ContainsKey(itemQuality[i]))
                            {
                                summuryWin["CASH"].Add(itemQuality[i], 0);
                            }
                            summuryWin["CASH"][itemQuality[i]] += quantity;
                        }
                    }
                    else if (upperInput.EndsWith("GEM") && upperInput.Length >= 4)
                    {
                        var quantity = long.Parse(itemQuality[i + 1]);
                        if (summuryWin["GOLD"].Values.Sum() >= summuryWin["GEM"].Values.Sum() + quantity)
                        {
                            if (currentCapacity + quantity > bagCapacity)
                            {
                                break;
                            }
                            currentCapacity += quantity;


                            if (!summuryWin["GEM"].ContainsKey(itemQuality[i]))
                            {
                                summuryWin["GEM"].Add(itemQuality[i], 0);
                            }
                            summuryWin["GEM"][itemQuality[i]] += quantity;

                        }
                    }
                }
            }

            foreach (var type in summuryWin.OrderByDescending(x => x.Value.Values.Sum()))
            {
                if (type.Key == "GOLD")
                {
                    if (type.Value.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine($"<Gold> ${type.Value.Values.Sum()}");

                    foreach (var item in type.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                    {
                        Console.WriteLine($"##{item.Key} - {item.Value}");
                    }
                }
                else if (type.Key == "GEM")
                {
                    if (type.Value.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine($"<Gem> ${type.Value.Values.Sum()}");

                    foreach (var item in type.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                    {
                        Console.WriteLine($"##{item.Key} - {item.Value}");
                    }
                }
                else if (type.Key == "CASH")
                {
                    if (type.Value.Count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine($"<Cash> ${type.Value.Values.Sum()}");

                    foreach (var item in type.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                    {
                        Console.WriteLine($"##{item.Key} - {item.Value}");
                    }
                }
            }
        }

    }
}