using AOC2015.Logic;
using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day23PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] programLines = InputFilesHelper.GetInputFileLines("day23.txt");

            var computer = new ChristmasComputer();
            computer.LoadProgram(programLines);
            computer.ExecuteProgram();

            int registerValue = computer.GetRegisterValue("b");

            return registerValue.ToString();
        }

        public string SolvePuzzlePart2()
        {
            string[] programLines = InputFilesHelper.GetInputFileLines("day23.txt");

            var initialRegisters = new Dictionary<string, int>
                        {
                            {"a", 1 },
                            {"b", 0 },
                        };


            var computer = new ChristmasComputer(initialRegisters);
            computer.LoadProgram(programLines);
            computer.ExecuteProgram();

            int registerValue = computer.GetRegisterValue("b");

            return registerValue.ToString();
        }
    }
}
