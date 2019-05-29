using Kitchen.Foods;
using Kitchen.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen
{
    public class Cook
    {
        Oven oven;
        Queue<Order> unprocessedOrders;
        Queue<Order> waitingForCookableIngredient;
        ICollection<Order> ordersUnderProcess;
        ICollection<Ingredient> ingredientsNeedCook;

        /*
         * TODO:
         * hozzávalók összegyűjtése
         * hozzávalók szétválogatása: sütnivalók, nem sütnivalók.
         * A sütnivalók elkészítésével kell kezdeni.
         * Amikor az előkészített hozzávalók száma elérte a sütő kapacitását, vagy nincs több hasonló típusú hozzávaló, akkor indulhat a sütés.
         * Sütés alatt folytatódhat az előkészítés.
         * Ha minden hozzávaló elkészült, lehet tálalni (azonnal)
         */

        public Cook(IEnumerable<Order> orders)
        {
            oven = new Oven();
            foreach (var order in orders)
            {
                this.unprocessedOrders.Enqueue(order);
            }
        }

        public async void StartCooking()
        {
            await Cooking();
            SortingIngredients();
            await FinishFood();
            PreparingNonCookableIngredients();
        }

        void PreparingNonCookableIngredients()
        {
            foreach (var order in ordersUnderProcess)
            {
                var ingredients = CollectIngredients(order.Ingredients);
                foreach (var ing in ingredients.Where(i => !i.NeedsCooking))
                {
                    Thread.Sleep(ing.PreparationTime);
                }

                waitingForCookableIngredient.Enqueue(order);
                ordersUnderProcess.Remove(order);
            }
        }

        async Task FinishFood()
        {
            while (waitingForCookableIngredient.Count() > 0)
            {
                foreach (var order in waitingForCookableIngredient)
                {
                    // TODO: kikeresni a megsült kaját
                }
            }
        }

        void ServingFood(Food food)
        {
            Console.WriteLine($"1x {food.Name} served.");
        }

        void SortingIngredients()
        {
            foreach (var order in unprocessedOrders)
            {
                ordersUnderProcess.Add(unprocessedOrders.Dequeue());

                var ingredients = CollectIngredients(order.Ingredients);
                foreach (var i in ingredients.Where(i => i.NeedsCooking))
                {
                    ingredientsNeedCook.Add(i);
                }
            }
        }

        IEnumerable<Ingredient> CollectIngredients(Ingredients.Ingredients ingreds)
        {
            var ingredients = new List<Ingredient>();

            if (ingreds.HasFlag(Ingredients.Ingredients.Bun))
            {
                ingredients.Add(new Bun());
            }
            else if (ingreds.HasFlag(Ingredients.Ingredients.Patty))
            {
                ingredients.Add(new Patty());
            }
            else if (ingreds.HasFlag(Ingredients.Ingredients.DoublePatty))
            {
                ingredients.Add(new Patty());
                ingredients.Add(new Patty());
            }
            else if (ingreds.HasFlag(Ingredients.Ingredients.Lettuce))
            {
                ingredients.Add(new Lettuce());
            }
            else if (ingreds.HasFlag(Ingredients.Ingredients.Tomato))
            {
                ingredients.Add(new Tomato());
            }
            else if (ingreds.HasFlag(Ingredients.Ingredients.Cheese))
            {
                ingredients.Add(new Cheese());
            }
            else if (ingreds.HasFlag(Ingredients.Ingredients.DoubleCheese))
            {
                ingredients.Add(new Cheese());
                ingredients.Add(new Cheese());
            }
            else if (ingreds.HasFlag(Ingredients.Ingredients.Ketchup))
            {
                ingredients.Add(new Ketchup());
            }
            else if (ingreds.HasFlag(Ingredients.Ingredients.Fries))
            {
                ingredients.Add(new Fries());
            }

            return ingredients;
        }

        async Task Cooking()
        {
            while (ordersUnderProcess.Count() > 0)
            {
                var fries = ingredientsNeedCook.Where(i => i.GetType() == typeof(Fries)).Select(i => i as Fries);
                var patties = ingredientsNeedCook.Where(i => i.GetType() == typeof(Patty)).Select(i => i as Patty);

                if (fries.Count() == oven.MaximumCapacity || ordersUnderProcess.Count() == 0)
                {
                    // cooking of fries
                }
                else if (patties.Count() == oven.MaximumCapacity || ordersUnderProcess.Count() == 0)
                {
                    // cooking of patties
                }
            }
        }
    }
}
