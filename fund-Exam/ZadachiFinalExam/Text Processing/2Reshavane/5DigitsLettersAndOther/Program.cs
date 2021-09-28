using System;
using System.Text;

namespace _5DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder numbers = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder others = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (char.IsDigit(symbol))
                {
                    numbers.Append(symbol);
                }
                else if (char.IsLetter(symbol))
                {
                    letters.Append(symbol);
                }
                else
                {
                    others.Append(symbol);
                }
            }
            Console.WriteLine($"{numbers}\n{letters}\n{others}");
        }
    }
}
