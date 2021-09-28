using System;
using System.Linq;

namespace World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string travel = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] tokens = input.Split(':');
                string command = tokens[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);
                    string stop = tokens[2];

                    if (index >= 0 && index < travel.Length)
                    {
                        travel = travel.Insert(index, stop);
                    }
                    Console.WriteLine(travel);
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    if (startIndex >= 0 && startIndex < travel.Length && endIndex >= 0 && endIndex < travel.Length)
                    {
                        int count = endIndex - startIndex + 1;
                        travel = travel.Remove(startIndex, count);
                    }
                    Console.WriteLine(travel);
                }
                else if (command == "Switch")
                {
                    string oldStop = tokens[1];
                    string newStop = tokens[2];

                    if (travel.Contains(oldStop))
                    {
                        travel = travel.Replace(oldStop, newStop);
                    }
                    Console.WriteLine(travel);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {travel}");
        }
    }
}