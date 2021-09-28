using System;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Done")
                {
                    break;
                }

                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "Change")
                {
                    string letter = parts[1];
                    string replacement = parts[2];
                    text = text.Replace(letter, replacement);
                    Console.WriteLine(text);
                }
                else if (command == "Includes")
                {
                    string include = parts[1];

                    if (text.Contains(include))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "End")
                {
                    string end = parts[1];

                    if (text.EndsWith(end))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (command == "FindIndex")
                {
                    string letter = parts[1];

                    int idx = text.IndexOf(letter);

                    Console.WriteLine(idx);
                }
                else if (command == "Cut")
                {
                    int idx = int.Parse(parts[1]);
                    int lenght = int.Parse(parts[2]);
                    string newText = text.Substring(idx, lenght);
                    text = text.Remove(0, text.Length);
                    text = newText;
                    Console.WriteLine(text);
                }
            }
        }
    }
}
