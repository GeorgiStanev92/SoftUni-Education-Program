using System;

namespace myapp1
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int startingPositionX = -1;
            int startingPositionY = -1;
            int flowersCount = 0;
            for (int row = 0; row < n; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                    if (matrix[row, col] == 'B')
                    {
                        startingPositionX = row;
                        startingPositionY = col;
                    }
                }
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End") { break; }
                else if (command == "down")
                {
                    if (IsValidCoordinate(startingPositionX + 1, startingPositionY, matrix))
                    {
                        if (matrix[startingPositionX + 1, startingPositionY] == 'f')
                        {
                            flowersCount++;
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionX += 1;
                            matrix[startingPositionX, startingPositionY] = 'B';
                        }
                        else if (matrix[startingPositionX + 1, startingPositionY] == 'O')
                        {
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionX += 1;
                            matrix[startingPositionX, startingPositionY] = 'B';
                            if (matrix[startingPositionX + 1, startingPositionY] == 'f')
                            {
                                flowersCount++;
                                matrix[startingPositionX, startingPositionY] = '.';
                                startingPositionX += 1;
                                matrix[startingPositionX, startingPositionY] = 'B';
                            }
                            else
                            {
                                matrix[startingPositionX, startingPositionY] = '.';
                                startingPositionX += 1;
                                matrix[startingPositionX, startingPositionY] = 'B';
                            }
                        }
                        else
                        {
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionX += 1;
                            matrix[startingPositionX, startingPositionY] = 'B';
                        }
                    }
                    else
                    {
                        matrix[startingPositionX, startingPositionY] = '.';
                        Console.WriteLine("The bee got lost!");
                        if (flowersCount >= 5)
                        {
                            Console.WriteLine("Great job, the bee managed to pollinate {0} flowers!", flowersCount);
                            PrintMatrix(matrix); return;
                        }

                        else
                        {
                            Console.WriteLine("The bee couldn't pollinate the flowers, she needed {0} flowers more", 5 - flowersCount);
                            PrintMatrix(matrix); return;
                        }
                    }
                }
                else if (command == "up")
                {
                    if (IsValidCoordinate(startingPositionX - 1, startingPositionY, matrix))
                    {
                        if (matrix[startingPositionX - 1, startingPositionY] == 'f')
                        {
                            flowersCount++;
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionX -= 1;
                            matrix[startingPositionX, startingPositionY] = 'B';
                        }
                        else if (matrix[startingPositionX - 1, startingPositionY] == 'O')
                        {
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionX -= 1;
                            matrix[startingPositionX, startingPositionY] = 'B';
                            if (matrix[startingPositionX - 1, startingPositionY] == 'f')
                            {
                                flowersCount++;
                                matrix[startingPositionX, startingPositionY] = '.';
                                startingPositionX -= 1;
                                matrix[startingPositionX, startingPositionY] = 'B';
                            }
                            else
                            {
                                matrix[startingPositionX, startingPositionY] = '.';
                                startingPositionX -= 1;
                                matrix[startingPositionX, startingPositionY] = 'B';
                            }
                        }
                        else
                        {
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionX -= 1;
                            matrix[startingPositionX, startingPositionY] = 'B';
                        }
                    }
                    else
                    {
                        matrix[startingPositionX, startingPositionY] = '.';
                        Console.WriteLine("The bee got lost!");
                        if (flowersCount >= 5)
                        {
                            Console.WriteLine("Great job, the bee managed to pollinate {0} flowers!", flowersCount);
                            PrintMatrix(matrix); return;
                        }
                        else
                        {
                            Console.WriteLine("The bee couldn't pollinate the flowers, she needed {0} flowers more", 5 - flowersCount);
                            PrintMatrix(matrix); return;
                        }
                    }
                }
                else if (command == "right")
                {
                    if (IsValidCoordinate(startingPositionX, startingPositionY + 1, matrix))
                    {
                        if (matrix[startingPositionX, startingPositionY + 1] == 'f')
                        {
                            flowersCount++;
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionY += 1;
                            matrix[startingPositionX, startingPositionY] = 'B';

                        }
                        else if (matrix[startingPositionX, startingPositionY + 1] == 'O')
                        {
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionY += 1;
                            matrix[startingPositionX, startingPositionY] = 'B';
                            if (matrix[startingPositionX, startingPositionY + 1] == 'f')
                            {
                                flowersCount++;
                                matrix[startingPositionX, startingPositionY] = '.';
                                startingPositionY += 1;
                                matrix[startingPositionX, startingPositionY] = 'B';
                            }
                            else
                            {
                                matrix[startingPositionX, startingPositionY] = '.';
                                startingPositionY += 1;
                                matrix[startingPositionX, startingPositionY] = 'B';
                            }
                        }
                        else
                        {
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionY += 1;
                            matrix[startingPositionX, startingPositionY] = 'B';
                        }
                    }
                    else
                    {
                        matrix[startingPositionX, startingPositionY] = '.';
                        Console.WriteLine("The bee got lost!");
                        if (flowersCount >= 5)
                        {
                            Console.WriteLine("Great job, the bee managed to pollinate {0} flowers!", flowersCount);
                            PrintMatrix(matrix); return;
                        }
                        else
                        {
                            Console.WriteLine("The bee couldn't pollinate the flowers, she needed {0} flowers more", 5 - flowersCount);
                            PrintMatrix(matrix); return;
                        }
                    }
                }
                else if (command == "left")
                {
                    if (IsValidCoordinate(startingPositionX, startingPositionY + 1, matrix))
                    {
                        if (matrix[startingPositionX, startingPositionY - 1] == 'f')
                        {
                            flowersCount++;
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionY -= 1;
                            matrix[startingPositionX, startingPositionY] = 'B';
                        }
                        else if (matrix[startingPositionX, startingPositionY - 1] == 'O')
                        {
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionY -= 1;
                            matrix[startingPositionX, startingPositionY] = 'B';
                            if (matrix[startingPositionX, startingPositionY - 1] == 'f')
                            {
                                flowersCount++;
                                matrix[startingPositionX, startingPositionY] = '.';
                                startingPositionY -= 1;
                                matrix[startingPositionX, startingPositionY] = 'B';
                            }
                            else
                            {
                                matrix[startingPositionX, startingPositionY] = '.';
                                startingPositionY -= 1;
                                matrix[startingPositionX, startingPositionY] = 'B';
                            }
                        }
                        else
                        {
                            matrix[startingPositionX, startingPositionY] = '.';
                            startingPositionY -= 1;
                            matrix[startingPositionX, startingPositionY] = 'B';
                        }
                    }
                    else
                    {
                        matrix[startingPositionX, startingPositionY] = '.';
                        Console.WriteLine("The bee got lost!");
                        if (flowersCount >= 5)
                        {
                            Console.WriteLine("Great job, the bee managed to pollinate {0} flowers!", flowersCount);
                            PrintMatrix(matrix); return;
                        }

                        else
                        {
                            Console.WriteLine("The bee couldn't pollinate the flowers, she needed {0} flowers more", 5 - flowersCount);
                            PrintMatrix(matrix); return;
                        }
                    }
                }
            }
            if (flowersCount >= 5)
            {
                Console.WriteLine("Great job, the bee managed to pollinate {0} flowers!", flowersCount);
                PrintMatrix(matrix);
            }
            else
            {
                Console.WriteLine("The bee couldn't pollinate the flowers, she needed {0} flowers more", 5 - flowersCount);
                PrintMatrix(matrix);
            }
        }
        public static bool IsValidCoordinate(int coordinateX, int coordinateY, char[,] matrix)
        {
            return (coordinateX >= 0 && coordinateX < matrix.GetLength(0) && coordinateY >= 0 && coordinateY < matrix.GetLength(1));
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}