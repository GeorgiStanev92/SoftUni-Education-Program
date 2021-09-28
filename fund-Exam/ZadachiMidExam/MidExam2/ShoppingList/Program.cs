using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] groceries = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries);

            List<string> products = new List<string>(groceries);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Go Shopping!")
                {
                    break;
                }

                string[] parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "Urgent")
                {
                    string product = parts[1];

                    if (!products.Contains(product))
                    {
                        products.Insert(0, product);
                    }
                }
                else if (parts[0] == "Unnecessary")
                {
                    string product = parts[1];
                    if (products.Contains(product))
                    {
                        products.Remove(product);
                    }
                }
                else if (parts[0] == "Correct")
                {
                    string productChange = parts[1];
                    string product = parts[2];
                    int idx = products.IndexOf(productChange);

                    if (products.Contains(productChange))
                    {
                        products.Insert(idx, product);
                        products.Remove(productChange);
                    }
                }
                else if (parts[0] == "Rearrange")
                {
                    string product = parts[1];

                    if (products.Contains(product))
                    {
                        products.Remove(product);
                        products.Add(product);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", products));
        }
    }
}
