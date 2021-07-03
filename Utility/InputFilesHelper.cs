using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOC2015.Utility
{
    public static class InputFilesHelper
    {
        public static string[] GetInputFileLines (string fileName)
        {
            var fullInputFilePath = Path.GetFullPath($"InputFiles/{fileName}");
            string[] inputStrings = File.ReadAllLines(fullInputFilePath);

            return inputStrings;

        }
    }
}
