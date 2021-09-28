using System;
using System.Collections.Generic;

namespace _1CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();

            string text = Console.ReadLine();

            foreach (char letter in text)
            {
                if (letter == ' ')
                {
                    continue;
                }
                if (counts.ContainsKey(letter))
                {
                    counts[letter]++;
                }
                else
                {
                    counts.Add(letter, 1);
                }
            }
            foreach (var letter in counts)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}
