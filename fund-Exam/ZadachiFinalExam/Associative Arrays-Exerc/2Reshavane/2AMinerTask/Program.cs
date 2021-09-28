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
                string mats = Console.ReadLine();
                

                if (mats == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (mined.ContainsKey(mats))
                {
                    mined[mats] += quantity;
                }
                else
                {
                    mined.Add(mats, quantity);
                }
            }
            foreach (var mine in mined)
            {
                Console.WriteLine($"{mine.Key} -> {mine.Value}");
            }
        }
    }
}
