using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public abstract class RPGPlayerBase
    {
        public int HitPoints { get; protected set; }

        public abstract int GetPlayerDamage();
        public abstract int GetPlayerArmor();

        public void DealDamage(int currAttackDamage)
        {
            HitPoints -= currAttackDamage;
        }
    }
}
