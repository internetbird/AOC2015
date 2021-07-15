using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGRing
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }
        public int Price { get; private set; }

        public RPGRing(string name, int damage, int armor, int price)
        {
            Name = name;
            Damage = damage;
            Armor = armor;
            Price = price;
        }
    }
}
