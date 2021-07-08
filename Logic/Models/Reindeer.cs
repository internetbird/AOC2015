using AOC2015.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class Reindeer
    {
        public Reindeer()
        {
            State = ReindeerState.Flying;
        }

        public string Name { get; set; }
        public int FlightSpeedInKms { get; set; }
        public int FlightTimeInSecs { get; set; }
        public int RestTimeInSecs { get; set; }
        public ReindeerState State { get; set; }
        public int TimeInCurrentState { get; set; }
    }
}
