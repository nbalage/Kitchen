using Kitchen.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Foods
{
    public class Hamburger : Food
    {
        public Hamburger()
        {
            Name = "Hamburger";
            Ingredients = new List<Ingredient>();
        }

        public override string ToString()
        {
            return "Hamburger";
        }

        //public Hamburger(string name, params Ingredient[] ingredients)
        //{
        //    this.Name = name;

        //    foreach (var ing in ingredients)
        //    {
        //        Ingredients.Add(ing);
        //    }
        //}
    }
}
