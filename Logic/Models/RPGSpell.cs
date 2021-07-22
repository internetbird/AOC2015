using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGSpell
    {
        public string Name { get; private set; }
        public int ManaCost { get; private set; }
        public int Heal { get; private set; }
        public int Damange { get; private set; }
        public int Armor { get; private set; }
        public int ManaRecharge { get; private set; }
        public int LastsForTurns { get; private set; }
        public bool IsEffect => LastsForTurns > 1;

        public RPGSpell(string name, int manaCost, int heal, int damange, int armor, int manaRecharge, int numOfTurns)
        {
            Name = name;
            ManaCost = manaCost;
            Heal = heal;
            Damange = damange;
            Armor = armor;
            ManaRecharge = manaRecharge;
            LastsForTurns = numOfTurns;
        }
    }
}
