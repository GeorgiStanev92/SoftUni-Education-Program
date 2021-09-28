using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yields = int.Parse(Console.ReadLine());

            if (yields < 100)
            {
                Console.WriteLine(0);
                Console.WriteLine(0);

                return;
            }

            int totalSpice = 0;
            int days = 0;

            while (yields >= 100)
            {
                days += 1;
                totalSpice += yields - 26;
                yields -= 10;
            }

            totalSpice -= 26;

            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}
