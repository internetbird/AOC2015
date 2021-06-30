using AOC2015.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day7PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            throw new NotImplementedException();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }

        private List<WireCircuitInstruction> GetWireCircuitInstructionInput()
        {
            var instructions = new List<WireCircuitInstruction>();

            var fullInputFilePath = Path.GetFullPath("InputFiles/day7.txt");
            string[] inputStrings = File.ReadAllLines(fullInputFilePath);



            return instructions;
        }
    }
}
