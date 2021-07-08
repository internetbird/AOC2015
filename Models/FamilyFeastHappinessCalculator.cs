using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.Models
{
    public class FamilyFeastHappinessCalculator
    {

        private Dictionary<string, int> _happinessScore;
        private Dictionary<string, Dictionary<string, int>> _happinessChangeData;

        public FamilyFeastHappinessCalculator(string[] familyMembers, string[] inputData)
        {

            _happinessScore = new Dictionary<string, int>();
          
            foreach (string member in familyMembers)
            {
                _happinessScore.Add(member, 0);
            }

            var dataBuilder = new HappinessChangeDataBuilder(inputData);
            _happinessChangeData = dataBuilder.BuildHappinessChangeData();
        }


        public int GetTotalHappinessForSeatingOrder(string[] seatingOrder)
        {
            int totalHappiness = 0;

            for (int i = 0; i < seatingOrder.Length; i++)
            {
                Tuple<string, string> memberNeighbours = GetNeighboursForIndex(seatingOrder, i);

                string currMember = seatingOrder[i];
                int happinessForNeighbour1 = _happinessChangeData[currMember][memberNeighbours.Item1];
                int happinessForNeighbour2 = _happinessChangeData[currMember][memberNeighbours.Item2];

                totalHappiness += (happinessForNeighbour1 + happinessForNeighbour2);
            }

            return totalHappiness;
        }

        private Tuple<string, string> GetNeighboursForIndex(string[] seatingOrder, int index)
        {
            string neighbour1, neighbour2;
            
            if (index > 0 && index < (seatingOrder.Length - 1))
            {
                neighbour1 = seatingOrder[index - 1];
                neighbour2 = seatingOrder[index + 1];

            }
            else if (index == 0)
            {
                neighbour1 = seatingOrder[1];
                neighbour2 = seatingOrder[seatingOrder.Length - 1];

            }
            else //last member
            {
                neighbour1 = seatingOrder[seatingOrder.Length - 2];
                neighbour2 = seatingOrder[0];
            }

            return new Tuple<string, string>(neighbour1, neighbour2); ;
        }
    }
}
