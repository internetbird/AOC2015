using AOC2015.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day22PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int minManaSpentToWin = 0;

            var player = new RPGWizardPlayer(50, 500);
            var boss = new RPGStaticPlayer(71, 10, 0);


            var game = new RPGWizardGame(player, boss);




            return minManaSpentToWin.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
