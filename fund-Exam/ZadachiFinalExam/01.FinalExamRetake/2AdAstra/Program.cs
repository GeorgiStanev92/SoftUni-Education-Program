using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\||#)([A-Za-z\s]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d{1,4}|10000)\1";
            Regex regex = new Regex (pattern);

            string text = Console.ReadLine();

           // var matches = regex.Matches(text);
             MatchCollection matches = regex.Matches(text);

            int calories = matches
                .Select(m => int.Parse(m.Groups[4].ToString()))
                .Sum();

            Console.WriteLine($"You have food to last you for: {calories / 2000} days!");

            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups[2].Value}, Best before: {match.Groups[3]}, Nutrition: {match.Groups[4].Value}");
            }
            
        }
    }
}
