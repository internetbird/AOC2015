using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Builders
{
    public class LightAutomataStateBuilder
    {
        public bool[,] BuildState(string[] inputLines)
        {
            int automataSize = inputLines[0].Length;
            bool[,] automataState = new bool[automataSize, automataSize];

            for (int i = 0; i < automataSize; i++)
            {
                for (int j = 0; j < automataSize; j++)
                {
                    automataState[i, j] = (inputLines[i][j] == '#');
                }         
            }

            return automataState;
        }
    }
}
