using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int multiplier = int.Parse(Console.ReadLine());

            
            int remainder = 0;

            //List<string> result = new List<string>();

            StringBuilder sv = new StringBuilder();

            for (int i = number.Length - 1; i >= 0; i--)
            {
                if (multiplier == 0)
                {
                    Console.WriteLine(0);
                    break;
                }
                int digit = number[i] - '0';

                remainder += digit * multiplier;

                if (remainder > 9)
                {
                    int remainderLastDigit = remainder % 10;
                    remainder /= 10;

                    //result.Add(remainderLastDigit.ToString());

                    sv.Append(remainderLastDigit.ToString());
                }
                else
                {
                    // result.Add(remainder.ToString());
                    sv.Append(remainder.ToString());

                    remainder = 0;
                }
            }

            if (remainder > 0)
            {
                //result.Add(remainder.ToString());

                sv.Append(remainder.ToString());
            }

            //result.Reverse();

            //Console.WriteLine(string.Join(string.Empty, result));

            Console.WriteLine(string.Concat(sv.ToString().Reverse()));
        }
    }
}
