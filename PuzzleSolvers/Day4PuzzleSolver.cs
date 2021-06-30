using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    public class Day4PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            for (int i = 1; i < 1000000; i++) //Hopefuly it will found between 1 and 1000000
            {
                var md5Hash = CryptographyHelper.CreateMD5Hash($"ckczppom{i}");

                if (md5Hash.StartsWith("00000"))
                {
                    return i.ToString();
                }
            }

            return "Not Found";
        }

        public string SolvePuzzlePart2()
        {
            for (int i = 1; i < 10000000; i++) //Hopefuly it will found between 1 and 1000000
            {
                var md5Hash = CryptographyHelper.CreateMD5Hash($"ckczppom{i}");

                if (md5Hash.StartsWith("000000"))
                {
                    return i.ToString();
                }
            }

            return "Not Found";
        }


       
    }
}
