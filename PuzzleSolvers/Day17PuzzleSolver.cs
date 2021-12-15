using AOC;
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
            List<int> containers = GetContainers();

            var calculator = new ContainerCombinationsCalculator();
            int numOfCombinations = calculator.CalculateNumOfCombinationsFor(containers, 150);

            return numOfCombinations.ToString();
        }
      
        public string SolvePuzzlePart2()
        {
            List<int> containers = GetContainers();

            var calculator = new ContainerCombinationsCalculator();
            int numOfCombinations = calculator.CalculateNumOfMinSizeContainerCombinationsFor(containers, 150);

            return numOfCombinations.ToString();
        }

        private static List<int> GetContainers()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day17.txt");
            List<int> containerSizes = inputLines
                                            .Select(line => int.Parse(line))
                                            .ToList();
            return containerSizes;
        }

    }
}
