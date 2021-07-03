using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class DistanceDictionaryBuilder
    {
        public Dictionary<string, int> Build(string[] inputLines)
        {

            var dictionary = new Dictionary<string, int>();

            for (int i = 0; i < inputLines.Length; i++)
            {
                string[] lineParts =  inputLines[i].Split();

                string distanceKey =  DistanceHelper.GetCitiesDictionaryKey(lineParts[0], lineParts[2]);
                int distanceValue = int.Parse(lineParts[4]);

                dictionary.Add(distanceKey, distanceValue);
            }

            return dictionary;
        }
    }
}
