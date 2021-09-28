using System;

namespace _10TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <+ num; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool IsTopNumber(int number)
        {
            return IsDivisibleby(number, 8) && ContainsOddDigit(number);
        }

        private static bool ContainsOddDigit(int number)
        {
            while (number != 0)
            {
                int lastDigit = number % 10;
                
                if (lastDigit % 2 != 0)
                {
                    return true;
                }

                number /= 10;
            }
            return false;
        }

        private static bool IsDivisibleby(int number, int divider)
        {
            int sum = 0;

            while (number != 0)
            {
                int lastDigit = number % 10;
                sum += lastDigit;

                number /= 10;
            }

            return sum % divider == 0;
        }
    }
}
