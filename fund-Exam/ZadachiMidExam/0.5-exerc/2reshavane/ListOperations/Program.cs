using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
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

                if (line == "End")
                {
                    break;
                }

                string[] command = line.Split();

                if (command[0] == "Add")
                {
                    int numberAdd = int.Parse(command[1]);
                    numbers.Add(numberAdd);
                }
                else if (command[0] == "Insert")
                {           
                    int numberInsert = int.Parse(command[1]);
                    int indexInsert = int.Parse(command[2]);

                    if (indexInsert >= 0 && indexInsert < numbers.Count)
                    {
                        numbers.Insert(indexInsert, numberInsert);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    
                }
                else if (command[0] == "Remove")
                {
                    int indexRemove = int.Parse(command[1]);

                    if (indexRemove >= 0 && indexRemove < numbers.Count)
                    {
                        numbers.RemoveAt(indexRemove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }  
                }
                else if (command[0] == "Shift")
                {
                    //string direction = command[1];
                    int count = int.Parse(command[2]);

                    if (command[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int firstElement = numbers[0];

                            numbers.RemoveAt(0);
                            numbers.Add(firstElement);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int lastElement = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, lastElement);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
