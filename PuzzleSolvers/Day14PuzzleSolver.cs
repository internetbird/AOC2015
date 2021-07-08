using AOC2015.Logic.Calculators;
using AOC2015.Models;
using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day14PuzzleSolver : IPuzzleSolver
    {
        private const int NumOfSecondsElapsed = 2503;

        public string SolvePuzzlePart1()
        {
            List<Reindeer> reindeers = GetInputReindeers();

            int maxDistanceTravelled = 0;
            string nameOfWinningReindeer = string.Empty;

            var calculator = new ReindeerDistanceCalculator();

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

        private static List<Reindeer> GetInputReindeers()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day14.txt");
            var reindeers = new List<Reindeer>();
            var builder = new ReindeerBuilder();

            foreach (string line in inputLines)
            {
                reindeers.Add(builder.Build(line));
            }

            return reindeers;
        }

        public string SolvePuzzlePart2()
        {
            List<Reindeer> reindeers = GetInputReindeers();

            var reindeerScores = new Dictionary<string, int>();
            //Initalize scores
            foreach (Reindeer reindeer in reindeers)
            {
                reindeerScores.Add(reindeer.Name, 0);
            }

            var calculator = new ReindeerDistanceCalculator();

            for (int secondsElapsed = 1; secondsElapsed <= NumOfSecondsElapsed; secondsElapsed++)
            {
                string reindeerLeader = string.Empty;
                int maxDistanceTravelled = 0;

                foreach (Reindeer reindeer in reindeers)
                {
                    int distanceTravelled = calculator.CalculateDistanceTravelled(reindeer, secondsElapsed);

                    if (distanceTravelled > maxDistanceTravelled)
                    {
                        reindeerLeader = reindeer.Name;
                        maxDistanceTravelled = distanceTravelled;
                    }
                }
                //Add a point to the winner after X seconds
                reindeerScores[reindeerLeader]++;

            }

            return reindeerScores.Max(pair => pair.Value).ToString();
        }
    }
}
