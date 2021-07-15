using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGPlayer
    {
        public RPGEquipment Equipement { get; private set; }
        public int HitPoints { get; private set; }

        public RPGPlayer(int initalHitPoints, RPGEquipment equipment)
        {
            HitPoints = initalHitPoints;
            Equipement = equipment;
        }

        public virtual int GetPlayerDamageScore()
        {

            if (Equipement.Weapon == null)
            {
                throw new Exception("Weapon was not set for this player!");
            }

            int damageScore = Equipement.Weapon.Damage;

            if (Equipement.RightHandRing != null)
            {
                damageScore += Equipement.RightHandRing.Damage;

                if (Equipement.LeftHandRing != null)
                {
                    damageScore += Equipement.LeftHandRing.Damage;
                }
            }
            return damageScore;
        }

        public void DealDamage(int currAttackDamage)
        {
            HitPoints -= currAttackDamage;
        }

        public virtual int GetPlayerArmorScore()
        {
            int armorScore = 0;

            if (Equipement.Armor != null)
            {
                armorScore += Equipement.Armor.Armor;
            }

            if (Equipement.RightHandRing != null)
            {
                armorScore += Equipement.RightHandRing.Armor;

                if (Equipement.LeftHandRing != null)
                {
                    armorScore += Equipement.LeftHandRing.Armor;
                }
            }

            return armorScore;
        }

    }
}
