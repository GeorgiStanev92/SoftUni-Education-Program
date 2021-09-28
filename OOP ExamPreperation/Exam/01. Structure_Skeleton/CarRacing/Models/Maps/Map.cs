using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }
            else if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            double racerOneBehaivior;

            if (racerOne.RacingBehavior == "strict")
            {
                racerOneBehaivior = 1.2;
            }
            else
            {
                racerOneBehaivior = 1.1;
            }

            double racerTwoBehaivior;

            if (racerTwo.RacingBehavior == "strict")
            {
                racerTwoBehaivior = 1.2;
            }
            else
            {
                racerTwoBehaivior = 1.1;
            }

            double racerOneWinningChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneBehaivior;
            racerOne.Race();
            double racerTwoWinningChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoBehaivior;
            racerTwo.Race();
            string result="";
            if (racerOneWinningChance > racerTwoWinningChance)
            {
                result = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else if (racerTwoWinningChance > racerOneWinningChance)
            {
                result = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
            return result;

        }
    }
}
