using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mirror_words
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@#])(?<word1>[A-Za-z]{3,})\1{2}(?<word2>[A-Za-z]{3,})\1";
            string text = Console.ReadLine();

            Regex words = new Regex(pattern);
            MatchCollection matchWords = words.Matches(text);

            List<string> validWords = new List<string>();

            foreach (Match item in matchWords)
            {
                string firstWord = item.Groups["word1"].Value;
                string secondWord = item.Groups["word2"].Value;

                string reversed = String.Concat(firstWord.Reverse());

                if (reversed == secondWord)
                {
                    validWords.Add($"{firstWord} <=> {secondWord}");
                }
            }
            if (matchWords.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matchWords.Count} word pairs found!");
            }

            if (validWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ", validWords));
            }
        }
    }
}