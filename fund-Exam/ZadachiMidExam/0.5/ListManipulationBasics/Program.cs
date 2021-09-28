using System;
using System.Linq;
using System.Collections.Generic;

namespace ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Add")
                {
                    int numberAdd = int.Parse(tokens[1]);
                    numbers.Add(numberAdd);                  
                }
                else if (tokens[0] == "Remove")
                {
                    int numberRemove = int.Parse(tokens[1]);
                    numbers.Remove(numberRemove);
                }
                else if (tokens[0] == "RemoveAt")
                {
                    int numberRemoveAt = int.Parse(tokens[1]);
                    numbers.RemoveAt(numberRemoveAt);
                }
                else if (tokens[0] == "Insert")
                {
                    int numberInsert = int.Parse(tokens[1]);
                    int indexInsert = int.Parse(tokens[2]);
                    numbers.Insert(indexInsert, numberInsert);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
