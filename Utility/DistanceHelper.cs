using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Utility
{
    public static class DistanceHelper
    {
        public static string GetCitiesDictionaryKey(string city1, string city2)
        {
            return $"{city1}#{city2}";
        }

    }
}
