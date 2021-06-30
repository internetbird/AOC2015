using AOC2015.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class Day3PuzzleSolver : IPuzzleSolver
    {


        public string SolvePuzzlePart1()
        {

            var visitedCoordinates = new List<string>();
            var coordinateRobot = new CoordinatesRobot();

            //Add the initial coordinate
            visitedCoordinates.Add(coordinateRobot.GetCoordinateString());

            List<Direction> inputDirections = GetInputDirections();
            for (int i = 0; i < inputDirections.Count; i++)
            {
                coordinateRobot.Move(inputDirections[i]);
                string newCoordinate = coordinateRobot.GetCoordinateString();

                if (!visitedCoordinates.Contains(newCoordinate)) {
                    visitedCoordinates.Add(newCoordinate);
                }
            }

            return visitedCoordinates.Count.ToString();
        }

        public string SolvePuzzlePart2()
        {
            var visitedCoordinates = new List<string>();
            var santa = new CoordinatesRobot();
            var santaRobo = new CoordinatesRobot();

            //Add the initial coordinate
            visitedCoordinates.Add(santa.GetCoordinateString());

            List<Direction> inputDirections = GetInputDirections();

            for (int i = 0; i < inputDirections.Count; i = i+2)
            {
                santa.Move(inputDirections[i]);
                santaRobo.Move(inputDirections[i + 1]);

                string santaNewCoordinate = santa.GetCoordinateString();
                string santaRoboNewCoordinate = santaRobo.GetCoordinateString();

                if (!visitedCoordinates.Contains(santaNewCoordinate))
                {
                    visitedCoordinates.Add(santaNewCoordinate);
                }

                if (!visitedCoordinates.Contains(santaRoboNewCoordinate))
                {
                    visitedCoordinates.Add(santaRoboNewCoordinate);
                }
            }

            return visitedCoordinates.Count.ToString();
        }


        private List<Direction> GetInputDirections()
        {
            var fullInputFilePath = Path.GetFullPath("InputFiles/day3.txt");
            var inputText = File.ReadAllText(fullInputFilePath);
        
            List<Direction> directions = inputText.Select(dir => MapCharToDirection(dir)).ToList();

            return directions;
        }

        private Direction MapCharToDirection(char dir)
        {
            switch(dir)
            {
                case '<':
                    return Direction.West;
                case '>':
                    return Direction.East;
                case '^':
                    return Direction.North;
                default:
                    return Direction.South;
            }
        }
    }
}
