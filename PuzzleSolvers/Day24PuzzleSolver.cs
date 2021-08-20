using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day24PuzzleSolver : IPuzzleSolver
    {
        private int _minNumOfItems = int.MaxValue;
        private ulong _minMultiplier = ulong.MaxValue;


        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day24.txt");

            List<ulong> weights = inputLines.Select(line => ulong.Parse(line)).ToList();

            int solutionsCounter = 0;
            var random = new Random();
            ulong weightForEachGroup = weights.Sum() / 3;

            while (solutionsCounter < 1000)
            {
                var groups = new List<List<ulong>>
                {
                     new List<ulong>(),
                     new List<ulong>(),
                     new List<ulong>()
                };

                foreach (ulong weight in weights)
                {
                    int randomGroupIndex = random.Next(3);

                    List<ulong> choosenGroup = groups[randomGroupIndex];
                  
                    if (choosenGroup.Sum() + weight <= weightForEachGroup)
                    {
                        choosenGroup.Add(weight);

                    }
                    else if (groups[(randomGroupIndex + 1) % 3].Sum() + weight <= weightForEachGroup)
                    {
                        groups[(randomGroupIndex + 1) % 3].Add(weight);
                    }
                    else
                    {
                        groups[(randomGroupIndex + 2) % 3].Add(weight);
                    }
                }

                if (groups[0].Sum() ==  groups[1].Sum() && groups[1].Sum() == groups[2].Sum())
                {
                    solutionsCounter++;

                    List<ulong> minSizeGroup = GetMinSizeGroup(groups);

                    if (minSizeGroup.Count < _minNumOfItems)
                    {
                        _minNumOfItems = minSizeGroup.Count;
                        _minMultiplier = minSizeGroup.Multiply();

                        Console.WriteLine($"Found new min size group with size : {_minNumOfItems} and QE : {minSizeGroup.Multiply()}");

                    } else if (minSizeGroup.Count == _minNumOfItems &&  minSizeGroup.Multiply() < _minMultiplier)
                    {
                        _minMultiplier = minSizeGroup.Multiply();
                        Console.WriteLine($"Found a new QE min : { minSizeGroup.Multiply()} for group size : {minSizeGroup.Count}");
                    }
                }

            }

            return _minMultiplier.ToString();
        }

        private List<ulong> GetMinSizeGroup(List<List<ulong>> groups)
        {
            return groups.OrderBy(group => group.Count).First();
        }


        public string SolvePuzzlePart2()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day24.txt");

            List<ulong> weights = inputLines.Select(line => ulong.Parse(line)).ToList();

            int solutionsCounter = 0;
            var random = new Random();
            ulong weightForEachGroup = weights.Sum() / 4;

            while (solutionsCounter < 1000)
            {
                var groups = new List<List<ulong>>
                {
                     new List<ulong>(),
                     new List<ulong>(),
                     new List<ulong>(),
                     new List<ulong>()
                };

                foreach (ulong weight in weights)
                {
                    int randomGroupIndex = random.Next(4);

                    List<ulong> choosenGroup = groups[randomGroupIndex];

                    if (choosenGroup.Sum() + weight <= weightForEachGroup)
                    {
                        choosenGroup.Add(weight);

                    }
                    else if (groups[(randomGroupIndex + 1) % 4].Sum() + weight <= weightForEachGroup)
                    {
                        groups[(randomGroupIndex + 1) % 4].Add(weight);
                    }
                    else if (groups[(randomGroupIndex + 2) % 4].Sum() + weight <= weightForEachGroup)
                    {
                        groups[(randomGroupIndex + 2) % 4].Add(weight);
                    }
                    else
                    {
                        groups[(randomGroupIndex + 3) % 4].Add(weight);
                    }
                }

                if (groups[0].Sum() == groups[1].Sum() 
                    && groups[1].Sum() == groups[2].Sum() 
                    && groups[2].Sum() == groups[3].Sum())
                {
                    solutionsCounter++;

                    List<ulong> minSizeGroup = GetMinSizeGroup(groups);

                    if (minSizeGroup.Count < _minNumOfItems)
                    {
                        _minNumOfItems = minSizeGroup.Count;
                        _minMultiplier = minSizeGroup.Multiply();

                        Console.WriteLine($"Found new min size group with size : {_minNumOfItems} and QE : {minSizeGroup.Multiply()}");

                    }
                    else if (minSizeGroup.Count == _minNumOfItems && minSizeGroup.Multiply() < _minMultiplier)
                    {
                        _minMultiplier = minSizeGroup.Multiply();
                        Console.WriteLine($"Found a new QE min : { minSizeGroup.Multiply()} for group size : {minSizeGroup.Count}");
                    }
                }
            }

            return _minMultiplier.ToString();
        }
    }
}
