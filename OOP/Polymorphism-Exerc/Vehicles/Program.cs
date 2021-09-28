using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split();
            string[] truckTokens = Console.ReadLine().Split();
            string[] busTokens = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]));
            Vehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), double.Parse(truckTokens[3]));
            Bus bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();
                string command = line[0];
                string type = line[1];
                double amount = double.Parse(line[2]);

                

                if (command == "Drive")
                {
                    if (type is "Car")
                    {
                        CanDrive(car, amount);
                    }
                    else if (type is "Bus")
                    {
                        bus.IsEmpty = false;
                        CanDrive(bus, amount);
                    }
                    else //truck
                    {
                        CanDrive(truck, amount);
                    }
                }
                else if (command is "Refuel")
                {
                    try
                    {
                        if (type is "Car")
                        {
                            car.Refuel(amount);
                        }
                        else if (type is "Bus")
                        {
                            bus.Refuel(amount);
                        }
                        else // truck
                        {
                            truck.Refuel(amount);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    bus.IsEmpty = true;
                    CanDrive(bus, amount);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
        public static void CanDrive(Vehicle vehicle, double distance)
        {
            bool canDrive = vehicle.CanDrive(distance);

            string result = canDrive ? $"{vehicle.GetType().Name} travelled {distance} km" 
                : $"{vehicle.GetType().Name} needs refueling";

            Console.WriteLine(result);
        }
    }
}
