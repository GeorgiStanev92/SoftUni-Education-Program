using System;
using System.Text;

namespace _5DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder nums = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder others = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char chartext = text[i];

                if (char.IsDigit(chartext))
                {
                    nums.Append(chartext);
                }
                else if (char.IsLetter(chartext))
                {
                    letters.Append(chartext);
                }
                //else if (char.IsPunctuation(chartext))
                //{
                  //  others.Append(chartext);
                //}
                else
                {
                    others.Append(chartext);
                }
            }
            Console.WriteLine($"{nums}\n{letters}\n{others}");
        }
    }
}
