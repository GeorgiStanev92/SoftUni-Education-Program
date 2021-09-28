using System;
using System.Numerics;

namespace _2BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorail = 1;

            for (int i = 2; i <= n; i++)
            {
                factorail *= i;
            }
            Console.WriteLine(factorail);
        }
    }
}
