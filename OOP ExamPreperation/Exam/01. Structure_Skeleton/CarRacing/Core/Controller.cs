using CarRacing.Core.Contracts;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Cars.Entities;
using CarRacing.Models.Cars.Entities.Racers;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {

        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type == "TunedCar")
            {
                ICar car  = new TunedCar(make, model, VIN, horsePower);
                cars.Add(car);
                return string.Format(OutputMessages.SuccessfullyAddedCar, car.Make, car.Model, car.VIN);
            }
            else if (type == "SuperCar")
            {
                ICar car = new SuperCar(make, model, VIN, horsePower);
                cars.Add(car);
                return string.Format(OutputMessages.SuccessfullyAddedCar, car.Make, car.Model, car.VIN);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            var car = cars.FindBy(carVIN);
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            if (type == "ProfessionalRacer")
            {
                IRacer racer = new ProfessionalRacer(username, car);
                racers.Add(racer);
                return string.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
            }
            else if (type == "StreetRacer")
            {
                IRacer racer = new StreetRacer(username, car);
                racers.Add(racer);
                return string.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer first = racers.FindBy(racerOneUsername);
            IRacer second = racers.FindBy(racerTwoUsername);
            if (first == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if (second == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            else
            {
                string result = map.StartRace(first, second);
                return result;
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var sorted = racers.Models.OrderByDescending(r => r.DrivingExperience)
                .ThenBy(r => r.Username)
                .ToList();

            foreach (Racer racer in sorted)
            {
                sb.Append($"{racer.GetType().Name}: {racer.Username}" +
                    $"\r\n--Driving behavior: {racer.RacingBehavior}" +
                    $"\r\n--Driving experience: {racer.DrivingExperience}" +
                    $"\r\n--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})" +
                    $"\r\n");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
