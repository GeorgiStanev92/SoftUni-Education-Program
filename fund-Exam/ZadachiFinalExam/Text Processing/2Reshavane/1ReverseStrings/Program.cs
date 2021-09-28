using System;

namespace _1ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (text != "end")
            {
                string result = string.Empty;

                for (int i = text.Length - 1; i >= 0; i--)
                {
                    result += text[i];
                }
                Console.WriteLine($"{text} = {result}");
                text = Console.ReadLine();
            }
        }
    }
}
