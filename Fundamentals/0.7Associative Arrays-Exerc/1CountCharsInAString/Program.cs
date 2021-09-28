using System;

namespace _1CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }using System;
using System.Collections.Generic;

namespace _2AMinerTask
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<char, int> counts = new Dictionary<char, int>();

                string word = Console.ReadLine();

                foreach (char letter in word)
                {
                    if (letter == ' ')
                    {
                        continue;
                    }

                    if (counts.ContainsKey(letter))
                    {
                        counts[letter] += 1;
                    }
                    else
                    {
                        counts.Add(letter, 1);
                    }
                }
                foreach (var kvp in counts)
                {
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }

}
}
