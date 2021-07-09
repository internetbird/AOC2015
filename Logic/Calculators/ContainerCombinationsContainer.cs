using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Calculators
{
    public class ContainerCombinationsContainer
    {
        public int CalculateNumOfCombinationsFor(List<int> containers, int amoutToContain)
        {
            int numOfCombinations = 0;
            int numOfContainers = containers.Count;

            for (int i = 1; i < Math.Pow(2, (double)numOfContainers) - 1; i++)
            {
               string bitStr = Convert.ToString(i, 2).PadLeft(containers.Count, '0');

                int containerSum = GetContainersSum(containers, bitStr);

                if (containerSum == amoutToContain)
                {
                    Console.WriteLine($"Found a sum combination for {bitStr}");
                    numOfCombinations++;
                }
            }

            return numOfCombinations;
          
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
