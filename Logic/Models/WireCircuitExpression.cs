using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class WireCircuitExpression
    {
        public WireCircuitOperator Operator { get; set; }
        public string Operand1 { get; set; }
        public string Operand2 { get; set; }
    }
}
