using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RageQuit
{
    static void Main()
    {
        string input = Console.ReadLine().ToUpper();
        var bigList = new List<char>();
        var currlist = new List<char>();

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            if (!Char.IsNumber(ch))
            {
                currlist.Add(ch);
            }

            if (Char.IsNumber(ch))
            {
                int count = 0;
                if (i < input.Length - 1 && Char.IsNumber(input[i + 1]))
                {
                    string str = input.Substring(i, 2);
                    count = int.Parse(str.ToString());
                }
                else
                {
                    count = int.Parse(ch.ToString());
                }

                if (count > 0)
                {
                    for (int j = 0; j < count; j++)
                    {
                        bigList.AddRange(currlist);
                    }
                }
                currlist.Clear();
            }
        }
        string result = new string(bigList.ToArray());
        Console.WriteLine("Unique symbols used: {0}", result.Distinct().Count());
        Console.WriteLine(result);
    }
}