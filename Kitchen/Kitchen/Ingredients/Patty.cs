using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Ingredients
{
    public class Patty : Ingredient
    {
        public Patty()
        {
            base.InitializeIngredient(true, 100, 1000);
        }
    }
}
