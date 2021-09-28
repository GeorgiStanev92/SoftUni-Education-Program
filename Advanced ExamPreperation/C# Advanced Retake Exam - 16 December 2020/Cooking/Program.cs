using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] ingredientInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(liquidInput);
            Stack<int> ingredients = new Stack<int>(ingredientInput);

            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Peek();
                int currentIngredient = ingredients.Peek();
                int result = currentLiquid + currentIngredient;

                if (result == 25)
                {
                    bread++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (result == 50)
                {
                    cake++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (result == 75)
                {
                    pastry++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (result == 100)
                {
                    fruitPie++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    currentIngredient += 3;
                    ingredients.Pop();
                    ingredients.Push(currentIngredient);
                }
            }
            if (bread >= 1 && cake >= 1 && pastry >= 1 && fruitPie >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Count <= 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            if (ingredients.Count <= 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            Console.WriteLine($"Bread: {bread}");
            Console.WriteLine($"Cake: {cake}");
            Console.WriteLine($"Fruit Pie: {fruitPie}");
            Console.WriteLine($"Pastry: {pastry}");
        }
    }
}