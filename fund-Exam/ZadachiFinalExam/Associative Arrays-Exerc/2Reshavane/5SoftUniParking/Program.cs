using System;
using System.Collections.Generic;

namespace _5SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registerUser = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();

                string command = commands[0];
                
                if (command == "register")
                {
                    string username = commands[1];
                    string plateNumber = commands[2];

                    if (!registerUser.ContainsKey(username))
                    {
                        registerUser.Add(username, plateNumber);
                        Console.WriteLine($"{username} registered {plateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plateNumber}");
                    }
                }
                else
                {
                    string username = commands[1];

                    if (registerUser.ContainsKey(username))
                    {
                        registerUser.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }
            foreach (var user in registerUser)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
