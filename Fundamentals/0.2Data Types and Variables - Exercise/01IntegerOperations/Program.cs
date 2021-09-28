using System;

namespace _01IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            long num1 = long.Parse(Console.ReadLine());
            long num2 = long.Parse(Console.ReadLine());
            long num3 = long.Parse(Console.ReadLine());
            long num4 = long.Parse(Console.ReadLine());

            long result = ((num1 + num2) / num3) * num4;

            Console.WriteLine(result);
        }
    }
}
