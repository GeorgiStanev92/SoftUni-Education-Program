using System;
using System.Linq;

namespace ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
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

                string[] parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "swap")
                {
                    int firstElement = int.Parse(parts[1]);
                    int secondElement = int.Parse(parts[2]);

                    int tempNumber = arr[firstElement];
                    arr[firstElement] = arr[secondElement];
                    arr[secondElement] = tempNumber;
                }
                else if (parts[0] == "multiply")
                {
                    int firstElement = int.Parse(parts[1]);
                    int secondElement = int.Parse(parts[2]);

                    arr[firstElement] *= arr[secondElement];
                }
                else if (parts[0] == "decrease")
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] -= 1;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
