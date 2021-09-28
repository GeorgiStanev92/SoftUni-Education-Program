using System;
using System.Linq;
using System.Text;

namespace _5MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = byte.Parse(Console.ReadLine());

            int reminder = 0;

            StringBuilder result = new StringBuilder();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (multiplier == 0)
                {
                    Console.WriteLine(0);
                    break;
                }
                int digit = number[i] - '0';

                reminder += digit * multiplier;

                if (reminder > 9)
                {
                    int remainderLastDigit = reminder % 10;
                    reminder /= 10;

                    result.Append(remainderLastDigit.ToString());
                }
                else
                {
                    result.Append(reminder.ToString());
                    reminder = 0;
                }
            }
            if (reminder > 0)
            {
                result.Append(reminder.ToString());
            }
            Console.WriteLine(string.Concat(result.ToString().Reverse()));
        }
    }
}
