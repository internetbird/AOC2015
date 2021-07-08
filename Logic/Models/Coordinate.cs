using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        /// <summary>
        /// Creates a coordinate from a given text in format: "x,y"
        /// </summary>
        /// <param name="coordinatesText"></param>
        public Coordinate(string coordinatesText) 
        {
            string[] textParts = coordinatesText.Split(',');

            X = int.Parse(textParts[0]);
            Y = int.Parse(textParts[1]);
        }
    }
}
