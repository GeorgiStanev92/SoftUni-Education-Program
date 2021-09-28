using System;
using System.Collections.Generic;

namespace HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int i = 0; i < commands; i++)
            {
                string[] command = Console.ReadLine().Split();
                string name = command[0];

                if (command.Length == 4)
                {
                    bool removed = guests.Remove(name);

                    if (!removed)
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
            }
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }   
    }
}
