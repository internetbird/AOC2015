using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015.Models
{
    public class WireCircuit
    {

        private Dictionary<string, WireCircuitExpression> _instructions;
        private Dictionary<string, ushort> _evaluatedWires;

        public WireCircuit(Dictionary<string, WireCircuitExpression> instructions)
        {
            _instructions = instructions;
            _evaluatedWires = new Dictionary<string, ushort>();
        }

        public ushort EvaulateWireSignal(string wireId)
        {
            if (_evaluatedWires.ContainsKey(wireId))
            {
                return _evaluatedWires[wireId];
            }

            if (!_instructions.ContainsKey(wireId))
            {
                throw new ArgumentException($"Could not evaluate wireId: {wireId}");
            }

            WireCircuitExpression expression = _instructions[wireId];

            ushort evaluatedExpression = EvaluateExpression(expression);

            _evaluatedWires.Add(wireId, evaluatedExpression);

            return evaluatedExpression;
        }

        private ushort EvaluateExpression(WireCircuitExpression expression)
        {

            ushort evaluationResult = default(ushort);

            if (expression.Operator == WireCircuitOperator.ASSIGNMENT)
            {
                evaluationResult = EvaluateOperand(expression.Operand1);

            }
            else if (expression.Operator == WireCircuitOperator.NOT)
            {
                ushort operandValue = EvaluateOperand(expression.Operand1);
                evaluationResult = (ushort)~operandValue;

            }
            else
            {
                ushort operand1Value = EvaluateOperand(expression.Operand1);
                ushort operand2Value = EvaluateOperand(expression.Operand2);

                if (expression.Operator == WireCircuitOperator.AND)
                {
                    evaluationResult = (ushort)(operand1Value & operand2Value);
                }
                else if (expression.Operator == WireCircuitOperator.OR)
                {

                    evaluationResult = (ushort)(operand1Value | operand2Value);

                }
                else if (expression.Operator == WireCircuitOperator.RSHIFT)
                {
                    evaluationResult = (ushort)(operand1Value >> operand2Value);

                }
                else if (expression.Operator == WireCircuitOperator.LSHIFT)
                {
                    evaluationResult = (ushort)(operand1Value << operand2Value);
                }
            }

            return evaluationResult;
        }

        private ushort EvaluateOperand(string operand)
        {
            ushort operandValue;

            if (ushort.TryParse(operand, out operandValue)) //Check if the operand is a number
            {
                return operandValue;

            } else //Try to get value by wireId
            {
                return EvaulateWireSignal(operand);
            }
        }
    }
}
