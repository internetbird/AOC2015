using AOC2015.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Logic.Builders
{
    public class AuntSueBuilder
    {
        public AuntSue Build(string inputLine)
        {
            var auntSue = new AuntSue();

            int titleDataSeperatorIndex = inputLine.IndexOf(':');

            string headerPart = inputLine.Substring(0, titleDataSeperatorIndex);
            string dataPart = inputLine.Substring(titleDataSeperatorIndex + 2);

            int auntId = int.Parse(headerPart.Split()[1]);
            auntSue.Id = auntId;

            string[] dataProperties = dataPart.Split(',');

            foreach (string dataProperty in dataProperties)
            {
                string[] propertyNameAndValue = dataProperty.Split(':');

                string propertyName = propertyNameAndValue[0].Trim();
                int propertyValue = int.Parse(propertyNameAndValue[1].Trim());

                auntSue.Properties.Add(propertyName, propertyValue);
            }

            return auntSue;
        }
    }
}
