using AOC2015.Logic.Builders;
using AOC2015.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic
{
    public class ChristmasComputer
    {
        private Dictionary<string, int> _registers;
        private List<ChristmasComputerInstruction> _program;
        private int _currentCommandIndex;

        public ChristmasComputer(Dictionary<string, int> initialRegisters = null)
        {
            _registers = initialRegisters;

            if (_registers == null)
            {
                _registers = new Dictionary<string, int>
                        {
                               {"a", 0 },
                               {"b", 0 }
                        };
            }

            _program = new List<ChristmasComputerInstruction>();
            _currentCommandIndex = 0;
        }

        public void LoadProgram(string[] programLines)
        {
            var instructionBuilder = new ChristmasComputerInstructionBuilder();

            foreach (string line in programLines)
            {
                ChristmasComputerInstruction instruction = instructionBuilder.BuildInstruction(line);
                _program.Add(instruction);
            }
        }

        public void ExecuteProgram()
        {
            ChristmasComputerInstruction instructionToExecute = GetNextInstructionToExecute();

            while (instructionToExecute != null)
            {
                ExecuteInsturction(instructionToExecute);
                instructionToExecute = GetNextInstructionToExecute();
            }
        }

        public int GetRegisterValue(string registerName) => _registers[registerName];

        private void ExecuteInsturction(ChristmasComputerInstruction instructionToExecute)
        {
            int registerValue;

            switch (instructionToExecute.Type)
            {
                case ChristmasComputerInstructionType.Increment:
                    _registers[instructionToExecute.Operand1]++;
                    _currentCommandIndex++;
                    break;
                case ChristmasComputerInstructionType.Half:
                    _registers[instructionToExecute.Operand1] = _registers[instructionToExecute.Operand1] / 2;
                    _currentCommandIndex++;
                    break;
                case ChristmasComputerInstructionType.Triple:
                    _registers[instructionToExecute.Operand1] = _registers[instructionToExecute.Operand1] * 3;
                    _currentCommandIndex++;
                    break;
                case ChristmasComputerInstructionType.Jump:
                    _currentCommandIndex += int.Parse(instructionToExecute.Operand1);
                    break;
                case ChristmasComputerInstructionType.JumpIfEven:
                    registerValue = GetRegisterValue(instructionToExecute.Operand1);

                    if (registerValue % 2 == 0)
                    {
                        _currentCommandIndex += int.Parse(instructionToExecute.Operand2);
                    } else
                    {
                        _currentCommandIndex++; 
                    }

                    break;
                case ChristmasComputerInstructionType.JumpIfOne:
                    registerValue = GetRegisterValue(instructionToExecute.Operand1);
                    if (registerValue == 1)
                    {
                        _currentCommandIndex += int.Parse(instructionToExecute.Operand2);
                    } else
                    {
                        _currentCommandIndex++;
                    }
                    break;
            }
        }

        private ChristmasComputerInstruction GetNextInstructionToExecute()
        {
            if (_currentCommandIndex < _program.Count)
            {
                return _program[_currentCommandIndex];
            }

            return null;
        }
    }
}
