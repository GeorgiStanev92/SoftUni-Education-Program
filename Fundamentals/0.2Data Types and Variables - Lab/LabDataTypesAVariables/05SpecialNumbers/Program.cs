using System;

namespace _05SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int digits = i;

                for (int j = 0; j < i.ToString().Length; j++)
                {
                    sum += digits % 10;
                    digits /= 10;
                }

                if (sum % 5 == 0 || sum % 7 == 0 || sum % 11 == 10)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
