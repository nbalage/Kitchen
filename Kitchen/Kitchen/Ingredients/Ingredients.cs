using System;
using System.Collections.Generic;
using System.Text;

namespace Kitchen.Ingredients
{
    [Flags]
    public enum Ingredients
    {
        Bun,
        Patty,
        DoublePatty,
        Lettuce,
        Tomato,
        Cheese,
        DoubleCheese,
        Ketchup,
        Fries
    }
}
