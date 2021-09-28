using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace CarRacing.Models.Cars.Entities.Racers
{
    public abstract class Racer : IRacer
    {
        private string userName;
        private string racingBehavior;
        private int drivingExperiance;
        private ICar car;

        public string Username
        {
            get => userName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                userName = value;
            }
        }

        public string RacingBehavior
        {
            get => racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                racingBehavior = value;
            }
        }
        public int DrivingExperience
        {
            get => drivingExperiance;
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                drivingExperiance = value;
            }
        }
        public ICar Car
        {
            get
            {
                return car;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                car = value;
            }
        }

        protected Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public bool IsAvailable()
        {
            
            if (car.FuelAvailable < Car.FuelConsumptionPerRace)
            {
                return false;
            }
            return true;
        }

        public virtual void Race()
        {
            
        }
    }
}
