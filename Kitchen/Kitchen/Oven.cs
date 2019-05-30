using Kitchen.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Ingredient>> CookPatties(IEnumerable<Patty> patties)
        {
            Console.WriteLine($"Cooking started with {patties.Count()}x Patties");
            var p = patties.First();
            Cook(p);
            foreach (var patty in patties)
            {
                patty.Roasted = true;
            }
            Console.WriteLine($"{patties.Count()}x Patties cooked");

            return patties;
        }

        public async Task<IEnumerable<Ingredient>> CookFires(IEnumerable<Fries> fries)
        {
            Console.WriteLine($"Cooking started with {fries.Count()}x Fries");
            var f = fries.First();
            Cook(f);
            foreach (var fry in fries)
            {
                fry.Roasted = true;
            }
            Console.WriteLine($"{fries.Count()}x Fries cooked");

            return fries;
        }

        void Cook(Ingredient ingredient)
        {
            Thread.Sleep(ingredient.CookingTime.Value);
        }
    }
}
