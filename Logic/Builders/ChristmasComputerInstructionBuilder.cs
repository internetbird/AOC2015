using AOC2015.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Builders
{
    public class ChristmasComputerInstructionBuilder
    {
        public ChristmasComputerInstruction BuildInstruction(string instructionText)
        {

            //Clean up
            instructionText = instructionText.Replace(",", string.Empty);

            var instruction = new ChristmasComputerInstruction();

            string[] instructionParts = instructionText.Split();

            ChristmasComputerInstructionType type = ChristmasComputerInstructionType.NotSet;

            switch (instructionParts[0])
            {
                case "inc":
                    type = ChristmasComputerInstructionType.Increment;
                    break;
                case "hlf":
                    type = ChristmasComputerInstructionType.Half;
                    break;
                case "tpl":
                    type = ChristmasComputerInstructionType.Triple;
                    break;
                case "jmp":
                    type = ChristmasComputerInstructionType.Jump;
                    break;
                case "jio":
                    type = ChristmasComputerInstructionType.JumpIfOne;
                    break;
                case "jie":
                    type = ChristmasComputerInstructionType.JumpIfEven;
                    break;
            }

            instruction.Type = type;
            instruction.Operand1 = instructionParts[1];
            if (instructionParts.Length > 2)
            {
                instruction.Operand2 = instructionParts[2];
            }

            return instruction;
        }
    }
}
