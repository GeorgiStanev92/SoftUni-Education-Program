using System;
using System.Linq;

namespace _5Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string pass = "";

            for (int i = username.Length - 1; i >= 0; i--)
            {
                pass += username[i];
            }

            bool isLogged = false;
            bool isBlocked = false;

            int attempts = 0;

            while (!isBlocked && ! isLogged)
            {
                string input = Console.ReadLine();

                if (input == pass)
                {
                    Console.WriteLine($"User {username} logged in.");
                    isLogged = true;
                }
                else
                {
                    attempts += 1;

                    if (attempts == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
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
