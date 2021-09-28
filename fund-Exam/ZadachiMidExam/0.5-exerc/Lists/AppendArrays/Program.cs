using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split('|');

            List<string> result = new List<string>();

            for (int i = arr.Length -1; i > 0; i--)
            {
                string[] elements = arr[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                result.AddRange(elements);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
