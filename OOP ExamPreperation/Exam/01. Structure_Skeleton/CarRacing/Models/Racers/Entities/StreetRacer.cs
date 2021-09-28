using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Cars.Entities.Racers;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        public StreetRacer(string username, ICar car) 
            : base(username, "aggressive", 10, car)
        {
        }

        public override void Race()
        {
            Car.Drive();
            DrivingExperience += 5;
        }
    }
}
