using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Models
{
    public class ChristmasComputerInstruction
    {
        public ChristmasComputerInstructionType Type { get; set; }
        public string Operand1 { get; set; }
        public string Operand2 { get; set; }
    }
}
