using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeFramework.Classes
{
   public class Ingredient
    {
     
            public string MealName { get; set; }

            public Ingredient()
            {

            }


            public Ingredient(string mealname)
            {
                MealName = mealname;
            }
        
    }
}
