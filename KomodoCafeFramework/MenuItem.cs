using System;
using System.Collections.Generic;
using System.Text;

namespace KomodoCafeFramework.Classes
{
    public class MenuItem
    {


        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public double Price { get; set; }

        public MenuItem(int mealNumber, string mealName, string description, List<Ingredient> ingredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
