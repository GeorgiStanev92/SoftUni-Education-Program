using System;
using System.Text;

namespace _7StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            int bomb = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char symbol = line[i];

                if (symbol == '>')
                {
                    bomb += line[i + 1] - '0';
                    result.Append(symbol);
                }
                else if (bomb > 0)
                {
                    bomb--;
                }
                else
                {
                    result.Append(symbol);
                }
            }
            Console.WriteLine(result);
        }
    }
}
