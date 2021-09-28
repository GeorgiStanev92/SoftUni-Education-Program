using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();

            string pass = "";
            
            for (int i = user.Length - 1; i >= 0; i--)
            {
                pass += user[i];
            }

            bool isLoggedIn = false;
            bool isBlocked = false;

            int attempts = 0;

            while (!isLoggedIn && !isBlocked)
            {
                string input = Console.ReadLine();

                if (input == pass)
                {
                    Console.WriteLine($"User {user} logged in.");
                    isLoggedIn = true;
                }
                else
                {
                    attempts += 1;

                    if (attempts == 4)
                    {
                        Console.WriteLine($"User {user} blocked!");
                        isBlocked = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                }
            }
        }
    }
}
