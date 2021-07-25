using AOC2015.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AOC2015.PuzzleSolvers
{
    public class Day22PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int minManaSpentToWin = int.MaxValue;
            int numOfManaSpentRecords = 0;
            int gameNum = 1;
            int minBossHitPoints = int.MaxValue;


            while (numOfManaSpentRecords < 10)
            {
                var player = new RPGWizardPlayer(50, 500, new RPGGameStore().GetAvailableSpells());
                var boss = new RPGStaticPlayer(71, 10, 0);

                /*   var player = new RPGWizardPlayer(10, 250, new RPGGameStore().GetAvailableSpells());
                   var boss = new RPGStaticPlayer(14, 8, 0);*/

                var game = new RPGWizardGame(player, boss);

                if (gameNum % 1000000 == 0)
                {
                    Console.WriteLine($"Starting Game #{gameNum}");
                }

                RPGPlayerBase winner = game.PlayGame();

                if (winner == player)
                {
                    if (player.TotalManaSpent < minManaSpentToWin)
                    {
                        Console.WriteLine($"I won for {player.TotalManaSpent} mana !");
                        minManaSpentToWin = player.TotalManaSpent;
                        numOfManaSpentRecords++;
                    }
                }
                else
                {
                    if (boss.HitPoints < minBossHitPoints)
                    {
                        minBossHitPoints = boss.HitPoints;
                        Console.WriteLine($"New boss min hit points : {minBossHitPoints}");
                    }

                    if (gameNum % 1000000 == 0)
                    {
                        Console.WriteLine($"I Lost!  My Hit Points : {player.HitPoints}, My Mana: {player.Mana}, Boss Hit Points: {boss.HitPoints}");
                    }
                }

                gameNum++;
            }
            return minManaSpentToWin.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
