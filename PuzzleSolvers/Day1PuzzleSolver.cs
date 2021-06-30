using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class Day1PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var inputText = GetInputText();

            int numOfOpenParenthisis = inputText.Count(c => c == '(');
            int numOfCloseParenthisis = inputText.Count(c => c == ')');


            return (numOfOpenParenthisis - numOfCloseParenthisis).ToString();
        }

        public string SolvePuzzlePart2()
        {

            var currFloor = 0;

            var inputText = GetInputText();

            for (int i = 0; i < inputText.Length; i++)
            {
                if(inputText[i] == '(')
                {
                    currFloor++;

                } else
                {
                    currFloor--;
                }

                if (currFloor == -1)
                {
                    return "Basement position is:" + (i + 1);
                }
            }

            return "Could not find a solution!";
        }


        private string GetInputText()
        {
            var fullInputFilePath = Path.GetFullPath("InputFiles/day1.txt");
            var inputText = File.ReadAllText(fullInputFilePath);

            return inputText;
        }
    }
}
