using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class WireCircuitInstruction
    {
        public WireCircuitExpression Expression { get; set; }
        public string AssignedWireId { get; set; }
    }
}
