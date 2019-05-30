using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Ingredients
{
    public class Lettuce : Ingredient
    {
        public Lettuce()
        {
            base.InitializeIngredient(false, 200);
        }

        public override string ToString()
        {
            return "Lettuce";
        }
    }
}
