﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _4ListOperations
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

                string[] parts = line.Split();
                string commnad = parts[0];

                if (commnad == "Add")
                {
                    int number = int.Parse(parts[1]);
                    numbers.Add(number);
                }
                else if (commnad == "Insert")
                {
                    int number = int.Parse(parts[1]);
                    int idx = int.Parse(parts[2]);

                    if (!IsValid(idx, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(idx, number);
                }
                else if (commnad == "Remove")
                {
                    int idx = int.Parse(parts[1]);

                    if (!IsValid(idx, numbers))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.RemoveAt(idx);
                }
                else if (commnad == "Shift")
                {
                    string direction = parts[1];
                    int count = int.Parse(parts[2]);

                    if (direction == "left")
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

        private static bool IsValid(int idx, List<int> numbers)
        {
            return idx >= 0 && idx < numbers.Count;
        }
    }
}
