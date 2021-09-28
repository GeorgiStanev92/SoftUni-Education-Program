using System;

namespace _07WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int tankLitters = 255;
            int tankValue = 0;

            for (int i = 0; i < lines; i++)
            {
                int litters = int.Parse(Console.ReadLine());
                

                if (tankValue + litters > tankLitters)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    tankValue += litters;
                }
            }
            Console.WriteLine(tankValue);



        }
    }
}
