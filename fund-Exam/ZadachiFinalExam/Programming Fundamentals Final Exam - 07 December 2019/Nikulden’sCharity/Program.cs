using System;

namespace _02Nikulden
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] command = Console.ReadLine()
                .Split();

            while (true)
            {
                string commandD = command[0];

                if (commandD == "Replace" && input.Length > 0)
                {
                    char oldOne = char.Parse(command[1]);
                    char newOne = char.Parse(command[2]);

                    input = input.Replace(oldOne, newOne);
                    Console.WriteLine(input);
                }
                else if (commandD == "Cut" && input.Length > 0)
                {
                    int startInx = int.Parse(command[1]);
                    int endInx = int.Parse(command[2]);

                    if (startInx >= 0 && endInx >= 0 && endInx <= input.Length - 1)
                    {
                        input = input.Remove(startInx, endInx - startInx + 1);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
                else if (commandD == "Make" && input.Length > 0)
                {
                    if (command[1] == "Upper")
                    {
                        input = input.ToUpper();
                        Console.WriteLine(input);
                    }
                    else if (command[1] == "Lower")
                    {
                        input = input.ToLower();
                        Console.WriteLine(input);
                    }
                }
                else if (commandD == "Check" && input.Length > 0)
                {
                    string checkwith = command[1];
                    if (input.Contains(checkwith))
                    {
                        Console.WriteLine($"Message contains {checkwith}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {checkwith}");
                    }


                }
                else if (commandD == "Sum" && input.Length > 0)
                {
                    int S = int.Parse(command[1]);
                    int E = int.Parse(command[2]);
                    int total = E - S;
                    int totalSum = 0;

                    if (S >= 0 && E <= input.Length - 1)
                    {
                        string Subbed = input.Substring(S, total + 1);

                        for (int i = Subbed.Length - 1; i >= 0; i--)
                        {
                            char ch = Subbed[i];
                            totalSum += ch;
                        }
                        Console.WriteLine(totalSum);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid indexes!");
                    }
                }
                else if (commandD == "Finish")
                {
                    break;
                }

                command = Console.ReadLine()
                        .Split();


            }
        }
    }
}