using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class WireCircuitInstruction
    {
        public string WireId1 { get; set; }
        public string WireId2 { get; set; }
        public string WireId3 { get; set; }
        public WireCircuitOperator Operator { get; set; }
        public ushort NumericVal { get; set; }
    }
}
