using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGStaticPlayer : RPGPlayer
    {
        private int _damageScore;
        private int _armorScore;

        public RPGStaticPlayer(int initalHitPoints, int damageScore, int armorScore) : base(initalHitPoints, null)
        {
            _damageScore = damageScore;
            _armorScore = armorScore;
        }
  
        public override int GetPlayerArmor()
        {
            return _armorScore;
        }

        public override int GetPlayerDamage()
        {
            return _damageScore;
        }
    }
}
