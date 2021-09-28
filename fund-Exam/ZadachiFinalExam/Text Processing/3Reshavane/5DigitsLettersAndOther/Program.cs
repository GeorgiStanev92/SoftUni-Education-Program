using System;
using System.Text;

namespace _5DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            StringBuilder nums = new StringBuilder();
            StringBuilder chars = new StringBuilder();
            StringBuilder others = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char symbol = line[i];

                if (char.IsLetter(symbol))
                {
                    chars.Append(symbol);
                }
                else if (char.IsDigit(symbol))
                {
                    nums.Append(symbol);
                }
                else if (!char.IsLetterOrDigit(symbol))
                {
                    others.Append(symbol);
                }
            }
            Console.WriteLine($"{nums}\n{chars}\n{others}");
        }
    }
}
