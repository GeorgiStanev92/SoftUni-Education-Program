using System;
using System.Linq;

namespace _2CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split();
            string[] secondArray = Console.ReadLine().Split();

            foreach (string  secondElement in secondArray)
            {

                foreach (var firstElement in firstArray)
                {
                    
                    if (firstElement == secondElement)
                    {
                        Console.Write($"{ secondElement} ");
                    }
                }
            }
        }
    }
}
