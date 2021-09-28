using System;
using System.Text;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

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
            return isValidLenght(username) && ContainsValidSymbols(username);

        }

        private static bool ContainsValidSymbols(string username)
        {
            foreach (var symbol in username)
            {
                if (!char.IsLetterOrDigit(symbol) && symbol != '_' && symbol != '-')
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
