using System;

namespace _5AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirsNum = int.Parse(Console.ReadLine());

            int sum = Sum(firstNum, secondNum);
            int diff = Subtract(sum, thirsNum);

            Console.WriteLine(diff);
        }

        private static int Subtract(int first, int second)
        {
            return first - second;
        }

        private static int Sum(int first, int second)
        {
            return first + second;
        }
    }
}
