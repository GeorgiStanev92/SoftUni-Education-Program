using System;
using System.Linq;
using System.Collections.Generic;

namespace second
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] friends = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int blackListCount = 0;
            int lostCount = 0;
            List<string> blackListed = new List<string>();
            List<string> losted = new List<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Report")
                {
                    break;
                }

                string[] command = line.Split();

                if (command[0] == "Blacklist")
                {
                    string name = command[1];

                    if (friends.Contains(name))
                    {
                        Console.WriteLine($"{name} was blacklisted.");
                        blackListCount++;
                        blackListed.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (command[0] == "Error")
                {
                    int idx = int.Parse(command[1]);
                    string name = friends[idx];

                    if (!(blackListed.Contains(name) || losted.Contains(name)))
                    {
                        losted.Add(name);
                        Console.WriteLine($"{name} was lost due to an error.");
                        lostCount++;
                    }
                }
                else if (command[0] == "Change")
                {
                    int idx = int.Parse(command[1]);
                    string newName = command[2];

                    if (idx >= 0 && idx < friends.Length)
                    {
                        string oldName = friends[idx];
                        friends[idx] = newName;

                        Console.WriteLine($"{oldName} changed his username to {newName}. ");
                    }
                }
            }
            Console.WriteLine($"Blacklisted names: {blackListCount} ");
            Console.WriteLine($"Lost names: {lostCount} ");
            Console.WriteLine(string.Join(" ", friends));
        }
    }
}
