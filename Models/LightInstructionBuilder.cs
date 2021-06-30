using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class LightInstructionBuilder
    {

        private const int TOGGLE_INSTRUCTION_PARTS = 4;


        public LightInstruction BuildInstruction(string instructionText)
        {
         
           string[] instructionParts = instructionText.Split();


            LightInstructionCommand instructionCommand;
            Coordinate startCoordinate, endCoordinate;

            if (instructionParts.Length == TOGGLE_INSTRUCTION_PARTS)
            {
                instructionCommand = LightInstructionCommand.Toggle;

                startCoordinate = new Coordinate(instructionParts[1]);
                endCoordinate = new Coordinate(instructionParts[3]);

            }
            else //'Turn on' Or 'Turn Off'
            {
                if (instructionParts[1] == "on")
                {
                    instructionCommand = LightInstructionCommand.TurnOn;
                }
                else
                {
                    instructionCommand = LightInstructionCommand.TurnOff;
                }

                startCoordinate = new Coordinate(instructionParts[2]);
                endCoordinate = new Coordinate(instructionParts[4]);
            }

            var instruction = new LightInstruction();
            instruction.Command = instructionCommand;
            instruction.StartCoordinate = startCoordinate;
            instruction.EndCoordinate = endCoordinate;

            return instruction;
        }
    }
}
