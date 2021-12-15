using AOC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2015
{
    public class Day5PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int numOfNiceStrings = 0;

            string[] inputStrings = GetInputStrings();

            foreach (string item in inputStrings)
            {
                if (item.Contains("ab") || item.Contains("cd") || item.Contains("pq") || item.Contains("xy"))
                {
                    continue;
                }

                int numOfVowels = 0;
                bool hasDuplicateLetter = false;

                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == 'a' || item[i] == 'e' || item[i] == 'i' || item[i] == 'o' || item[i] == 'u') {
                        numOfVowels++;
                    }

                    if (i < (item.Length - 1) && item[i] == item[i+1])
                    {
                        hasDuplicateLetter = true;

                    }
                }

                if (numOfVowels >= 3 && hasDuplicateLetter)
                {
                    numOfNiceStrings++;
                }
            }
           

            return numOfNiceStrings.ToString();
        }

        public string SolvePuzzlePart2()
        {
            int numOfNiceStrings = 0;

            string[] inputStrings = GetInputStrings();

            foreach (string item in inputStrings)
            {
                bool hasDuplicateTwoLetters = false;
                bool hasOneLetterRepeat = false;


                for (int i = 0; i < item.Length; i++)
                {
                    if (i < item.Length - 3)
                    {
                        string twoLetters = item.Substring(i, 2);
                        if (item.Substring(i+2).Contains(twoLetters))
                        {
                            hasDuplicateTwoLetters = true;
                        }
                    }

                    if (i < item.Length - 2)
                    {
                        if (item[i] == item[i+2])
                        {
                            hasOneLetterRepeat = true;
                        }
                    }
                }

                if (hasDuplicateTwoLetters && hasOneLetterRepeat)
                {
                    numOfNiceStrings++;
                }

            }

            return numOfNiceStrings.ToString();
        }

        private string[] GetInputStrings()
        {
            var fullInputFilePath = Path.GetFullPath("InputFiles/day5.txt");
            string[] inputStrings = File.ReadAllLines(fullInputFilePath);

            return inputStrings;
        }
    }
}
