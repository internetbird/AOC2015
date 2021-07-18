using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGWizardPlayer : RPGPlayerBase
    {
        public int Mana { get;  private set; }

        public int HitPoints { get; private set; }

        private List<RPGSpell> _activeRPGSpells;

        public RPGWizardPlayer(int initialHitPoints, int initalMana)
        {
            HitPoints = initialHitPoints;
            Mana = initalMana;

            _activeRPGSpells = new List<RPGSpell>();
        }

        public override int GetPlayerDamage()
        {
            throw new NotImplementedException();
        }

        public override int GetPlayerArmor()
        {
            throw new NotImplementedException();
        }
    }
}
