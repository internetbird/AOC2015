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
            Dictionary<string, WireCircuitExpression> instructions = GetWireCircuitInstructionInput();

            var wireCircuit = new WireCircuit(instructions);

            return wireCircuit.EvaulateWireSignal("a").ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, WireCircuitExpression>  GetWireCircuitInstructionInput()
        {
            var instructions = new Dictionary<string, WireCircuitExpression>();

            var fullInputFilePath = Path.GetFullPath("InputFiles/day7.txt");
            string[] inputStrings = File.ReadAllLines(fullInputFilePath);

            for (int i = 0; i < inputStrings.Length; i++)
            {
                var builder = new WireCircuitInstructionBuilder();
                WireCircuitInstruction instruction = builder.BuildInstruction(inputStrings[i]);
                instructions.Add(instruction.AssignedWireId, instruction.Expression);
            }

            return instructions;
        }
    }
}
