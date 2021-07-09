using AOC2015.Logic.Builders;
using AOC2015.Logic.Models;
using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day16PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            List<AuntSue> allAunts = GetInputAunts();

            int auntId = FindAuntMatch(allAunts);
            return auntId.ToString();
        }

        private static List<AuntSue> GetInputAunts()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day16.txt");

            var allAunts = new List<AuntSue>();

            var builder = new AuntSueBuilder();

            foreach (string inputLine in inputLines)
            {
                AuntSue newAunt = builder.Build(inputLine);
                allAunts.Add(newAunt);
            }

            return allAunts;
        }

        private int FindAuntMatch(List<AuntSue> allAunts)
        {
            List<AuntSue> matchedAunts = new List<AuntSue>(allAunts);
            Dictionary<string, int> propertiesToMatch = new Dictionary<string, int>
            {
                {"children", 3 },
                {"cats", 7 },
                {"samoyeds", 2},
                {"pomeranians", 3},
                {"vizslas", 0 },
                {"akitas", 0 },
                {"goldfish", 5 },
                {"trees", 3 },
                {"cars", 2 },
                {"perfumes", 1 }
            };

            foreach (KeyValuePair<string, int> property in propertiesToMatch)
            {
                matchedAunts = matchedAunts.FindAll(aunt =>
                        !aunt.Properties.ContainsKey(property.Key) || aunt.Properties[property.Key] == property.Value);
            }

            return matchedAunts[0].Id;
        }

        private int FindAuntMatchWithRanges(List<AuntSue> allAunts)
        {
            List<AuntSue> matchedAunts = new List<AuntSue>(allAunts);
            Dictionary<string, int> propertiesToMatch = new Dictionary<string, int>
            {
                {"children", 3 },
                {"cats", 7 },
                {"samoyeds", 2},
                {"pomeranians", 3},
                {"vizslas", 0 },
                {"akitas", 0 },
                {"goldfish", 5 },
                {"trees", 3 },
                {"cars", 2 },
                {"perfumes", 1 }
            };

            foreach (KeyValuePair<string, int> property in propertiesToMatch)
            {
                if (property.Key == "cats" || property.Key == "trees")
                {
                    matchedAunts = matchedAunts.FindAll(aunt =>
                    !aunt.Properties.ContainsKey(property.Key) || aunt.Properties[property.Key] > property.Value);

                } else if (property.Key == "pomeranians" || property.Key == "goldfish")
                {
                    matchedAunts = matchedAunts.FindAll(aunt =>
                 !aunt.Properties.ContainsKey(property.Key) || aunt.Properties[property.Key] < property.Value);

                } else
                {
                    matchedAunts = matchedAunts.FindAll(aunt =>
                     !aunt.Properties.ContainsKey(property.Key) || aunt.Properties[property.Key] == property.Value);
                }
            }

            return matchedAunts[0].Id;
        }


        public string SolvePuzzlePart2()
        {
            List<AuntSue> allAunts = GetInputAunts();

            int auntId = FindAuntMatchWithRanges(allAunts);
            return auntId.ToString();
        }
    }
}
