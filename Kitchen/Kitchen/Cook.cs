using Kitchen.Foods;
using Kitchen.Ingredients;
using System;
using System.Collections.Concurrent;
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
        ICollection<Order> waitingForCookableIngredient;
        ICollection<Order> ordersUnderProcess;
        ICollection<Ingredient> ingredientsNeedCook;
        ICollection<Ingredient> cookedIngredients;
        bool Start = true;

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
            unprocessedOrders = new Queue<Order>();
            waitingForCookableIngredient = new List<Order>();
            ordersUnderProcess = new List<Order>();
            ingredientsNeedCook = new List<Ingredient>();
            cookedIngredients = new List<Ingredient>();

            foreach (var order in orders)
            {
                this.unprocessedOrders.Enqueue(order);
            }
        }

        public async void StartCooking()
        {
            Task[] tasks = new Task[4];
            tasks[0] = SortingIngredients();
            tasks[1] = Cooking();
            tasks[2] = PreparingNonCookableIngredients();
            tasks[3] = FinishFood();

            //var finished = await FinishFood();

            //finished;
            await Task.WhenAll(tasks);
        }

        async Task PreparingNonCookableIngredients()
        {
            while (ordersUnderProcess.Count() > 0)
            {
                var order = ordersUnderProcess.First();
                var ingredients = CollectIngredients(order.Ingredients);
                foreach (var ing in ingredients.Where(i => !i.NeedsCooking))
                {
                    Thread.Sleep(ing.PreparationTime);
                    order.Food.Ingredients.Add(ing);

                    Console.WriteLine($"{ing} prepared");
                }

                waitingForCookableIngredient.Add(order);
                ordersUnderProcess.Remove(order);
            }
        }

        async Task FinishFood()
        {
            while (waitingForCookableIngredient.Count() > 0 || Start)
            {
                foreach (var order in waitingForCookableIngredient)
                {
                    var ings = CollectIngredients(order.Ingredients).Where(i => i.NeedsCooking);
                    foreach (var i in ings)
                    {
                        // TODO: ellenőrizni, hogy nem csak referenciát néz-e
                        if (!order.Food.Ingredients.Contains(i) &&
                            cookedIngredients.Contains(i))
                        {
                            order.Food.Ingredients.Add(i);
                            cookedIngredients.Remove(i);
                        }

                        if (IsFoodReady(order))
                        {
                            ServingFood(order.Food);
                            waitingForCookableIngredient.Remove(order); // TODO...
                        }
                    }
                }
            }
        }

        bool IsFoodReady(Order order)
        {
            bool foodIsReady = true;

            if (order.Ingredients.HasFlag(Ingredients.Ingredients.Bun) &&
                order.Food.Ingredients.Count(i => i.GetType() == typeof(Bun)) < 1)
            {
                foodIsReady = false;
            }
            else if (order.Ingredients.HasFlag(Ingredients.Ingredients.Patty) && 
                     order.Food.Ingredients.Count(i => i.GetType() == typeof(Patty)) < 1)
            {
                foodIsReady = false;
            }
            else if (order.Ingredients.HasFlag(Ingredients.Ingredients.DoublePatty) &&
                     order.Food.Ingredients.Count(i => i.GetType() == typeof(Patty)) < 2)
            {
                foodIsReady = false;
            }
            else if (order.Ingredients.HasFlag(Ingredients.Ingredients.Lettuce) &&
                     order.Food.Ingredients.Count(i => i.GetType() == typeof(Lettuce)) < 1)
            {
                foodIsReady = false;
            }
            else if (order.Ingredients.HasFlag(Ingredients.Ingredients.Tomato) &&
                     order.Food.Ingredients.Count(i => i.GetType() == typeof(Tomato)) < 1)
            {
                foodIsReady = false;
            }
            else if (order.Ingredients.HasFlag(Ingredients.Ingredients.Cheese) &&
                     order.Food.Ingredients.Count(i => i.GetType() == typeof(Cheese)) < 1)
            {
                foodIsReady = false;
            }
            else if (order.Ingredients.HasFlag(Ingredients.Ingredients.DoubleCheese) &&
                     order.Food.Ingredients.Count(i => i.GetType() == typeof(Cheese)) < 2)
            {
                foodIsReady = false;
            }
            else if (order.Ingredients.HasFlag(Ingredients.Ingredients.Ketchup) &&
                     order.Food.Ingredients.Count(i => i.GetType() == typeof(Ketchup)) < 1)
            {
                foodIsReady = false;
            }
            else if (order.Ingredients.HasFlag(Ingredients.Ingredients.Fries) &&
                     order.Food.Ingredients.Count(i => i.GetType() == typeof(Fries)) < 1)
            {
                foodIsReady = false;
            }

            return foodIsReady;
        }

        void ServingFood(Food food)
        {
            Console.WriteLine($"1x {food.Name} served.");
        }

        async Task SortingIngredients()
        {
            while (unprocessedOrders.Count() > 0)
            {
                Start = false;
                var order = unprocessedOrders.Dequeue();
                ordersUnderProcess.Add(order);

                var ingredients = CollectIngredients(order.Ingredients);
                foreach (var i in ingredients.Where(i => i.NeedsCooking))
                {
                    Console.WriteLine($"{i.ToString()} prepared for cooking");
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
            if (ingreds.HasFlag(Ingredients.Ingredients.Patty))
            {
                ingredients.Add(new Patty());
            }
            if (ingreds.HasFlag(Ingredients.Ingredients.DoublePatty))
            {
                ingredients.Add(new Patty());
                ingredients.Add(new Patty());
            }
            if (ingreds.HasFlag(Ingredients.Ingredients.Lettuce))
            {
                ingredients.Add(new Lettuce());
            }
            if (ingreds.HasFlag(Ingredients.Ingredients.Tomato))
            {
                ingredients.Add(new Tomato());
            }
            if (ingreds.HasFlag(Ingredients.Ingredients.Cheese))
            {
                ingredients.Add(new Cheese());
            }
            if (ingreds.HasFlag(Ingredients.Ingredients.DoubleCheese))
            {
                ingredients.Add(new Cheese());
                ingredients.Add(new Cheese());
            }
            if (ingreds.HasFlag(Ingredients.Ingredients.Ketchup))
            {
                ingredients.Add(new Ketchup());
            }
            if (ingreds.HasFlag(Ingredients.Ingredients.Fries))
            {
                ingredients.Add(new Fries());
            }

            return ingredients;
        }

        async Task Cooking()
        {
            while (ordersUnderProcess.Count() > 0 || Start)
            {
                var fries = ingredientsNeedCook.Where(i => i.GetType() == typeof(Fries)).Select(i => i as Fries);
                var patties = ingredientsNeedCook.Where(i => i.GetType() == typeof(Patty)).Select(i => i as Patty);

                if (fries.Count() >= oven.MaximumCapacity || ordersUnderProcess.Count() == 0)
                {
                    // cooking of fries
                    if (fries.Count() >= oven.MaximumCapacity)
                    {
                        fries = fries.Take(4);
                    }
                    // TODO: az elkészült hozzávalót hozzáadni a cookedIngredients-hez és kivenni a ingredientsNeedCook-ból
                    var roastedFires = oven.CookFires(fries);
                    foreach (var roastedFry in roastedFires.Result)
                    {
                        cookedIngredients.Add(roastedFry);
                    }
                    foreach (var fry in fries)
                    {
                        ingredientsNeedCook.Remove(fry);
                    }
                }
                else if (patties.Count() >= oven.MaximumCapacity || ordersUnderProcess.Count() == 0)
                {
                    // cooking of patties
                    if (patties.Count() >= oven.MaximumCapacity)
                    {
                        patties = patties.Take(4);
                    }
                    // TODO: az elkészült hozzávalót hozzáadni a cookedIngredients-hez és kivenni a ingredientsNeedCook-ból
                    var roastedPatties = oven.CookPatties(patties);
                    foreach (var roastedPatty in roastedPatties.Result)
                    {
                        cookedIngredients.Add(roastedPatty);
                    }
                    foreach (var patty in patties)
                    {
                        ingredientsNeedCook.Remove(patty); // itt miért lép ki egy után???
                    }
                }
            }
        }
    }
}
