using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            
            int tankCapacity = 255;

            int capacity = 0;

            for (int i = 0; i < lines; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (capacity + liters > tankCapacity)
                {
                    Console.WriteLine("Insufficient capacity!");    
                }
                else
                {
                    capacity += liters;
                }
            }
            Console.WriteLine(capacity);
        }
    }
}
