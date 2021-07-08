using AOC2015.Logic.Calculators;
using AOC2015.Models;
using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day14PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day14.txt");
            var reindeers = new List<Reindeer>();
            var builder = new ReindeerBuilder();

            foreach (string line in inputLines)
            {
                reindeers.Add(builder.Build(line));
            }

            int maxDistanceTravelled = 0;
            string nameOfWinningReindeer = string.Empty;

            var calculator = new ReindeerDistanceCalculator();
            const int NumOfSecondsElapsed = 2503;

            foreach (Reindeer reindeer in reindeers)
            {
                int reindeerDistance = calculator.CalculateDistanceTravelled(reindeer, NumOfSecondsElapsed);
                Console.WriteLine($"Reindeer :{reindeer.Name} has travelled {reindeerDistance}KM");

                if (reindeerDistance > maxDistanceTravelled)
                {
                    nameOfWinningReindeer = reindeer.Name;
                    maxDistanceTravelled = reindeerDistance;
                }
            }

            Console.WriteLine($"Winning reindeer is:{nameOfWinningReindeer} with a total of {maxDistanceTravelled}KM travelled!");

            return maxDistanceTravelled.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
