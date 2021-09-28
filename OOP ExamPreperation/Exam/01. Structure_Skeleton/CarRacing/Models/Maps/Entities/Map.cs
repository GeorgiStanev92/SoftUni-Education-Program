using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps.Entities
{
    public class Map : IMap
    {
        private const double strick = 1.2;
        private const double aggressive = 1.1;
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                racerOne.Race();
                racerTwo.Race();
                double racerOneChance = WinningChance(racerOne);
                double racerTwoChance = WinningChance(racerTwo);

                if (racerTwoChance > racerOneChance)
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerTwo.Username, racerOne.Username, racerTwo.Username);
                }
                else
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
            }
            else if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
        }

        public double WinningChance(IRacer racer)
        {
            double chance;

            if (racer.RacingBehavior == "aggressive")
            {
                chance = racer.Car.HorsePower * racer.DrivingExperience * 1.1;
            }
            else
            {
                chance = racer.Car.HorsePower * racer.DrivingExperience * 1.2;
            }
            return chance;
        }
    }
}
