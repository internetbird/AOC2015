using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class SantaRouteCalculator
    {
        private string[] _citiesToVist = { "Tristram", "AlphaCentauri", "Snowdin", "Tambi", "Faerun", "Norrath", "Straylight", "Arbre" };

        private Dictionary<string, int> _distancesDictionary;

        public SantaRouteCalculator(Dictionary<string, int> distancesDictionary)
        {
            _distancesDictionary = distancesDictionary;
        }


        public int CalculateShortestRoute()
        {
            var permutationGenerator = new PermutationGenerator();

            List<string[]> allPossibleRoutes = permutationGenerator.ListAllPermutations(_citiesToVist);

            int shortestDistance = -1;

            foreach (string[] route in allPossibleRoutes)
            {
                int routeDistance = CalculateRouteDistance(route);

                if (shortestDistance < 0 || (routeDistance < shortestDistance))
                {
                    shortestDistance = routeDistance;
                }
            }

            return shortestDistance;
        }

        private int CalculateRouteDistance(string[] route)
        {
            int routeDistance = 0;

            for (int i = 0; i < route.Length - 1; i++)
            {
                int citiesDistance = GetCitiesDistance(route[i], route[i + 1]);
                routeDistance += citiesDistance;
            }

            return routeDistance;
        }

        private int GetCitiesDistance(string city1, string city2)
        {
            string keyOption1 = DistanceHelper.GetCitiesDictionaryKey(city1, city2);
            string keyOption2 = DistanceHelper.GetCitiesDictionaryKey(city2, city1);

            return _distancesDictionary.ContainsKey(keyOption1) ?
                _distancesDictionary[keyOption1] : _distancesDictionary[keyOption2];

        }
    }
}
