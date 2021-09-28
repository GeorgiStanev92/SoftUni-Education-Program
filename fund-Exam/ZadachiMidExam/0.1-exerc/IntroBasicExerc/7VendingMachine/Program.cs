using System;

namespace _7VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            double money = 0;

            while (line != "Start")
            {
                double coins = double.Parse(line);

                if (coins == 0.1 || coins == 0.2 || coins == 0.5 ||
                    coins == 1 || coins == 2)
                {
                    money += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                line = Console.ReadLine();
            }

            line = Console.ReadLine();


            while (line != "End")
            {
                double price = 0;

                if (line == "Nuts")
                {
                    price += 2;
                }
                else if (line == "Water")
                {
                    price += 0.7;
                }
                else if (line == "Crisps")
                {
                    price += 1.5;
                }
                else if (line == "Soda")
                {
                    price += 0.8;
                }
                else if (line == "Coke")
                {
                    price += 1;
                }

                if (price != 0)
                {
                    if (money >= price)
                    {
                        Console.WriteLine($"Purchased {line.ToLower()}");
                        money -= price;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                line = Console.ReadLine();
            }
            Console.WriteLine($"Change: {money:F2}");
        }
    }
}
