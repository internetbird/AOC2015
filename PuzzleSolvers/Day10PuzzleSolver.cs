using AOC;
using AOC2015.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    class Day10PuzzleSolver : IPuzzleSolver
    {

        public string SolvePuzzlePart1() => SolvePuzzle(40);

        public string SolvePuzzlePart2() => SolvePuzzle(50);

        private string SolvePuzzle(int numOfTimesToRun)
        {
            string result = "1321131112";

            var calculator = new LookAndSayCalculator();

            for (int i = 0; i < numOfTimesToRun; i++)
            {
                Console.WriteLine($"Iteration #{i + 1}");
                result = calculator.CalculateNextValue(result);
            }

            return result.Length.ToString();
        }

    }
}
