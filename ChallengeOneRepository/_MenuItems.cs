using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepository
{
    public class MenuItems
    {
        public string MealName { get; set; }
        public string MealNumber { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }

        public MenuItems() { }
        public MenuItems(string mealName, string mealID, string description, string ingredient, decimal price)
        {
            MealName = mealName;
            MealNumber = mealID;
            Description = description;
            Ingredients = ingredient;
            Price = price;

        }

     
    }
}
