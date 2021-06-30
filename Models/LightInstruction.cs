using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class LightInstruction
    {
        public LightInstructionCommand Command { get; set; }
        public Coordinate StartCoordinate { get; set; }
        public Coordinate EndCoordinate { get; set; }
    }
}
