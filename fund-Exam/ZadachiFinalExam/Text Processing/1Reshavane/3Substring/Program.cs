using System;

namespace _3Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(word))
            {
                int idx = text.IndexOf(word);
                text = text.Remove(idx, word.Length);
            }
            Console.WriteLine(text);
        }
    }
}
