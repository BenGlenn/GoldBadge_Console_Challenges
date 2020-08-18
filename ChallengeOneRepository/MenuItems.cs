using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepository
{
    public class MenuItem
    {
        public string MealName { get; set; }
        public string IdNumber { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }

        public MenuItem() { }
        public MenuItem(string mealName, string mealID, string description, string ingredient, decimal price)
        {
            MealName = mealName;
            IdNumber = mealID;
            Description = description;
            Ingredients = ingredient;
            Price = price;

        }

     
    }
}
