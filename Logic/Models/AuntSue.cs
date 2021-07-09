using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class AuntSue
    {
        public int Id { get; set; }
        public Dictionary<string, int> Properties { get; set; }

        public AuntSue()
        {
            Properties = new Dictionary<string, int>();
        }
    }
}
