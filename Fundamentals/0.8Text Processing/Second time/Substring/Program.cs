using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string remove = Console.ReadLine();

            string words = Console.ReadLine();

            while (words.Contains(remove))
            {
                int idx = words.IndexOf(remove);
                words = words.Remove(idx, remove.Length);
            }
            Console.WriteLine(words);
        }
    }
}
