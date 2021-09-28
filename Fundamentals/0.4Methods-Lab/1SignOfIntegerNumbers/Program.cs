using System;

namespace _1SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string result = SighChecker(num);
            Console.WriteLine(result);
        }

        static string SighChecker(int num) 
        {
            string sigh = null;

            if (num > 0)
            {
                sigh = "positive";

            }
            else if (num < 0)
            {
                sigh = "negative";
            }
            else
            {
                sigh = "zero";
            }

            return $"The number {num} is {sigh}.";
        }
    }
}
