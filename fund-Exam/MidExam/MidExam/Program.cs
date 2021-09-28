using System;

namespace MidExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuits = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int factory = int.Parse(Console.ReadLine());

            int days = 30; 

            int totalBiscuits = 0;

            while (days > 0)
            {
                if (days % 3 == 0)
                {
                    int discount = (int)Math.Ceiling(biscuits * workers* 0.75);
                    totalBiscuits += discount;
                }
                else
                {
                    int count = biscuits * workers;
                    totalBiscuits += count;
                }
                days--;
                
            }

            double diff = Math.Abs(totalBiscuits - factory);

            double percent = diff / factory * 100;

            Console.WriteLine($"You have produced {totalBiscuits} biscuits for the past month.");

            if (totalBiscuits > factory)
            {
                Console.WriteLine($"You produce {percent:F2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {percent:F2} percent less biscuits.");
            }
        }
    }
}
