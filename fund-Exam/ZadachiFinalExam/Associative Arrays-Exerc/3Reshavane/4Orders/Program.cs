using System;
using System.Collections.Generic;

namespace _4Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> productPrice = new Dictionary<string, double>();

            Dictionary<string, int> productQuantity = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "buy")
                {
                    break;
                }

                string[] parts = line.Split();

                string product = parts[0];
                double price = double.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                if (!productPrice.ContainsKey(product))
                {
                    productPrice.Add(product, price);
                    productQuantity.Add(product, quantity);
                }
                else
                {
                    productPrice[product] = price;
                    productQuantity[product] += quantity;
                }
            }
            foreach (var item in productPrice)
            {
                string product = item.Key;
                double price = item.Value;
                int quantity = productQuantity[product];

                double totalPrice = price * quantity;

                Console.WriteLine($"{item.Key} -> {totalPrice:F2}");
            }
        }
    }
}
