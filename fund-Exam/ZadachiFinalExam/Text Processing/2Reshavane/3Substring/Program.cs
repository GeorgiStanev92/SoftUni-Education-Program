using System;

namespace _3Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string remove = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(remove))
            {
                int idx = text.IndexOf(remove);
                text = text.Remove(idx, remove.Length);
            }
            Console.WriteLine(text);
        }
    }
}
