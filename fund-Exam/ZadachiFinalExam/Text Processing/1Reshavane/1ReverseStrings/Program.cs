using System;

namespace _1ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (line != "end")
            {
                string result = string.Empty;

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    result += line[i];
                    
                }
                Console.WriteLine($"{line} = {result}");
                line = Console.ReadLine();
            }
        }
    }
}
