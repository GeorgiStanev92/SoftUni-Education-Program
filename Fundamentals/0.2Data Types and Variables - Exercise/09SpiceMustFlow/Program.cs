using System;

namespace _09SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            if (yield < 100)
            {
                Console.WriteLine(0);
                Console.WriteLine(0);

                return;
            }
            int totalSpice = 0;
            int days = 0;
            
            while (yield >= 100)
            {
                days += 1;
                totalSpice += yield - 26;
                yield -= 10;
            }

            totalSpice -= 26;

            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}
