using System;

namespace _1ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var username in usernames)
            {
                if (isValid(username))
                {
                    Console.WriteLine(username);
                }
            }
        }

        private static bool isValid(string username)
        {
            return isValidLenght(username) && containsValidSymbols(username);
        }

        private static bool containsValidSymbols(string username)
        {
            foreach (char letter in username)
            {
                if (!char.IsLetterOrDigit(letter) && letter != '-' && letter != '_')
                {
                    return false;
                }
            }
            return true;
        }

        private static bool isValidLenght(string username)
        {
            return username.Length >= 3 && username.Length <= 16;
        }
    }
}
