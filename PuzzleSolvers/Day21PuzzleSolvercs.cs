using AOC;
using AOC2015.Logic.Builders;
using AOC2015.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day21PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int minGoldAmoutToWin = int.MaxValue;

            var builder = new RPGEquipmentBuilder();
            List<RPGEquipment> allEquipmentCombinations = builder.BuildAllPossibleStoreEquipmentCombinations(new RPGGameStore());

            foreach (RPGEquipment equipment in allEquipmentCombinations)
            {
                int equipmentTotalCost = equipment.GetTotalCost();

                if (equipmentTotalCost < minGoldAmoutToWin)
                {
                    RPGPlayer me = new RPGPlayer(100, equipment);
                    RPGPlayer boss = new RPGStaticPlayer(104, 8, 1);

                    var game = new RPGGame(me, boss);

                    RPGPlayer winner = game.PlayGame();
                    if (winner == me)
                    {
                        minGoldAmoutToWin = equipmentTotalCost;
                        Console.WriteLine($"I was able to win for: {minGoldAmoutToWin}");
                    }
                }
            }

            return minGoldAmoutToWin.ToString();
        }

        public string SolvePuzzlePart2()
        {
            int maxAmoutToLose = 0;

            var builder = new RPGEquipmentBuilder();
            List<RPGEquipment> allEquipmentCombinations = builder.BuildAllPossibleStoreEquipmentCombinations(new RPGGameStore());
            foreach (RPGEquipment equipment in allEquipmentCombinations)
            {
                int equipmentTotalCost = equipment.GetTotalCost();

                if (equipmentTotalCost > maxAmoutToLose)
                {
                    RPGPlayer me = new RPGPlayer(100, equipment);
                    RPGPlayer boss = new RPGStaticPlayer(104, 8, 1);

                    var game = new RPGGame(me, boss);

                    RPGPlayer winner = game.PlayGame();
                    if (winner == boss)
                    {
                        maxAmoutToLose = equipmentTotalCost;
                        Console.WriteLine($"I was able to lose for: {maxAmoutToLose}");
                    }
                }
            }

            return maxAmoutToLose.ToString();
        }

    }
}
