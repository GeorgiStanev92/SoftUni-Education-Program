using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
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
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] command = line.Split();

                if (command[0] == "Delete")
                {
                    int delete = int.Parse(command[1]);
                    numbers.Remove(delete);
                }
                else
                {
                    int insert = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    numbers.Insert(index, insert);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
