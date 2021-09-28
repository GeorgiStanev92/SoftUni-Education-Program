using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> carsKilometers = new Dictionary<string, int>();
            Dictionary<string, int> carFuel = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string car = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);
                carsKilometers.Add(car, mileage);
                carFuel.Add(car, fuel);
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Stop")
                {
                    break;
                }

                string[] parts = line.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];
                string car = parts[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(parts[2]);
                    int neededFuel = int.Parse(parts[3]);
                    
                    if (carsKilometers.ContainsKey(car))
                    {
                        if (neededFuel > carFuel[car])
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                            continue;
                        }
                        else
                        {
                            carsKilometers[car] += distance;
                            carFuel[car] -= neededFuel;

                            Console.WriteLine($"{car} driven for {distance} kilometers. {neededFuel} liters of fuel consumed.");
                        }

                        if (carsKilometers[car] >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {car}!");
                        }
                    }
                }
                else if (command == "Refuel")
                {
                    
                    int refuel = int.Parse(parts[2]);
                    int fuelInfo = carFuel[car];
                    int capacity = 75 - fuelInfo;
                    carFuel[car] += refuel;

                    if (fuelInfo + refuel <= 75)
                    {
                        Console.WriteLine($"{car} refueled with {refuel} liters");
                    }
                    else
                    {
                        int refueled = refuel - capacity;
                        Console.WriteLine($"{car} refueled with {refueled} liters");
                    }
                }
                else if (command == "Revert")
                {
                    int kilometers = int.Parse(parts[2]);
                    carsKilometers[car] -= kilometers;

                    if (carsKilometers[car] < 10000)
                    {
                        carsKilometers[car] = 10000;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                }
            }

            Dictionary<string, int> sorted = carsKilometers
                .OrderByDescending(c => c.Value)
                .ThenBy(c => c.Key)
                .ToDictionary(c => c.Key, c => c.Value);

            foreach (var kvp in sorted)
            {
                string car = kvp.Key;
                int kilometers = kvp.Value;
                int fuel = carFuel[car];

                Console.WriteLine($"{car} -> Mileage: {kilometers} kms, Fuel in the tank: {fuel} lt.");
            }
        }
    }
}
