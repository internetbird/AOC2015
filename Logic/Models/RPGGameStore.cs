using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGGameStore
    {
        public List<RPGWeapon> GetAvailableWeapons()
        {
            var weapons = new List<RPGWeapon> {
                new RPGWeapon("Dagger", 4, 8),
                new RPGWeapon("Shortsword", 5, 10),
                new RPGWeapon("Warhammer", 6, 25),
                new RPGWeapon("Longsword", 7, 40),
                new RPGWeapon("Greataxe", 8, 74),
            };

            return weapons;
        }

        public List<RPGArmor> GetAvailbaleArmors()
        {
            var armors = new List<RPGArmor> { 
                new RPGArmor("Leather", 1 , 13),
                new RPGArmor("Chainmail", 2 ,31),
                new RPGArmor("Splintmail",3, 53),
                new RPGArmor("Bandedmail", 4 , 75),
                new RPGArmor("Platemail", 5 , 102)
            };

            return armors;
        }

        public List<RPGRing> GetAvailableRings()
        {
            var rings = new List<RPGRing> { 
                new RPGRing("Damage +1", 1, 0, 25),
                new RPGRing("Damage +2", 2, 0, 50),
                new RPGRing("Damage +3", 3, 0, 100),
                new RPGRing("Defense +1", 0, 1, 20),
                new RPGRing("Defense +2", 0, 2, 40),
                new RPGRing("Defense +3", 0, 3, 80)
            };

            return rings;
        }
    }
}
