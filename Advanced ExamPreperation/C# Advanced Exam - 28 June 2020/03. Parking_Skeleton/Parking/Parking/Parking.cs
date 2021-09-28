using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }
        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var carToRemove = data.FirstOrDefault(c =>
            c.Manufacturer == manufacturer &&
            c.Model == model);

            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            var latestCar = data.OrderByDescending(c => c.Year)
                .FirstOrDefault();
            return latestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            var car = data.FirstOrDefault(c =>
            c.Manufacturer == manufacturer &&
            c.Model == model);

            return car;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString();
        }
    }
}
