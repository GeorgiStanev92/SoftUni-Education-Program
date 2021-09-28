using System;

namespace _8FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            double firstFactorial = CalculateFactorial(firstNum);
            double secondFactorial = CalculateFactorial(secondNum);

            double result = (double)firstFactorial  / secondFactorial;

            Console.WriteLine($"{result:F2}");


        }

        private static double CalculateFactorial(int number)
        {
            double factorial = 1;

            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
