using AOC2015.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Builders
{
    public class RPGEquipmentBuilder
    {
        public List<RPGEquipment> BuildAllPossibleStoreEquipmentCombinations(RPGGameStore store)
        {
            var equipmentCombinations = new List<RPGEquipment>();

            List<RPGWeapon> availableWeapons = store.GetAvailableWeapons();
            List<RPGArmor> availableArmors = store.GetAvailbaleArmors();

            availableArmors.Add(null); //Add the option of not equiping with an armor

            List<List<RPGRing>> ringCombinations = GetRingCombinations(store);

            foreach (RPGWeapon weapon in availableWeapons)
            {
                foreach (RPGArmor armor in availableArmors)
                {
                    foreach (List<RPGRing> ringCombination in ringCombinations)
                    {
                        var equipment = new RPGEquipment();
                        equipment.Weapon = weapon;
                        equipment.Armor = armor;

                        if (ringCombination.Count > 0)
                        {
                            equipment.RightHandRing = ringCombination[0];

                            if (ringCombination.Count > 1)
                            {
                                equipment.LeftHandRing = ringCombination[1];
                            }
                        }

                        equipmentCombinations.Add(equipment);
                    }
                }
            }

            return equipmentCombinations;
        }

        private List<List<RPGRing>> GetRingCombinations(RPGGameStore store)
        {
            List<RPGRing> availableRings = store.GetAvailableRings();

            var ringCombinations = new List<List<RPGRing>>();

            ringCombinations.Add(new List<RPGRing>()); //No rings

            //single ring
            foreach (RPGRing ring in availableRings)
            {
                ringCombinations.Add(new List<RPGRing> { ring });
            }

            //two rings
            foreach (RPGRing ring in availableRings)
            {
                var twoRings = new List<RPGRing>();

                twoRings.Add(ring);

                var leftOverRings = new List<RPGRing>(availableRings);
                leftOverRings.Remove(ring);

                foreach (RPGRing leftOverRing in leftOverRings)
                {
                    twoRings.Add(leftOverRing);
                    ringCombinations.Add(twoRings);
                }
            }
            return ringCombinations;
        }
    }
}
