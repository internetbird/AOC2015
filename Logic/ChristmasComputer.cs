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

        public ChristmasComputer()
        {
            _registers = new Dictionary<string, int>
            {
                   {"a", 0 },
                   {"b", 0 }
            };

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
            switch (instructionToExecute.Type)
            {
                case ChristmasComputerInstructionType.Increment:
                    _registers[instructionToExecute.Operand1]++;
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
