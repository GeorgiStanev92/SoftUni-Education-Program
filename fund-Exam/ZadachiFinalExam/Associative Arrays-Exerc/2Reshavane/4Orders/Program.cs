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

                string product = parts[0];
                decimal price = decimal.Parse(parts[1]);
                int quantity = int.Parse(parts[2]);

                if (priceProduct.ContainsKey(product))
                {
                    priceProduct[product] = price;
                    quantityProduct[product] += quantity;
                }
                else
                {
                    priceProduct.Add(product, price);
                    quantityProduct.Add(product, quantity);
                }
            }
            foreach (var item in priceProduct)
            {
                string product = item.Key;
                decimal price = item.Value;
                int quantity = quantityProduct[product];

                decimal totalPrice = price * quantity;

                Console.WriteLine($"{product} -> {totalPrice:F2}");
            }
        }
    }
}
