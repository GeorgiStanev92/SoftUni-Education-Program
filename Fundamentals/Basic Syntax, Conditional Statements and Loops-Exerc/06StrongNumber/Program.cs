using System;

namespace _06StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int originNum = num;
            int sum = 0;
            while (num > 0)
            {
                int lastDigit = num % 10;

                int factorial = 1;
                
                for (int i = lastDigit; i >= 1; i--)
                {
                    factorial *= i;
                }

                sum += factorial;
                
                num /= 10;
            }

            if (originNum == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            
            
        }
    }
}
