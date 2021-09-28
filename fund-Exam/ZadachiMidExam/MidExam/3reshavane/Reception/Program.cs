using System;

namespace Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int efficiency1 = int.Parse(Console.ReadLine());
            int efficiency2 = int.Parse(Console.ReadLine());
            int efficiency3 = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            int hours = 0;
            int totalEfficiency = efficiency1 + efficiency2 + efficiency3;

            while (true)
            {
                if (students <= 0)
                {
                    break;
                }
                hours++;

                if (hours % 4 == 0)
                {
                    continue;
                }
                else
                {
                    students -= totalEfficiency;
                }

            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
