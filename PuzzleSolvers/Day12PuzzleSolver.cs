using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2015.PuzzleSolvers
{
    public class Day12PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {

            var inputText = InputFilesHelper.GetInputFileText("day12.txt");

            var numberRegex = new Regex(@"-?\d+");

            MatchCollection matches =  numberRegex.Matches(inputText);

           int sum =  matches.Sum(match => int.Parse(match.Value));

            return sum.ToString();
        }

        public string SolvePuzzlePart2()
        {
            var inputText = InputFilesHelper.GetInputFileText("day12.txt");
            var redObjectsRegex = new Regex(@":""red""");

            Match redObjectMatch = redObjectsRegex.Match(inputText);

            while (redObjectMatch.Success)
            {
                int startBracetIndex = inputText.LastIndexOf("{", redObjectMatch.Index);

                int endBracetIndex = FindEndBracetIndex(startBracetIndex, inputText);

                var sectionToRemove = inputText.Substring(startBracetIndex, (endBracetIndex - startBracetIndex + 1));

                inputText = inputText.Remove(startBracetIndex, (endBracetIndex - startBracetIndex + 1));

                redObjectMatch = redObjectsRegex.Match(inputText);
            }

            var numberRegex = new Regex(@"-?\d+");

            MatchCollection matches = numberRegex.Matches(inputText);

            int sum = matches.Sum(match => int.Parse(match.Value));

            return sum.ToString();
        }

        private int FindEndBracetIndex(int startBracetIndex, string inputText)
        {
            int innerBracetsCounter = 0;

            for (int i = startBracetIndex + 1; i < inputText.Length; i++)
            {
                if (inputText[i] == '{')
                {
                    innerBracetsCounter++;
                }

                if (inputText[i] == '}')
                {
                    if (innerBracetsCounter == 0)
                    {
                        return i;

                    } else
                    {
                        innerBracetsCounter--;
                    }
                }
            }

            return -1;
        }
    }
}
