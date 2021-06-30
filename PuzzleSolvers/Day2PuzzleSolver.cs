using AOC2015.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class Day2PuzzleSolver : IPuzzleSolver
    {     
        public string SolvePuzzlePart1()
        {
            List<Box> boxes = GetInputBoxes();
            var totalPaperSize = boxes.Sum(box => CalculatePaperSizeForBox(box));

            return totalPaperSize.ToString();
        }

        public string SolvePuzzlePart2()
        {
            List<Box> boxes = GetInputBoxes();

            int totalRibbonLength = boxes.Sum(box => CalculateRibbonLengthForBox(box));

            return totalRibbonLength.ToString();
        }

       

        private List<Box> GetInputBoxes()
        {
            var fullInputFilePath = Path.GetFullPath("InputFiles/day2.txt");

            string[] fileLines = File.ReadAllLines(fullInputFilePath);

            List<Box> boxes = fileLines.Select(line => MapLineToBox(line)).ToList();
           
            return boxes;
        }

        private Box MapLineToBox(string line)
        {
            string[] dimensions = line.Split('x');

            var box = new Box
            {
                Width = int.Parse(dimensions[0]),
                Height = int.Parse(dimensions[1]),
                Length = int.Parse(dimensions[2])
            };

            return box;
        }

        private int CalculatePaperSizeForBox(Box box)
        {
            int side1Area = box.Height * box.Length;
            int side2Area = box.Height * box.Width;
            int side3Area = box.Width * box.Length;

            int smallestArea = new List<int> { side1Area, side2Area, side3Area }.Min();

            int totalPaperSize = (2 * side1Area) + (2 * side2Area) + (2 * side3Area) + smallestArea;
            return totalPaperSize;
        }

        private int CalculateRibbonLengthForBox(Box box)
        {
           
            var dimensions = new List<int> { box.Height, box.Length, box.Width };
            dimensions.Sort();
            int perimeterLength = (2 * dimensions[0]) + (2 * dimensions[1]);

            int tieLength = box.Height * box.Length * box.Width;

            int totalRibbonLength = perimeterLength + tieLength;

            return totalRibbonLength;
        }
    }
}
