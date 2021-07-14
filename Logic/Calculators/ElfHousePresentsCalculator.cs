using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Calculators
{
    public class ElfHousePresentsCalculator
    {
        public int CalculateNumOfPresentsForHouse(int houseNum)
        {

            int numOfPresents = 0;

            for (int i = 1; i <= houseNum / 2; i++)
            {
                if (houseNum % i == 0)
                {
                    numOfPresents += (i * 10);
                }
            }

            numOfPresents += (houseNum * 10);

            return numOfPresents;
        }
    }
}
