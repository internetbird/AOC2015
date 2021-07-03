using AOC2015.Models;
using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day9PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            Dictionary<string, int> distancesDictionary = GetInputDistancesDictionary();

            var calculator = new SantaRouteCalculator(distancesDictionary);

            int shortestRoute = calculator.CalculateShortestRoute();

            return shortestRoute.ToString();
        }


        public string SolvePuzzlePart2()
        {
            Dictionary<string, int> distancesDictionary = GetInputDistancesDictionary();

            var calculator = new SantaRouteCalculator(distancesDictionary);

            int longestRoute = calculator.CalculateLongestRoute();

            return longestRoute.ToString();
        }

        private Dictionary<string, int> GetInputDistancesDictionary()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day9.txt");
            
            var builder = new DistanceDictionaryBuilder();
            Dictionary<string, int>  distancesDictionary = builder.Build(inputLines);

            return distancesDictionary;
        }
    }
}
