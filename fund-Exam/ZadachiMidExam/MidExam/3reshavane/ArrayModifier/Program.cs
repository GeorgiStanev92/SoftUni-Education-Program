using System;
using System.Linq;

namespace ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "swap")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);

                    int oldIndex = numbers[index1];
                    numbers[index1] = numbers[index2];
                    numbers[index2] = oldIndex;
                }
                else if (command[0] == "multiply")
                {
                    int index1 = int.Parse(command[1]);
                    int index2 = int.Parse(command[2]);

                    numbers[index1] *= numbers[index2];
                }
                else if (command[0] == "decrease")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] -= 1;
                    }
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
