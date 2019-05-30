using Kitchen.Foods;
using Kitchen.Ingredients;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>
            {
                new Order("Basic burger", Menu.BasicBurger, 2),
                new Order("Cheese burger", Menu.CheeseBurger, 2),
                new Order("Double Burger", Menu.DoubleBurger, 2),
                new Order("full burger", Menu.FullBurger, 2),
                new Order("french fries with ketchup", Menu.FriesWithKetchup, 4),
                new Order("fries", Menu.NormalFries, 3)
            };

            Timer timer = new Timer();
            timer.Start();
            var cook = new Cook(orders);
            cook.StartCooking();
            timer.Stop();
            Console.WriteLine($"The program ran at {timer.Interval} ms");
            timer.Dispose();
        }
    }
}
