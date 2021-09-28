using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            //•	* – a regular position on the field
            //•	< – ship of the first player.
            //•	> – ship of the second player
            //•	# – a sea mine that explodes when attacked
            string[] coordinatesOfAttack = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            var matrix = FillMatrix(sizeOfMatrix);

            var shipsOfPlayers = FindShipsOfBothPlayers(matrix);
            int allShips = shipsOfPlayers.Sum();
            for (int i = 0; i < coordinatesOfAttack.Length; i++)
            {
                var coordinates = coordinatesOfAttack[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var row = int.Parse(coordinates[0]);
                var col = int.Parse(coordinates[1]);

                if (row >= 0 && row <= matrix.Length - 1 && col >= 0 && col <= matrix[row].Length - 1)
                {
                    if (matrix[row][col] == "<")
                    {
                        matrix[row][col] = "X";
                    }
                    else if (matrix[row][col] == ">")
                    {
                        matrix[row][col] = "X";
                    }
                    else if (matrix[row][col] == "#")
                    {
                        Bomb(matrix, new int[] { row, col });
                    }
                    var currentShipsOfPlayers = FindShipsOfBothPlayers(matrix);
                    if (currentShipsOfPlayers[0] == 0)
                    {
                        var sunkShips = shipsOfPlayers.Sum() - currentShipsOfPlayers.Sum();
                        Console.WriteLine($"Player Two has won the game! {sunkShips} ships have been sunk in the battle.");
                        return;
                    }
                    else if (currentShipsOfPlayers[1] == 0)
                    {
                        var sunkShips = shipsOfPlayers.Sum() - currentShipsOfPlayers.Sum();
                        Console.WriteLine($"Player One has won the game! {sunkShips} ships have been sunk in the battle.");
                        return;
                    }

                }
            }
            var ships = FindShipsOfBothPlayers(matrix);
            Console.WriteLine($"It's a draw! Player One has {ships[0]} ships left. Player Two has {ships[1]} ships left.");


        }

        static void Bomb(string[][] matrix, int[] coordinatesOfBomb)
        {
            var row = coordinatesOfBomb[0];
            var col = coordinatesOfBomb[1];

            if (row - 1 >= 0)
            {
                matrix[row - 1][col] = "X";
            }
            if (row - 1 >= 0 && col + 1 < matrix[row].Length - 1)
            {
                matrix[row - 1][col + 1] = "X";
            }
            if (row - 1 >= 0 && col - 1 >= 0)
            {
                matrix[row - 1][col - 1] = "X";
            }
            if (col + 1 <= matrix[row].Length - 1)
            {
                matrix[row][col + 1] = "X";
            }
            if (col - 1 >= 0)
            {
                matrix[row][col - 1] = "X";
            }
            if (row + 1 <= matrix.Length - 1 && col - 1 >= 0)
            {
                matrix[row + 1][col - 1] = "X";
            }
            if (row + 1 <= matrix.Length - 1 && col + 1 <= matrix[row].Length - 1)
            {
                matrix[row + 1][col + 1] = "X";
            }
            if (row + 1 <= matrix.Length - 1)
            {
                matrix[row + 1][col] = "X";
            }
        }
        static int[] FindShipsOfBothPlayers(string[][] matrix)
        {
            int firstPlayer = 0;
            int secondPlayer = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i].Where(x => x == "<").ToList().ForEach(x => ++firstPlayer);
                matrix[i].Where(x => x == ">").ToList().ForEach(x => ++secondPlayer);
            }

            return new int[] { firstPlayer, secondPlayer };
        }
        static string[][] FillMatrix(int size)
        {
            string[][] matrix = new string[size][];

            for (int i = 0; i < matrix.Length; i++)
            {
                string[] line = string.Join("",
                                      Console.ReadLine()
                                      .ToCharArray()
                                      .Select(x => x
                                          .ToString())
                                      .ToArray())
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                matrix[i] = new string[line.Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = line[j];
                }
            }

            return matrix;
        }

        static void PrintMatrix(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }
    }
}