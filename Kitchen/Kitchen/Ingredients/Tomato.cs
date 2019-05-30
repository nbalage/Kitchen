using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Ingredients
{
    public class Tomato : Ingredient
    {
        public Tomato()
        {
            base.InitializeIngredient(false, 200);
        }

        public override string ToString()
        {
            return "Tomato";
        }
    }
}
