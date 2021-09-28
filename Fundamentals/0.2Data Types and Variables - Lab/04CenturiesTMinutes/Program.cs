using System;
using System.Numerics;

namespace _04CenturiesTMinutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            long years = centuries * 100;
            long days = (long)Math.Truncate(years * 365.2422);
            long hours = days * 24;
            BigInteger minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
