﻿using ingreds = Kitchen.Ingredients.Ingredients;

using Kitchen.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen
{
    public class Order
    {
        public ingreds Ingredients { get; set; }

        public Food Food { get; set; }

        public int Count { get; set; }

        public string Name { get; set; }

        public Order(string name, ingreds ingreds, int count)
        {
            this.Count = count;
            this.Ingredients = ingreds;
            this.Name = name;
            if (ingreds.Equals(Menu.BasicBurger) ||
                ingreds.Equals(Menu.CheeseBurger) ||
                ingreds.Equals(Menu.DoubleBurger) ||
                ingreds.Equals(Menu.FullBurger) ||
                ingreds.Equals(Menu.NakedBurger))
            {
                Food = new Hamburger();
            }
            else if (ingreds.Equals(Menu.FriesWithKetchup) ||
                     ingreds.Equals(Menu.NormalFries))
            {
                Food = new FrenchFries();
            }
        }
    }
}
