using AOC2015.Logic.Models;
using AOC2015.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Calculators
{
    public class ReindeerDistanceCalculator
    {
        public int CalculateDistanceTravelled(Reindeer reindeer, int numOfSecondsElapsed)
        {
            int totalDistanceTravelled = 0;

            for (int currSecond = 0; currSecond < numOfSecondsElapsed; currSecond++)
            {
                if (reindeer.State == ReindeerState.Flying)
                {
                    if (reindeer.TimeInCurrentState == reindeer.FlightTimeInSecs)
                    {
                        reindeer.State = ReindeerState.Resting;
                        reindeer.TimeInCurrentState = 1;

                    } else
                    {
                        totalDistanceTravelled += reindeer.FlightSpeedInKms;
                        reindeer.TimeInCurrentState++;
                    }

                } else //reindeer is resting
                {
                    if (reindeer.TimeInCurrentState == reindeer.RestTimeInSecs)
                    {
                        reindeer.State = ReindeerState.Flying;
                        reindeer.TimeInCurrentState = 1;
                        totalDistanceTravelled += reindeer.FlightSpeedInKms;

                    } else
                    {
                        reindeer.TimeInCurrentState++;
                    }
                }
            }

            return totalDistanceTravelled;
        }
    }
}
