using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class LightsAutomata
    {
        private const int AutomataSize = 100;
        private bool[,] _state = new bool[AutomataSize, AutomataSize];

        public LightsAutomata(bool[,] initalState)
        {
            _state = initalState;
        }

        public void SwitchToNextState()
        {
            bool[,] newState = new bool[AutomataSize, AutomataSize];

            for (int i = 0; i < AutomataSize; i++)
            {
                for (int j = 0; j < AutomataSize; j++)
                {
                    //First take the old value and change it only if it is required
                    newState[i, j] = _state[i, j];

                    int numOfNeighboursThatAreOn = GetNumOfNeighboursThatAreOn(i, j);

                    if (_state[i,j]) //Current state is on
                    {
                        if (numOfNeighboursThatAreOn != 2 && numOfNeighboursThatAreOn != 3)
                        {
                            newState[i, j] = false;
                        }

                    } //Current is state is off
                    {
                        if (numOfNeighboursThatAreOn == 3)
                        {
                            newState[i, j] = true;
                        }
                    }
                }
            }
            _state = newState;
        }

        public void SwitchToNextStateWithStuckLights()
        {
            bool[,] newState = new bool[AutomataSize, AutomataSize];

            for (int i = 0; i < AutomataSize; i++)
            {
                for (int j = 0; j < AutomataSize; j++)
                {
                    //First take the old value and change it only if it is required
                    newState[i, j] = _state[i, j];

                    int numOfNeighboursThatAreOn = GetNumOfNeighboursThatAreOn(i, j);

                    if (_state[i, j]) //Current state is on
                    {
                        if (!IsStuckOnLight(i,j) && numOfNeighboursThatAreOn != 2 && numOfNeighboursThatAreOn != 3)
                        {
                            newState[i, j] = false;
                        }

                    } //Current is state is off
                    {
                        if (numOfNeighboursThatAreOn == 3)
                        {
                            newState[i, j] = true;
                        }
                    }
                }
            }
            _state = newState;
        }

        private bool IsStuckOnLight(int i, int j)
        {
            return (i == 0 && j == 0) ||
                (i == 0 && j == AutomataSize - 1) ||
                (i == AutomataSize - 1 && j == 0) || 
                (i == AutomataSize - 1 && j == AutomataSize - 1);
        }

        private int GetNumOfNeighboursThatAreOn(int i, int j)
        {

            var neighbourValues = new List<bool>();

            neighbourValues.Add(GetNeighbourValue(i - 1, j - 1));
            neighbourValues.Add(GetNeighbourValue(i - 1, j));
            neighbourValues.Add(GetNeighbourValue(i - 1, j + 1));
            neighbourValues.Add(GetNeighbourValue(i, j - 1));
            neighbourValues.Add(GetNeighbourValue(i, j + 1));
            neighbourValues.Add(GetNeighbourValue(i + 1, j - 1));
            neighbourValues.Add(GetNeighbourValue(i + 1, j));
            neighbourValues.Add(GetNeighbourValue(i + 1, j + 1));

            int valuesSum = neighbourValues.Sum(value => value ? 1 : 0);
            return valuesSum;
        }

        private bool GetNeighbourValue(int i, int j)
        {
           if (i < 0 || i > (AutomataSize - 1) || j < 0 || j > (AutomataSize - 1))
            {
                return false;
            }

            return _state[i, j];
        }

        public int GetNumOfLightsThatAreOn()
        {
            int numOfLightsThatAreOn = 0;
            
            for (int i = 0; i < AutomataSize; i++)
            {
                for (int j = 0; j < AutomataSize; j++)
                {
                    if (_state[i,j])
                    {
                        numOfLightsThatAreOn++;
                    }
                }
            }
            return numOfLightsThatAreOn;
        }
    }
}
