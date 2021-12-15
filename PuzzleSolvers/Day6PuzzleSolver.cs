using AOC;
using AOC2015.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day6PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var lightsMatrix = new LightsMatrix();

            List<LightInstruction> instructions = GetLightInstructionInput();

            instructions.ForEach(instruction => lightsMatrix.ExecuteInstruction(instruction));
        
            var numOfActiveLights = lightsMatrix.GetNumOfActiveLights();

            return numOfActiveLights.ToString();
        }

        public string SolvePuzzlePart2()
        {
            var lightsMatrix = new BrightnessLightMatrix();

            List<LightInstruction> instructions = GetLightInstructionInput();

            instructions.ForEach(instruction => lightsMatrix.ExecuteInstruction(instruction));

            var totalBrightness = lightsMatrix.GetTotalBrightness();
            
            return totalBrightness.ToString();
        }


        private List<LightInstruction> GetLightInstructionInput()
        {
            var instructions = new List<LightInstruction>();

            var fullInputFilePath = Path.GetFullPath("InputFiles/day6.txt");
            string[] inputStrings = File.ReadAllLines(fullInputFilePath);

            for (int i = 0; i < inputStrings.Length; i++)
            {
                var builder = new LightInstructionBuilder();
                LightInstruction instruction = builder.BuildInstruction(inputStrings[i]);
                instructions.Add(instruction);
            }

            return instructions;
        }
    }
}
