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
                string text = Console.ReadLine();

                if (text == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (mined.ContainsKey(text))
                {
                    mined[text] += quantity;
                }
                else
                {
                    mined.Add(text, quantity);
                }
            }
            foreach (var item in mined)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
