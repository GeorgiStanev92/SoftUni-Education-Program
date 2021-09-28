using System;

namespace Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();

            //int idx = text.IndexOf(key);

            //while (idx != -1)
            // {
            //    text = text.Remove(idx, key.Length);
            //   idx = text.IndexOf(key);
            // }
            // Console.WriteLine(text);

            // while (text.Contains(key))
            // {
            //     int idx = text.IndexOf(key);
            //     text = text.Remove(idx, key.Length);
            //  }
            //  Console.WriteLine(text);

            while (text.Contains(key))
            {
                text = text.Replace(key, string.Empty);
            }
            Console.WriteLine(text);
        }
    }
}
