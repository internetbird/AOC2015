using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.Logic.Calculators
{
    public class ContainerCombinationsCalculator
    {
        public int CalculateNumOfCombinationsFor(List<int> containers, int amoutToContain)
        {
            var containerCombinations = GetContainerCombinationsFor(containers, amoutToContain);
            return containerCombinations.Count;
        }

        public int CalculateNumOfMinSizeContainerCombinationsFor(List<int> containers, int amoutToContain)
        {
            var containerCombinations = GetContainerCombinationsFor(containers, amoutToContain);
            int minContainerCombinationSize = containerCombinations.Min(combination => combination.Count);

            return containerCombinations.Count(combination => combination.Count == minContainerCombinationSize);
        }

        private List<List<int>> GetContainerCombinationsFor(List<int> containers, int amoutToContain)
        {
            var combinations = new List<List<int>>();

            int numOfContainers = containers.Count;

            for (int i = 1; i < Math.Pow(2, (double)numOfContainers) - 1; i++)
            {
                string bitStr = Convert.ToString(i, 2).PadLeft(containers.Count, '0');

                int containerSum = GetContainersSum(containers, bitStr);

                if (containerSum == amoutToContain)
                {
                    combinations.Add(GetCombinationForBitStr(bitStr, containers));
                }
            }


            return combinations;
        }

        private List<int> GetCombinationForBitStr(string bitStr, List<int> containers)
        {

            var combination = new List<int>();

            for (int i = 0; i < bitStr.Length; i++)
            {
                if (bitStr[i] == '1')
                {
                    combination.Add(containers[i]);
                }
            }
            return combination;
        }

        private int GetContainersSum(List<int> containers, string bitStr)
        {
            int containersSum = 0;

            for (int i = 0; i < bitStr.Length; i++)
            {
                if (bitStr[i] == '1')
                {
                    containersSum += containers[i];
                }
            }

            return containersSum;
        }
    }
}
