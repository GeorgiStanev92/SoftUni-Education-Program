using System;

namespace _11MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());


            if (times > 10)
            {
                Console.WriteLine($"{num} X {times} = {num * times}");
                return;
            }
            while (times <= 10) 
            {
                Console.WriteLine($"{num} X {times} = {num * times}");
                times++;
            }
        }
    }
}
