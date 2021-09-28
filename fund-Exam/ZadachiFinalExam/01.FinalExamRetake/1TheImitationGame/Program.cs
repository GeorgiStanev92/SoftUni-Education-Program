using System;

namespace _1TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();
            

            while (command != "Decode")
            {
                string[] tokens = command.Split("|", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Move")
                {
                    int characterCount = int.Parse(tokens[1]);
                    string characters = message.Substring(0, characterCount);
                    message = message.Substring(characterCount) + characters;
                }
                else if (tokens[0] == "Insert")
                {
                    int idx = int.Parse(tokens[1]);
                    message = message.Insert(idx, tokens[2]);
                }
                else if (tokens[0] == "ChangeAll")
                {
                    while (message.Contains(tokens[1]))
                    {
                        message = message.Replace(tokens[1], tokens[2]);
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
