using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Utility
{
    public static class StringExtensions
    {
        public static bool HasStraightThreeLetters(this string input)
        {
            for (int i = 0; i < input.Length-2; i++)
            {
                if ((input[i+1] == input[i] + 1) && (input[i + 2] == input[i + 1] + 1))
                {
                    return true;
                }
            }
            return false;
        }


        public static bool ContainsTwoDifferentLetterPairs(this string input)
        {

            bool firstPairFound = false;
            char firstPairChar = default(char);


            for (int i = 0; i < input.Length - 1; i++)
            {
                if(input[i] == input[i+1])
                {
                    if (!firstPairFound)
                    {
                        firstPairFound = true;
                        firstPairChar = input[i];

                    } else
                    {
                        if (input[i] != firstPairChar)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
