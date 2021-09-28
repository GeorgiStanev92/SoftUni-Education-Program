using System;
using System.Text;

namespace _4CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder encryptText = new StringBuilder();

            foreach (char letter in text)
            {
                char encrypterdLetter = (char)(letter + 3);

                encryptText.Append(encrypterdLetter);
            }
            Console.WriteLine(encryptText);
        }
    }
}
