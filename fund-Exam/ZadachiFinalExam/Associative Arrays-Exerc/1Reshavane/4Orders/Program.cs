using System;
using System.Collections.Generic;

namespace _4Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> priceProduct = new Dictionary<string, decimal>();
            Dictionary<string, int> quantityProduct = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "buy")
                {
                    break;
                }

                string[] parts = line.Split();

                string name = parts[0];
                decimal price = decimal.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                if (priceProduct.ContainsKey(name))
                {
                    priceProduct[name] = price;
                    quantityProduct[name] += quantity;
                }
                else
                {
                    priceProduct.Add(name, price);
                    quantityProduct.Add(name, quantity);
                }
            }

            foreach (var kvp in priceProduct)
            {
                string product = kvp.Key;
                decimal price = kvp.Value;
                int quantity = quantityProduct[product];

                decimal totalPrice = price * quantity;

                Console.WriteLine($"{product} -> {totalPrice:F2}");
            }
        }
    }
}
