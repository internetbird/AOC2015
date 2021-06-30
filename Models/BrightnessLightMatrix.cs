using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class BrightnessLightMatrix
    {

        private int[,] _lightMatrix;

        private int _numOfRows;
        private int _numOfColumns;

        public BrightnessLightMatrix(int rows = 1000, int columns = 1000)
        {
            _lightMatrix = new int[rows, columns];

            _numOfRows = rows;
            _numOfColumns = columns;
        }

        public void ExecuteInstruction(LightInstruction instruction)
        {

            for (int i = instruction.StartCoordinate.X; i <= instruction.EndCoordinate.X; i++)
            {
                for (int j = instruction.StartCoordinate.Y; j <= instruction.EndCoordinate.Y; j++)
                {
                    if (instruction.Command == LightInstructionCommand.TurnOn)
                    {
                        _lightMatrix[i, j]++;
                    }
                    else if (instruction.Command == LightInstructionCommand.TurnOff)
                    {
                        if (_lightMatrix[i, j] > 0)
                        {
                            _lightMatrix[i, j]--;
                        }
                    }
                    else //Toggle
                    {
                        _lightMatrix[i, j] += 2;
                    }
                }
            }
        }


        public int GetTotalBrightness()
        {
            int brightnessSum = 0;
            for (int i = 0; i < _numOfRows; i++)
            {
                for (int j = 0; j < _numOfColumns; j++)
                {
                   brightnessSum = brightnessSum + _lightMatrix[i,j];
                }
            }
            return brightnessSum;
        }
    }
}
