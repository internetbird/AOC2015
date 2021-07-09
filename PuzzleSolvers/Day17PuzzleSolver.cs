using AOC2015.Logic.Calculators;
using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day17PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day17.txt");
            List<int> containerSizes = inputLines
                                            .Select(line => int.Parse(line))
                                            .ToList();

            var calculator = new ContainerCombinationsContainer();
            int numOfCombinations = calculator.CalculateNumOfCombinationsFor(containerSizes, 150);

            return numOfCombinations.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
