using System;
using System.Collections.Generic;
using System.Linq;

namespace _3ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string[]> pieces = new Dictionary<string, string[]>();
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                pieces.Add(data[0], new string[] { data[1], data[2] });
            }
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Stop")
                {
                    break;
                }

                string[] parts = line.Split('|');

                if (parts[0] == "Add")
                {
                    if (pieces.ContainsKey(parts[1]))
                    {
                        Console.WriteLine($"{parts[1]} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(parts[1], new string[] { parts[2], parts[3] });
                        Console.WriteLine($"{parts[1]} by {parts[2]} in {parts[3]} added to the collection!");
                    }
                }
                else if (parts[0] == "Remove")
                {
                    if (pieces.ContainsKey(parts[1]))
                    {
                        pieces.Remove(parts[1]);
                        Console.WriteLine($"Successfully removed {parts[1]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {parts[1]} does not exist in the collection.");
                    }
                }
                else if (parts[0] == "ChangeKey")
                {
                    if (pieces.ContainsKey(parts[1]))
                    {
                        pieces[parts[1]][1] = parts[2];

                        Console.WriteLine($"Changed the key of {parts[1]} to {parts[2]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {parts[1]} does not exist in the collection.");
                    }
                }
            }

            pieces = pieces
                .OrderBy(p => p.Key)
                .ThenBy(p => p.Value[0])
                .ToDictionary(k => k.Key, v => v.Value);

            // var result = pieces
            //.OrderBy(p => p.Key)
            //.ThenBy(p => p.Value[0]);

            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
