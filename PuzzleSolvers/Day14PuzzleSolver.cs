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

            return string.Empty;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
