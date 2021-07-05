using AOC2015.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day11PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            
            var passwordGenerator = new SantaPasswordGenerator();

            var nextPassowrd = passwordGenerator.GenerateNextPassword("hxbxwxba");

            return nextPassowrd;
        }

        public string SolvePuzzlePart2()
        {
            var passwordGenerator = new SantaPasswordGenerator();

            var nextPassowrd = passwordGenerator.GenerateNextPassword("hxbxxyzz");

            return nextPassowrd;
        }
    }
}
