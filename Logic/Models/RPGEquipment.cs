using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGEquipment
    {
        public RPGWeapon Weapon { get; set; }
        public RPGArmor Armor { get; set; }
        public RPGRing RightHandRing { get; set; }
        public RPGRing LeftHandRing { get; set; }

        public int GetTotalCost()
        {
            int totalCost = Weapon.Price;

            if (Armor != null)
            {
                totalCost += Armor.Price;
            }

            if (RightHandRing != null)
            {
                totalCost += RightHandRing.Price;
            }

            if (LeftHandRing != null)
            {
                totalCost += LeftHandRing.Price;
            }

            return totalCost;
        }
    }
}
