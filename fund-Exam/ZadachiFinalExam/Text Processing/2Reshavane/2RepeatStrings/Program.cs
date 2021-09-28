using System;
using System.Text;

namespace _2RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            StringBuilder text = new StringBuilder();

            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    text.Append(word);
                }
            }
            Console.WriteLine(string.Join(" ", text));
        }
    }
}
