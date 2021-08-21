using AOC2015.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day25PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var codeGridGenerator = new CodeGridGenerator();

            ulong code = codeGridGenerator.GetCodeAtPosition(2978, 3083);

            return code.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
