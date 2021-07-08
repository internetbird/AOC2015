using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class ReindeerBuilder
    {
        public Reindeer Build(string inputData)
        {
            var reindeer = new Reindeer();

            string[] inputParts = inputData.Split();
            reindeer.Name = inputParts[0];
            reindeer.FlightSpeedInKms = int.Parse(inputParts[3]);
            reindeer.FlightTimeInSecs = int.Parse(inputParts[6]);
            reindeer.RestTimeInSecs = int.Parse(inputParts[13]);
            return reindeer;
        }
    }
}
