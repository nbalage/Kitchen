using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Ingredients
{
    public class Fries : Ingredient
    {
        public Fries()
        {
            base.InitializeIngredient(true, 100, 2000);
        }
    }
}
