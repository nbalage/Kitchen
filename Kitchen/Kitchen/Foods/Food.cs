using Kitchen.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Foods
{
    public abstract class Food
    {
        public ICollection<Ingredient> Ingredients { get; set; }

        public string Name { get; set; }
    }
}
