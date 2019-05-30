using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Ingredients
{
    public abstract class Ingredient : IEquatable<Ingredient>//, IComparer<Ingredient>
    {
        public bool NeedsCooking { get; set; }

        public int PreparationTime { get; set; }

        public int? CookingTime { get; set; }

        public bool Roasted { get; set; } = false;

        //public int Compare(Ingredient x, Ingredient y)
        //{
        //    return "a".or > "b"
        //}

        public bool Equals(Ingredient other)
        {
            return this.GetType() == other.GetType();
        }

        public void InitializeIngredient(bool needsCooking, int preparationTime, int? cookingTime = null)
        {
            if (needsCooking && cookingTime == null)
            {
                throw new ArgumentException("The cooking time is mandantory, when the ingredient needs cooking!");
            }

            this.NeedsCooking = needsCooking;
            this.PreparationTime = preparationTime;
            this.CookingTime = cookingTime;
        }
    }
}
