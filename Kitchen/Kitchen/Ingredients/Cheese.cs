using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Ingredients
{
    public class Cheese : Ingredient
    {
        public Cheese()
        {
            base.InitializeIngredient(false, 0);
        }

        public override string ToString()
        {
            return "Cheese";
        }
    }
}
