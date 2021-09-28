﻿using System;
using System.Linq;

namespace Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split("@").Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            int lastPosition = 0;

            while (command != "Love!")
            {
                string[] receivedCommand = command.Split();
                int index = 0;

                if (receivedCommand.Length > 0)
                {
                    if (receivedCommand[0] == "Jump")
                    {
                        index = int.Parse(receivedCommand[1]);
                    }
                }

                while (index > 0)
                {
                    lastPosition++;
                    if (lastPosition >= neighborhood.Length)
                    {
                        lastPosition = 0;
                        break;
                    }
                    index--;
                }

                if (neighborhood[lastPosition] == 0)
                {
                    Console.WriteLine($"Place {lastPosition} already had Valentine's day.");
                }
                else
                {
                    neighborhood[lastPosition] -= 2;

                    if (neighborhood[lastPosition] == 0)
                    {
                        Console.WriteLine($"Place {lastPosition} has Valentine's day.");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {lastPosition}.");

            if (neighborhood.Sum() == 0)
            {
                Console.WriteLine($"Mission was successful.");
            }
            else
            {
                int houseCount = 0;

                for (int i = 0; i < neighborhood.Length; i++)
                {
                    if (neighborhood[i] != 0)
                    {
                        houseCount++;
                    }
                }
                Console.WriteLine($"Cupid has failed {houseCount} places.");
            }
        }
    }
}