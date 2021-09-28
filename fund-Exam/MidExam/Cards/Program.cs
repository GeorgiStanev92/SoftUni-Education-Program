using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Ready")
                {
                    break;
                }

                string[] command = line.Split();

                if (command[0] == "Add")
                {
                    string card = command[1];

                    if (!cards.Contains(card))
                    {
                        Console.WriteLine("Card not found.");
                    }
                    else
                    {
                        cards.Add(card);
                    }
                }
                else if (command[0] == "Insert")
                {
                    string card = command[1];
                    int idx = int.Parse(command[2]);

                    if (cards.Contains(card) && idx >= 0 && idx < cards.Count)
                    {
                        cards.Insert(idx, card);
                    }
                    else
                    {
                        Console.WriteLine("Error!");      
                    }
                }
                else if (command[0] == "Remove")
                {
                    string card = command[1];

                    if (cards.Contains(card))
                    {
                        cards.Remove(card);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command[0] == "Swap")
                {  
                    string card1 = command[1];
                    string card2 = command[2];

                    card1 = card1 + card2;
                    card2 = card1.Substring(card1.Length - card2.Length);
                    card1 = card2.Substring(card2.Length);
 
                }
                else if (command[0] == "Shuffle")
                {
                    cards.Reverse();
                }
            }
            Console.WriteLine(string.Join(" ", cards));
        }
    }
}
