using AOC2015.Models;
using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day13PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {

            var familyMembers = new string[] { "Alice", "Bob", "Carol", "David", "Eric", "Frank", "George", "Mallory" };
            string solution = SolveForFamilyMembers(familyMembers);
            return solution;
           
        }

        public string SolvePuzzlePart2()
        {
            var familyMembers = new string[] { "MySelf", "Alice", "Bob", "Carol", "David", "Eric", "Frank", "George", "Mallory" };
            string solution = SolveForFamilyMembers(familyMembers);
            return solution;
        }


        private string SolveForFamilyMembers(string[] familyMembers)
        {
            var inputLines = InputFilesHelper.GetInputFileLines("day13.txt");

            var calculator = new FamilyFeastHappinessCalculator(familyMembers, inputLines);

            var permutationGenerator = new PermutationGenerator();
            List<string[]> allCircularPermutations = permutationGenerator.ListAllCircularPermutations(familyMembers);
            int maxTotalHappiness = 0;

            foreach (string[] permutation in allCircularPermutations)
            {
                int seatingOrderHappiness = calculator.GetTotalHappinessForSeatingOrder(permutation);
                if (seatingOrderHappiness > maxTotalHappiness)
                {
                    maxTotalHappiness = seatingOrderHappiness;
                }
            }

            return maxTotalHappiness.ToString();
        }
    }
}
