using System;
using System.Collections.Generic;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> activationKey = new Dictionary<string, string>();

            string text = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Generate")
                {
                    break;
                }

                string[] parts = line.Split(">>>");
                string command = parts[0];

                if (command == "Contains")
                {
                    string contains = parts[1];

                    if (text.Contains(contains))
                    {
                        Console.WriteLine($"{text} contains {contains}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string casing = parts[1];
                    int startIdx = int.Parse(parts[2]);
                    int endIdx = int.Parse(parts[3]);

                    string substr = text.Substring(startIdx, endIdx - startIdx);

                    string replacment = substr.ToUpper();

                    if (casing == "Lower")
                    {
                        replacment = substr.ToLower();
                    }
                    text = text.Replace(substr, replacment);

                    Console.WriteLine(text);
                }
                else if (command == "Slice")
                {
                    int startIdx = int.Parse(parts[1]);
                    int endIdx = int.Parse(parts[2]);

                    text = text.Remove(startIdx, endIdx - startIdx);

                    Console.WriteLine(text);
                }
            }
            Console.WriteLine($"Your activation key is: {text}");
        }
    }
}
