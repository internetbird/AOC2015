using AOC;
using AOC2015.Logic.Builders;
using AOC2015.Logic.Models;
using AOC2015.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2015.PuzzleSolvers
{
    public class Day19PuzzleSolver : IPuzzleSolver
    {

        private const string MedicineMolecule = "CRnSiRnCaPTiMgYCaPTiRnFArSiThFArCaSiThSiThPBCaCaSiRnSiRnTiTiMgArPBCaPMgYPTiRnFArFArCaSiRnBPMgArPRnCaPTiRnFArCaSiThCaCaFArPBCaCaPTiTiRnFArCaSiRnSiAlYSiThRnFArArCaSiRnBFArCaCaSiRnSiThCaCaCaFYCaPTiBCaSiThCaSiThPMgArSiRnCaPBFYCaCaFArCaCaCaCaSiThCaSiRnPRnFArPBSiThPRnFArSiRnMgArCaFYFArCaSiRnSiAlArTiTiTiTiTiTiTiRnPMgArPTiTiTiBSiRnSiAlArTiTiRnPMgArCaFYBPBPTiRnSiRnMgArSiThCaFArCaSiThFArPRnFArCaSiRnTiBSiThSiRnSiAlYCaFArPRnFArSiThCaFArCaCaSiThCaCaCaSiRnPRnCaFArFYPMgArCaPBCaPBSiRnFYPBCaFArCaSiAl";

        public string SolvePuzzlePart1()
        {
            List<string> distinctMolecules = new List<string>();
            List<Transition> moleculeTransitions = GetInputMoleculeTransitions();

            foreach (Transition transition in moleculeTransitions)
            {
                string moleculeToReplace = transition.From;
                MatchCollection matches = Regex.Matches(MedicineMolecule, moleculeToReplace);

                foreach (Match match in matches)
                {
                    var sb = new StringBuilder(MedicineMolecule);

                    sb.Remove(match.Index, moleculeToReplace.Length);
                    sb.Insert(match.Index, transition.To);

                    if (!distinctMolecules.Contains(sb.ToString()))
                    {
                        distinctMolecules.Add(sb.ToString());
                    }
                }
            }
            return distinctMolecules.Count.ToString();
        }

        private static List<Transition> GetInputMoleculeTransitions(string fileName = "day19.txt")
        {
            var builder = new MoleculeTransitionBuilder();
            string[] inputLines = InputFilesHelper.GetInputFileLines(fileName);
            List<Transition> moleculeTransitions = builder.Build(inputLines);
            return moleculeTransitions;
        }

        public string SolvePuzzlePart2()
        {
            List<Transition> moleculeTransitions = GetInputMoleculeTransitions();
            string currMolecule = "e";

            List<string> allPossibleMolecules = GetAllPossibleMoleculesBySingleTransition(currMolecule, moleculeTransitions);
            int numOfTransitions = 1;

            var searchedMolecules = new List<string>();

            while (!allPossibleMolecules.Contains(MedicineMolecule))
            {
                searchedMolecules.AddRange(allPossibleMolecules);
                allPossibleMolecules = GetAllPossibleMoleculesBySingleTransition(allPossibleMolecules, moleculeTransitions)
                  .Distinct()
                  .Where(m => m.Length <= MedicineMolecule.Length)
                  .OrderByDescending(m => GetMatchScore(m))
                  .Take(1000)
                  .ToList();

                numOfTransitions++;
                PrintMolecules(numOfTransitions, allPossibleMolecules);
            }

            return numOfTransitions.ToString();
        }

        private int GetMatchScore(string molecule)
        {
            int matchScore = 0;

            for (int i = 0; i < molecule.Length; i++)
            {
                if(molecule[i] == MedicineMolecule[i])
                {
                    matchScore++;
                } else
                {
                    return matchScore;
                }
            }

            return matchScore;


        }

        private void PrintMolecules(int numOfTransitions, List<string> allPossibleMolecules)
        {
            Console.WriteLine($"# Of Transitions : {numOfTransitions}");
            Console.WriteLine("---------------------------------------");

            int counter = 1;
            foreach (string molecule in allPossibleMolecules)
            {
                Console.Write($"Molecule #{counter} :");

                for (int i = 0; i < molecule.Length; i++)
                {
                    if (molecule[i] == MedicineMolecule[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(molecule[i]);
                }

                Console.ForegroundColor = ConsoleColor.White;

                

                Console.Write($"[{molecule.Length} / {MedicineMolecule.Length}] \n");
                counter++;
            }
        }

        private List<string> GetAllPossibleMoleculesBySingleTransition(List<string> molecules, List<Transition> moleculeTransitions)
        {
            var allPossibleMolecules = new List<string>();

            foreach (string molecule in molecules)
            {
                List<string> possibleMolecules = GetAllPossibleMoleculesBySingleTransition(molecule, moleculeTransitions);
                allPossibleMolecules.AddRange(possibleMolecules);
            }

            return allPossibleMolecules;
        }

        private List<string> GetAllPossibleMoleculesBySingleTransition(string originMolecule, List<Transition> transitions)
        {
          var resultMolecules = new List<string>();

            foreach (Transition transition in transitions)
            {
                string moleculeToReplace = transition.From;
                MatchCollection matches = Regex.Matches(originMolecule, moleculeToReplace);

                foreach (Match match in matches)
                {
                    var sb = new StringBuilder(originMolecule);

                    sb.Remove(match.Index, moleculeToReplace.Length);
                    sb.Insert(match.Index, transition.To);


                    //Only add molecules that do not decrease the score
                    if (originMolecule.Length <= 10 || (GetMatchScore(sb.ToString()) >= GetMatchScore(originMolecule)))
                    {
                        if (!resultMolecules.Contains(sb.ToString()))
                        {
                            resultMolecules.Add(sb.ToString());
                        }
                    }
                }
            }

            return resultMolecules;

        }

    }
}
