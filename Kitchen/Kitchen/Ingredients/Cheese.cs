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
    }
}
