using System;
using System.Collections.Generic;

namespace _1CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> count = new Dictionary<char, int>();

            string words = Console.ReadLine();

            foreach (char letter in words)
            {
                if (letter == ' ')
                {
                    continue;
                }

                if (count.ContainsKey(letter))
                {
                    count[letter]++;
                }
                else
                {
                    count.Add(letter, 1);
                }
            }
            foreach (var word in count)
            {
                Console.WriteLine($"{word.Key} -> {word.Value}");
            }
        }
    }
}
