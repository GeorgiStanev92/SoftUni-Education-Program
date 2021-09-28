using System;
using System.Collections.Generic;

namespace _5SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, string> users = new Dictionary<string, string>();

            for (int i = 0; i < lines; i++)
            {
                string[] parts = Console.ReadLine().Split();

                string command = parts[0];

                if (command == "register")
                {
                    string username = parts[1];
                    string number = parts[2];

                    if (users.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {number}");
                    }
                    else
                    {
                        users.Add(username, number);

                        Console.WriteLine($"{username} registered {number} successfully");
                    }
                }
                else
                {
                    string username = parts[1];
                    bool removed = users.Remove(username);

                    if (removed)
                    {
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
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
