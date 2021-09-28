using System;
using System.Linq;
using System.Collections.Generic;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> membersBySide = new Dictionary<string, List<string>>();

            Dictionary<string, string> members = new Dictionary<string, string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Lumpawaroo")
                {
                    break;
                }

                if (line.Contains(" | "))
                {
                    string[] parts = line.Split(" | ");

                    string forceSide = parts[0];
                    string forseUser = parts[1];

                    if (members.ContainsKey(forseUser))
                    {
                        continue;
                    }

                    if (!membersBySide.ContainsKey(forceSide))
                    {
                        membersBySide.Add(forceSide, new List<string>());
                    }

                    membersBySide[forceSide].Add(forseUser);

                    members.Add(forseUser, forceSide);
                }
                else
                {
                    string[] parts = line.Split(" -> ");

                    string forceSide = parts[1];
                    string forseUser = parts[0];

                    if (!membersBySide.ContainsKey(forceSide))
                    {
                        membersBySide.Add(forceSide, new List<string>());
                    }

                    if (members.ContainsKey(forseUser))
                    {
                        string oldSide = members[forseUser];

                        membersBySide[oldSide].Remove(forseUser);
                        membersBySide[forceSide].Add(forseUser);
                        members[forseUser] = forceSide;
                    }
                    else
                    {
                        membersBySide[forceSide].Add(forseUser);
                        members.Add(forseUser, forceSide);


                    }

                    Console.WriteLine($"{forseUser} joins the {forceSide} side!");

                }
            }

            Dictionary<string, List<string>> result = membersBySide
                .Where(s => s.Value.Count > 0)
                .OrderByDescending(s => s.Value.Count)
                .ThenBy(s => s.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in result)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                kvp.Value.Sort();

                foreach (var member in kvp.Value)
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }
    }
}
