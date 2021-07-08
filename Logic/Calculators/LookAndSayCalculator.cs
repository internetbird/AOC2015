using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class LookAndSayCalculator
    {
        public string CalculateNextValue(string value)
        {

            var sb = new StringBuilder();
            char currDigit = value[0];
            int charCounter = 1;

            for (int i = 1; i < value.Length; i++)
            {
                if (value[i] != currDigit)
                {
                    sb.Append($"{charCounter}{currDigit}");
                    charCounter = 1;
                    currDigit = value[i];

                } else
                {
                    charCounter++;
                }
            }

            //Write out final output considering the last char
            sb.Append($"{charCounter}{currDigit}");

            return sb.ToString();
        }
    }
}
