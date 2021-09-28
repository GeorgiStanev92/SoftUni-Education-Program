using System;

namespace _12EvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            while (n % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                n = int.Parse(Console.ReadLine());

                if (n < 0)
                {
                    n = Math.Abs(n);

                    if (n % 2 == 0)
                    {
                        Console.WriteLine($"The number is: {n}");
                    }
                }
                else if (n % 2 == 0)
                {
                    
                    Console.WriteLine($"The number is: {n}");
                }
            }
        }
    }
}
