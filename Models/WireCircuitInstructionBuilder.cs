using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class WireCircuitInstructionBuilder
    {
        public WireCircuitInstruction BuildInstruction(string instructionText)
        {
            string[] instructionParts = instructionText.Split();

            WireCircuitOperator instructionOperator = WireCircuitOperator.UNDEFINED;
            string assignedWireId = null;
            string operand1;
            string operand2 = null;

            if (instructionParts[0] == "NOT")
            {
                instructionOperator = WireCircuitOperator.NOT;
                operand1 = instructionParts[1];
                operand2 = instructionParts[3];
            }

            else if (instructionParts.Length == 3) // Simple assignement instruction in the form : a -> b
            {
                instructionOperator = WireCircuitOperator.ASSIGNMENT;
                operand1 = instructionParts[0];
                assignedWireId = instructionParts[2];
            }

            else //The operator is the second word
            {
                switch (instructionParts[1])
                {
                    case "AND":
                        instructionOperator = WireCircuitOperator.AND;
                        break;
                    case "OR":
                        instructionOperator = WireCircuitOperator.OR;
                        break;
                    case "LSHIFT":
                        instructionOperator = WireCircuitOperator.LSHIFT;
                        break;
                    case "RSHIFT":
                        instructionOperator = WireCircuitOperator.RSHIFT;
                        break;
                    default:
                        break;
                }

                operand1 = instructionParts[0];
                operand2 = instructionParts[2];
                assignedWireId = instructionParts[4];
            }


            var instruction = new WireCircuitInstruction();

            instruction.Operator = instructionOperator;
            instruction.Operand1 = operand1;
            instruction.Operand2 = operand2;
            instruction.AssignedWireId = assignedWireId;

            return instruction;

        }
    }
}
