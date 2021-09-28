using System;

namespace _05Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();

            string pass = "";

            for (int i = user.Length -1; i >+ 0; i--)
            {
                pass += user[i];
            }

            bool isLoggedIn = false;
            bool isBlocked = false;
            
            int attemps = 0;

            while (!isLoggedIn && !isBlocked)
            {
                string inputPass = Console.ReadLine();

                if (inputPass == pass)
                {
                    Console.WriteLine($"User {user} logged in.");
                    isLoggedIn = true;
                }
                else
                {
                    attemps += 1;
                    
                    if (attemps == 4)
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
