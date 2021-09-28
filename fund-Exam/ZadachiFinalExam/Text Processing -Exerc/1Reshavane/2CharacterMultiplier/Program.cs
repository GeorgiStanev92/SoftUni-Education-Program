using System;

namespace _2CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split();

            int result = MultiplyWords(text[0], text[1]);

            Console.WriteLine(result);
        }

        private static int MultiplyWords(string first, string second)
        {
            int minLenght = Math.Min(first.Length, second.Length);

            int sum = 0;

            for (int i = 0; i < minLenght; i++)
            {
                sum += first[i] * second[i];
            }
            if (first.Length > second.Length)
            {
                sum += SumRemainingChars(first, minLenght);
            }
            else if (first.Length < second.Length)
            {
                sum += SumRemainingChars(second, minLenght);
            }
            return sum;
        }

        private static int SumRemainingChars(string word, int idx)
        {
            int sum = 0;
            for (int i = idx; i < word.Length; i++)
            {
                sum += word[i];
            }
            return sum;
        }
    }
}
