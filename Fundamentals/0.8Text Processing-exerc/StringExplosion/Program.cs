using System;
using System.Text;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string filed = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            int bomb = 0;

            for (int i = 0; i < filed.Length; i++)
            {
                char symbol = filed[i];

                if (symbol == '>')
                {
                    bomb += filed[i + 1] - '0';
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
