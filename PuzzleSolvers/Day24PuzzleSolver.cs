using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day24PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day24.txt");

            List<ulong> weights = inputLines.Select(line => ulong.Parse(line)).ToList();
          
            bool solutionFound = false;
            List<ulong> groupA = null, groupB = null, groupC = null;

            var random = new Random();

            ulong weightForEachGroup = weights.Sum() / 3;
            
            while (!solutionFound)
            {
                groupA = new List<ulong>();
                groupB = new List<ulong>();
                groupC = new List<ulong>();


                foreach (ulong weight in weights)
                {
                    int randomGroup = random.Next(3);

                    if (randomGroup == 0) //Group A
                    {
                        if (groupA.Sum() + weight <= weightForEachGroup)
                        {
                            groupA.Add(weight);

                        }
                        else if (groupB.Sum() + weight <= weightForEachGroup)
                        {
                            groupB.Add(weight);
                        }
                        else
                        {
                            groupC.Add(weight);
                        }


                    }
                    else if (randomGroup == 1) //Group B
                    {
                        if (groupB.Sum() + weight <= weightForEachGroup)
                        {
                            groupB.Add(weight);

                        }
                        else if (groupA.Sum() + weight <= weightForEachGroup)
                        {
                            groupA.Add(weight);
                        }
                        else
                        {
                            groupC.Add(weight);
                        }
                    }
                    else //Group C
                    {
                        if (groupC.Sum() + weight <= weightForEachGroup)
                        {
                            groupC.Add(weight);

                        }
                        else if (groupB.Sum() + weight <= weightForEachGroup)
                        {
                            groupB.Add(weight);
                        }
                        else
                        {
                            groupA.Add(weight);
                        }
                    }
                }

                if (groupA.Sum() == groupB.Sum() && groupB.Sum() == groupC.Sum())
                {
                    solutionFound = true;
                }

            }

            ulong groupA_QE =  groupA.Multiply();
            ulong groupB_QE = groupB.Multiply();
            ulong groupC_QE = groupC.Multiply();

            return groupA.Count().ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
