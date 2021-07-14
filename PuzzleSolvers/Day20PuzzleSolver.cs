using AOC2015.Logic.Calculators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day20PuzzleSolver : IPuzzleSolver
    {
        private const int PuzzleInput = 36000000;

        public string SolvePuzzlePart1()
        {
            int solutionHouseNum = 0;
            int numOfPresents = 0;

            var calculator = new ElfHousePresentsCalculator();

            while(numOfPresents < PuzzleInput)
            {
                solutionHouseNum += 2;
                numOfPresents= calculator.CalculateNumOfPresentsForHouse(solutionHouseNum);

                if (solutionHouseNum % 10000 == 0)
                {
                    Console.WriteLine($"House #{solutionHouseNum} get {numOfPresents} presents");
                }
            }

            return solutionHouseNum.ToString(); ;
        }

        public string SolvePuzzlePart2()
        {
            int solutionHouseNum = 0;
            int numOfPresents = 0;

            var calculator = new ElfHousePresentsCalculator();

            while (numOfPresents < PuzzleInput)
            {
                solutionHouseNum++;
                numOfPresents = calculator.CalculateNumOfPresentsForHouseWith50Limit(solutionHouseNum);

                if (solutionHouseNum % 10000 == 0)
                {
                    Console.WriteLine($"House #{solutionHouseNum} get {numOfPresents} presents");
                }
            }

            return solutionHouseNum.ToString(); ;
        }
    }
}
