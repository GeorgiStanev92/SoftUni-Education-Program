using System;

namespace _12RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool isSpecial = false;

            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int digit = i;

                while (i > 0)
                {
                    sum += i % 10;
                    digit /= 10;
                }

                isSpecial = (sum == 5 || sum == 7 || sum == 11);
               
                sum = 0;
                i = digit;

                Console.WriteLine($"{digit} -> {isSpecial}");
                
            }
        }
    }
}
