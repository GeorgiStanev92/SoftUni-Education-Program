using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int count = 0;
            int originPower = power;

            while (power >= distance)
            {
                power -= distance;
                count += 1;

                if (power == originPower / 2 && exhaustionFactor > 0)
                {
                    power /= exhaustionFactor;
                }
            }

            Console.WriteLine(power);
            Console.WriteLine(count);
        }
    }
}
