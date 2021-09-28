using System;

namespace MidExam
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeed = double.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());

            double sum = 0;
            double percent = moneyNeed * 0.25;

            for (int i = 1; i <= month; i++)
            {
                double bonus = sum * 0.25;

                if (i % 4 == 0)
                {
                    sum += bonus;
                }

                if (i % 2 == 1 && i >= 2)
                {
                    sum -= sum * 0.16;
                }
                sum += percent;
            }


            if (sum >= moneyNeed)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {sum - moneyNeed:F2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {moneyNeed - sum:F2}lv. more.");
            }
        }
    }
}
