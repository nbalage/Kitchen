using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Ingredients
{
    public class Bun : Ingredient
    {
        public Bun()
        {
            base.InitializeIngredient(false, 200);
        }

        public override string ToString()
        {
            return "Bun";
        }
    }
}
