using AOC2015.Logic.Builders;
using AOC2015.Logic.Models;
using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2015.PuzzleSolvers
{
    public class Day19PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
          
            string initialMolecule = "CRnSiRnCaPTiMgYCaPTiRnFArSiThFArCaSiThSiThPBCaCaSiRnSiRnTiTiMgArPBCaPMgYPTiRnFArFArCaSiRnBPMgArPRnCaPTiRnFArCaSiThCaCaFArPBCaCaPTiTiRnFArCaSiRnSiAlYSiThRnFArArCaSiRnBFArCaCaSiRnSiThCaCaCaFYCaPTiBCaSiThCaSiThPMgArSiRnCaPBFYCaCaFArCaCaCaCaSiThCaSiRnPRnFArPBSiThPRnFArSiRnMgArCaFYFArCaSiRnSiAlArTiTiTiTiTiTiTiRnPMgArPTiTiTiBSiRnSiAlArTiTiRnPMgArCaFYBPBPTiRnSiRnMgArSiThCaFArCaSiThFArPRnFArCaSiRnTiBSiThSiRnSiAlYCaFArPRnFArSiThCaFArCaCaSiThCaCaCaSiRnPRnCaFArFYPMgArCaPBCaPBSiRnFYPBCaFArCaSiAl";

            List<string> distinctMolecules = new List<string>();

            var builder = new MoleculeTransitionBuilder();
            string[] inputLines = InputFilesHelper.GetInputFileLines("day19.txt");
            List<Transition> moleculeTransitions = builder.Build(inputLines);


            foreach(Transition transition in moleculeTransitions)
            {
                string moleculeToReplace = transition.From;
                MatchCollection matches = Regex.Matches(initialMolecule, moleculeToReplace);

                foreach (Match match in matches)
                {
                    var sb = new StringBuilder(initialMolecule);

                    sb.Remove(match.Index, moleculeToReplace.Length);
                    sb.Insert(match.Index, transition.To);

                    if (!distinctMolecules.Contains(sb.ToString())){
                        distinctMolecules.Add(sb.ToString());
                    }
                }
            }
            return distinctMolecules.Count.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
