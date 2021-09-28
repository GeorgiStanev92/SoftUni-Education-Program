using System;
using System.Linq;

namespace Problem_1._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {

            string word = Console.ReadLine();
            string input = string.Empty;


            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] parts = input.Split(":|:");
                string command = parts[0];


                if (command == "InsertSpace")
                {
                    int index = int.Parse(parts[1]);
                    int wordLength = word.Length;

                    string line1 = word.Substring(0, index);
                    string line2 = word.Substring(index);

                   // word = line1 + " " + line2;
                    word = word.Insert(index, " ");
                    Console.WriteLine(word);
                }
                else if (command == "Reverse")
                {
                    string substr = parts[1];

                    if (word.Contains(substr))
                    {
                        string reversedSubstr = string.Empty;
                        int index = word.IndexOf(substr);

                        word = word.Remove(index, substr.Length);

                        for (int i = substr.Length - 1; i >= 0; i--)
                        {
                            reversedSubstr += substr[i];
                        }

                        word += reversedSubstr;
                        // тука добавяш обърнатия текст и си отива отзад
                        Console.WriteLine(word);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substr = parts[1];
                    string newSubstr = parts[2];

                    word = word.Replace(substr, newSubstr);
                    Console.WriteLine(word);
                }
            }
            Console.WriteLine($"You have a new text message: {word}");
        }
    }
}