using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double bestVolume = 0;
            string bestModel = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height;

                if (volume > bestVolume)
                {
                    bestVolume = volume;
                    bestModel = model;
                }
            }

            Console.WriteLine(bestModel);
        }
    }
}
