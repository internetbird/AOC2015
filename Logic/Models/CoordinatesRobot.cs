using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class CoordinatesRobot
    {
        private int x_coordinate;
        private int y_coordinate;


        public CoordinatesRobot()
        {
            x_coordinate = 0;
            y_coordinate = 0;
        }


        public void Move(Direction directionToMove)
        {
            switch (directionToMove)
            {
                case Direction.North:
                    y_coordinate++;
                    break;
                case Direction.South:
                    y_coordinate--;
                    break;
                case Direction.East:
                    x_coordinate++;
                    break;
                case Direction.West:
                    x_coordinate--;
                    break;
            }
        }


        public string GetCoordinateString()
        {
            return $"{x_coordinate},{y_coordinate}";
        }

    }
}
