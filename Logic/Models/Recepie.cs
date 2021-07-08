using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class Recepie
    {
        public Dictionary<Ingredient, int> Contents { get; set; }


        public Recepie()
        {
            Contents = new Dictionary<Ingredient, int>();
        }
    }

}
