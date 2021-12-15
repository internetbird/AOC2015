using AOC;
using AOC2015.Logic.Builders;
using AOC2015.Logic.Models;
using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day18PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            bool[,] intiialState = GetInputInitialState("day18.txt");

            var automata = new LightsAutomata(intiialState);

            for (int i = 0; i < 100; i++) //Move the next state 100 times
            {
                automata.SwitchToNextState();
            }

            int numOfLightsThatAreOn = automata.GetNumOfLightsThatAreOn();
            return numOfLightsThatAreOn.ToString();
        }

      

        public string SolvePuzzlePart2()
        {
            bool[,] intiialState = GetInputInitialState("day18_2.txt");

            var automata = new LightsAutomata(intiialState);

            for (int i = 0; i < 100; i++) //Move the next state 100 times
            {
                automata.SwitchToNextStateWithStuckLights();
            }

            int numOfLightsThatAreOn = automata.GetNumOfLightsThatAreOn();
            return numOfLightsThatAreOn.ToString();
        }

        private static bool[,] GetInputInitialState(string fileName)
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines(fileName);

            var builder = new LightAutomataStateBuilder();
            bool[,] intiialState = builder.BuildState(inputLines);
            return intiialState;
        }
    }
}
