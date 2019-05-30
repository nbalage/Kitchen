using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Ingredients
{
    public class Ketchup : Ingredient
    {
        public Ketchup()
        {
            base.InitializeIngredient(false, 0);
        }

        public override string ToString()
        {
            return "Ketchup";
        }
    }
}
