using System;
using System.Collections.Generic;

namespace _2AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mined = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (mined.ContainsKey(line))
                {
                    mined[line] += quantity;
                }
                else
                {
                    mined.Add(line, quantity);
                }
            }
            foreach (var mine in mined)
            {
                Console.WriteLine($"{mine.Key} -> {mine.Value}");
            }
        }
    }
}
