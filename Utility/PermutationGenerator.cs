using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.Utility
{
    public class PermutationGenerator
    {
        public List<string[]> ListAllPermutations(string[] input)
        {
            var permutations = new List<string[]>();

            if (input.Length == 1)
            {
                return new List<string[]> { input };
            }


            for (int i = 0; i < input.Length; i++)
            {

                var currItem = input[i];
                var listWithoutCurrItem = new List<string>(input);
                listWithoutCurrItem.Remove(currItem);

                List<string[]> subArrayPermutations = ListAllPermutations(listWithoutCurrItem.ToArray());

                foreach (string[] item in subArrayPermutations)
                {
                    string[] fullPermutationArray = item.PrependItem(input[i]);
                    permutations.Add(fullPermutationArray);
                }
            }

            return permutations;
        }

        public List<string[]> ListAllCircularPermutations(string[] input)
        {
            if (input.Length < 2)
            {
                return new List<string[]> { input };
            }

            var firstItem = input[0];

            var arrayWithoutFirstItem = input.SubArray(1, input.Length - 1);

            List<string[]> permutationsWithoutFirstItem = ListAllPermutations(arrayWithoutFirstItem);

            return permutationsWithoutFirstItem
                .Select(permutation => permutation.PrependItem(firstItem))
                .ToList();
        }

    }
}
