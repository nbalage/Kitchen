using ingreds = Kitchen.Ingredients.Ingredients;

using Kitchen.Foods;
using Kitchen.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen
{
    public static class Menu
    {
        public static ingreds NakedBurger
        {
            get
            {
                return ingreds.Patty |
                       ingreds.Lettuce |
                       ingreds.Tomato |
                       ingreds.Ketchup;
            }
        }

        public static ingreds BasicBurger
        {
            get
            {
                return ingreds.Bun |
                       ingreds.Patty |
                       ingreds.Ketchup;
            }
        }

        public static ingreds CheeseBurger
        {
            get
            {
                return ingreds.Bun |
                       ingreds.Patty |
                       ingreds.Cheese |
                       ingreds.Ketchup;
            }
        }

        public static ingreds FullBurger
        {
            get
            {
                return ingreds.Bun |
                       ingreds.Patty |
                       ingreds.Lettuce |
                       ingreds.Tomato |
                       ingreds.Cheese |
                       ingreds.Ketchup;
            }
        }

        public static ingreds DoubleBurger
        {
            get
            {
                return ingreds.Bun |
                       ingreds.DoublePatty |
                       ingreds.Lettuce |
                       ingreds.Tomato |
                       ingreds.DoubleCheese |
                       ingreds.Ketchup;
            }
        }

        public static ingreds NormalFries
        {
            get
            {
                return ingreds.Fries;
            }
        }

        public static ingreds FriesWithKetchup
        {
            get
            {
                return ingreds.Ketchup |
                       ingreds.Fries;
            }
        }
    }
}
