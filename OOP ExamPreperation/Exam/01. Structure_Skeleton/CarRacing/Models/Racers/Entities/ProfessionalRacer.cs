using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Cars.Entities.Racers;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        public ProfessionalRacer(string username, ICar car) 
            : base(username, "strict", 30, car)
        {
        }

        public override void Race()
        {
            Car.Drive();
            DrivingExperience += 10;
        }
    }
}
