using Kitchen.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Foods
{
    public class FrenchFries : Food
    {
        public FrenchFries()
        {
            Name = "FrenchFries";
            Ingredients = new List<Ingredient>();
        }

        public override string ToString()
        {
            return "French Fries";
        }

        //public FrenchFries(string name, params Ingredient[] ingredients)
        //{
        //    this.Name = name;

        //    foreach (var ing in ingredients)
        //    {
        //        Ingredients.Add(ing);
        //    }
        //}
    }
}
