using System;

namespace _09PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            int lightsabersCount = (int)Math.Ceiling(students * 1.1);
            int beltsCount = students - students / 6;

            double totalPrice = lightsabersPrice * lightsabersCount + robesPrice * students + beltPrice * beltsCount;

            if (money >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice - money):F2}lv more.");
            }
        }
    }
}
