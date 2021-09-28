using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                string[] parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "Add")
                {
                    int numberAdd = int.Parse(parts[1]);
                    numbers.Add(numberAdd);
                }
                else if (parts[0] == "Remove")
                {
                    int numberRemove = int.Parse(parts[1]);
                    numbers.Remove(numberRemove);
                }
                else if (parts[0] == "RemoveAt")
                {
                    int numberRemoveAt = int.Parse(parts[1]);
                    numbers.RemoveAt(numberRemoveAt);
                }
                else if (parts[0] == "Insert")
                {
                    int numberInsert = int.Parse(parts[1]);
                    int indexInsert = int.Parse(parts[2]);
                    numbers.Insert(indexInsert, numberInsert);
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
