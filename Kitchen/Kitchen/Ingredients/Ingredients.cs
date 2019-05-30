using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Ingredients
{
    [Flags]
    public enum Ingredients
    {
        Bun = 1,
        Patty = 2,
        DoublePatty = 4,
        Lettuce = 8,
        Tomato = 16,
        Cheese = 32,
        DoubleCheese = 64,
        Ketchup = 128,
        Fries = 256
    }
}
