using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02_Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string text = @"\A\!([A-Z][a-z]{2,})\!\:\[([a-zA-z]{8,})\]\Z";

            var regex = new Regex(text);

            for (int i = 1; i <= n; i++)
            {
                string message = Console.ReadLine();

                var match = regex.Match(message);

                if (match.Success)
                {
                    string command = match.Groups[1].Value;
                    string addition = match.Groups[2].Value;
                    Console.Write(command + ":" + " ");

                    foreach (var ch in addition)
                    {
                        int result = ch;
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}