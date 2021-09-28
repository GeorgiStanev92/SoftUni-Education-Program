using System;
using System.Globalization;

class HolidaysBetweenTwoDates
{
    static void Main()
    {
        int startDate = int.Parse(Console.ReadLine());
        int endDate = int.Parse(Console.ReadLine());
        int holidaysCount = 0;

        for (var date = startDate; date <= endDate; date.AddDays(1))
            if (date.DayOfWeek == DayOfWeek.Saturday &&
                date.DayOfWeek == DayOfWeek.Sunday) holidaysCount++;
        Console.WriteLine(holidaysCount);
        for (int i = startDate; i <= endDate; i++)
        {
            if (true)
            {

            }
        }
    }
}
