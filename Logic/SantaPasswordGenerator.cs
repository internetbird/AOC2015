using AOC2015.Utility;
using BirdLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class SantaPasswordGenerator
    {
        public string GenerateNextPassword(string currentPassword)
        {
            string nextPassword = GetNextAlphabeticPassword(currentPassword);
            while (!IsValidPassword(nextPassword))
            {
                nextPassword = GetNextAlphabeticPassword(nextPassword);
            }

            return nextPassword;
        }

        private bool IsValidPassword(string password)
        {

            bool isValid = !password.Contains('i') && !password.Contains('o') && !password.Contains('l')
                    && password.HasStraightThreeLetters() && password.ContainsTwoDifferentLetterPairs();

            return isValid;
        }

        private string GetNextAlphabeticPassword(string password)
        {

            char[] passwordChars = password.ToCharArray();
           
            var currIndex = password.Length - 1;
            var processCompleted = false;

            while (!processCompleted)
            {
                if (passwordChars[currIndex] < 'z')
                {
                    passwordChars[currIndex]++;
                    processCompleted = true;

                } else
                {
                    passwordChars[currIndex] = 'a';

                    currIndex--;

                    if (currIndex < 0)
                    {
                        processCompleted = true;
                    }

                }
            }

            return string.Join(string.Empty, passwordChars);
        }
    }
}
