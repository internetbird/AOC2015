using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2015.PuzzleSolvers
{
    public class Day8PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day8.txt");

            int totalCodeChars = 0, totalMemoryChars = 0;

            foreach (var input in inputLines)
            {
                totalCodeChars += input.Length;

                var stringWithoutQuotes = input.Substring(1, input.Length - 2);
                var unespacedString = Regex.Unescape(stringWithoutQuotes);

                totalMemoryChars += unespacedString.Length;
            }

            return (totalCodeChars - totalMemoryChars).ToString();
        }

        public string SolvePuzzlePart2()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day8.txt");

            int totalCodeChars = 0, totalEncodedChars = 0;

            foreach (var input in inputLines)
            {
                totalCodeChars += input.Length;

                int encodedInputLength = 0;

                for (int i = 0; i < input.Length; i++)
                {
                   if (input[i] == '"' || input[i] == '\\')
                    {
                        encodedInputLength += 2;

                    } else
                    {
                        encodedInputLength++;
                    }
                }

                encodedInputLength += 2; //Add the double quotes at the beginning and the end

                totalEncodedChars += encodedInputLength;
            }

            return (totalEncodedChars - totalCodeChars).ToString();
        }

    }
}
