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

            WireCircuitOperator expressionOperator = WireCircuitOperator.UNDEFINED;
            string assignedWireId = null;
            string operand1;
            string operand2 = null;

            if (instructionParts[0] == "NOT")
            {
                expressionOperator = WireCircuitOperator.NOT;
                operand1 = instructionParts[1];
                assignedWireId = instructionParts[3];
            }

            else if (instructionParts.Length == 3) // Simple assignement instruction in the form : a -> b
            {
                expressionOperator = WireCircuitOperator.ASSIGNMENT;
                operand1 = instructionParts[0];
                assignedWireId = instructionParts[2];
            }

            else //The operator is the second word
            {
                switch (instructionParts[1])
                {
                    case "AND":
                        expressionOperator = WireCircuitOperator.AND;
                        break;
                    case "OR":
                        expressionOperator = WireCircuitOperator.OR;
                        break;
                    case "LSHIFT":
                        expressionOperator = WireCircuitOperator.LSHIFT;
                        break;
                    case "RSHIFT":
                        expressionOperator = WireCircuitOperator.RSHIFT;
                        break;
                    default:
                        break;
                }

                operand1 = instructionParts[0];
                operand2 = instructionParts[2];
                assignedWireId = instructionParts[4];
            }

            var instruction = new WireCircuitInstruction();
            instruction.AssignedWireId = assignedWireId;

            instruction.Expression = new WireCircuitExpression
            {
                Operator = expressionOperator,
                Operand1 = operand1,
                Operand2 = operand2
            };


            return instruction;

        }
    }
}
