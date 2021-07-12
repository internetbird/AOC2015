using AOC2015.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Builders
{
    public class MoleculeTransitionBuilder
    {
        public List<Transition> Build(string[] inputLines)
        {
            var moleculeTransitions = new List<Transition>();

            foreach(string line in inputLines)
            {
                string[] lineParts = line.Split("=>");

                var transition = new Transition
                {
                    From = lineParts[0].Trim(),
                    To = lineParts[1].Trim()
                };

                moleculeTransitions.Add(transition);
            }
            return moleculeTransitions;
        }
    }
}
