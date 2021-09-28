using System;
using System.Collections.Generic;

namespace _5SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = line[0];

                if (command == "register")
                {
                    string name = line[1];
                    string number = line[2];

                    if (!users.ContainsKey(name))
                    {
                        users.Add(name, number);
                        Console.WriteLine($"{name} registered {number} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {number}");
                    }
                }
                else
                {
                    string name = line[1];

                    if (users.ContainsKey(name))
                    {
                        users.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
