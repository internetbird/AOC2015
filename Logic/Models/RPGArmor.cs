using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class RPGArmor
    {
        public string Name { get; private set; }
        public int Armor { get; private set; }
        public int Price { get; private set; }


        public RPGArmor(string name, int armor, int price)
        {
            Name = name;
            Armor = armor;
            Price = price;
        }
    }
}
