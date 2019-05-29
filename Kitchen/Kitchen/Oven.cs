using Kitchen.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Kitchen
{
    public class Oven
    {
        const int _maximumCapacity = 4;

        public int MaximumCapacity
        {
            get
            {
                return _maximumCapacity;
            }
        }

        public int ActualCapacity { get; } = 0;

        public bool HasEmptyPlace { get; } = true;

        // NOTE: csak egy típusú kaját tud egyszerre sütni

        public Ingredient Cook(Ingredient ingredient)
        {
            Thread.Sleep(ingredient.CookingTime.Value);
            ingredient.Roasted = true;

            return ingredient;
        }
    }
}
