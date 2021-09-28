using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(=|\/)(?<location>[A-Z][A-Za-z]{2,})\1");
            string input = Console.ReadLine();

            MatchCollection cities = regex.Matches(input);

            if (cities.Count == 0)
            {
                Console.WriteLine("Destinations: ");
                Console.WriteLine("Travel Points: 0");
                return;

            }

            int travelPoints = 0;
            foreach (Match item in cities)
            {
                travelPoints += item.Groups[2].Value.Length;
            }

            List<string> output = new List<string>();

            foreach (Match item in cities)
            {
                output.Add(item.Groups[2].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", output)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}





