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

                string[] commnad = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commnad[0] == "swap")
                {
                    int index1 = int.Parse(commnad[1]);
                    int index2 = int.Parse(commnad[2]);

                    int oldindex = numbers[index1];
                    numbers[index1] = numbers[index2];
                    numbers[index2] = oldindex;
                }
                else if (commnad[0] == "multiply")
                {
                    int index1 = int.Parse(commnad[1]);
                    int index2 = int.Parse(commnad[2]);

                    numbers[index1] *= numbers[index2];
                }
                else if (commnad[0] == "decrease")
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
