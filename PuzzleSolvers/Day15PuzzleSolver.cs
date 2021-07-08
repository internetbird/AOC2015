using AOC2015.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015.PuzzleSolvers
{
    public class Day15PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            List<Ingredient> ingredients = GetIngrediends();

            List<Recepie> allPossibleRecepies = GetAllPossibleRecepies(ingredients);

            return string.Empty;
        }

        private List<Recepie> GetAllPossibleRecepies(List<Ingredient> ingredients)
        {
            var allPossibleRecepies = new List<Recepie>();

            for (int numOfSpoons1 = 0; numOfSpoons1 <= 100; numOfSpoons1++)
            {
                var recepie = new Recepie();
                if (numOfSpoons1 != 0)
                {
                    recepie.Contents.Add(ingredients[0], numOfSpoons1);
                }

                for (int numOfSpoons2 = 0; numOfSpoons2 <= (100 - numOfSpoons1); numOfSpoons2++)
                {
                    if (numOfSpoons2 != 0)
                    {
                        recepie.Contents.Add(ingredients[1], numOfSpoons2);
                    }
                    
                    for (int numOfSpoons3 = 0; numOfSpoons3 <= (100 - numOfSpoons1 - numOfSpoons2); numOfSpoons3++)
                    {

                        if (numOfSpoons3 != 0)
                        {
                            recepie.Contents.Add(ingredients[2], numOfSpoons3);
                        }

                        for (int numOfSpoons4 = 0; numOfSpoons4 < (100 - numOfSpoons1 - numOfSpoons2 - numOfSpoons3); numOfSpoons4++)
                        {

                            if (numOfSpoons4 != 0)
                            {
                                recepie.Contents.Add(ingredients[3], numOfSpoons4);
                                break;
                            }
                        }
                    }
                }
            }

            return allPossibleRecepies;
            
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }

        private List<Ingredient> GetIngrediends()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient{ Name = "Sprinkles", Capacity = 2, Durability = 0, Flavor = -2, Texture = 0, Calories = 3},
                new Ingredient{ Name = "Butterscotch", Capacity = 0, Durability = 5, Flavor = -3, Texture = 0, Calories = 3},
                new Ingredient{ Name = "Chocolate", Capacity = 0, Durability = 0, Flavor = 5, Texture = -1, Calories = 8},
                new Ingredient{ Name = "Candy", Capacity =0, Durability = -1, Flavor = 0, Texture = 5, Calories = 8},
            };


            return ingredients;
        }
    }
}
