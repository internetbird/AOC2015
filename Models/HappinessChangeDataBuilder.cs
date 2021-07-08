using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class HappinessChangeDataBuilder
    {
        private string[] _inputData;


        public HappinessChangeDataBuilder(string[] inputData)
        {
            _inputData = inputData;
        }

        public Dictionary<string, Dictionary<string, int>> BuildHappinessChangeData()
        {
            var data = new Dictionary<string, Dictionary<string, int>>();

            foreach (string inputLine in _inputData)
            {
                string[] lineParts = inputLine.Split();

                string memberName = lineParts[0];
                string neighbourName = lineParts[10].TrimEnd('.');
                int happinessValue = GetHappinessValue(lineParts[2], lineParts[3]);

                if (!data.ContainsKey(memberName))
                {
                    data.Add(memberName, new Dictionary<string, int>());
                }

                Dictionary<string, int> memberDictionary = data[memberName];
                memberDictionary.Add(neighbourName, happinessValue);

            }

            return data;
        }

        private int GetHappinessValue(string gainOrLose, string happinessValStr)
        {
            int happinessVal = int.Parse(happinessValStr);

            if (gainOrLose == "lose")
            {
                happinessVal = -happinessVal;
            }

            return happinessVal;
        }
    }
}
