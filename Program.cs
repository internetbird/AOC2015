using AOC2015.PuzzleSolvers;
using System;
using System.IO;
using System.Linq;

namespace AOC2015
{
    class Program
    {
        static void Main(string[] args)
        {
            IPuzzleSolver solver = new Day14PuzzleSolver();

            var solution = solver.SolvePuzzlePart2();

            Console.WriteLine($"The solution to the puzzle is: {solution}");

            Console.ReadKey();
        }
    }
}
