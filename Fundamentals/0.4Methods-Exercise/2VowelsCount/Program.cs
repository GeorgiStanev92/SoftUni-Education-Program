using System;

namespace _2VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int vowelsCount = GetVowelsCount(text);

            Console.WriteLine(vowelsCount);
        }

        private static int GetVowelsCount(string text)
        {
            int count = 0;

            text = text.ToLower();

            foreach (char letter in text)
            {

                if (letter == 'a' ||
                    letter == 'e' ||
                    letter == 'o' ||
                    letter == 'y' ||
                    letter == 'u' ||
                    letter == 'i')
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}
