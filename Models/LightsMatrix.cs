using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class LightsMatrix
    {

        private bool[,] _lightMatrix;

        private int _numOfRows;
        private int _numOfColumns;

        public LightsMatrix(int rows = 1000, int columns = 1000)
        {
            _lightMatrix = new bool[rows, columns];

            _numOfRows = rows;
            _numOfColumns = columns;
        }


        public void ExecuteInstruction(LightInstruction instruction)
        {

        }

        public int GetNumOfActiveLights()
        {

            int numOfActiveLights = 0;

            for (int i = 0; i < _numOfRows; i++)
            {
                for (int j = 0; j < _numOfColumns; j++)
                {
                    if (_lightMatrix[i,j])
                    {
                        numOfActiveLights++;
                    }
                }
            }
            return numOfActiveLights;
        }
    }
}
