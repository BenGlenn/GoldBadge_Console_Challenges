using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepository
{
    public class ChallengeOneRepo
    {
        private List<MenuItem> _listMenuItems = new List<MenuItem>();

        //Create
        public void AddNewItem(MenuItem menuItem)
        {
            _listMenuItems.Add(menuItem);
        }

        //Read
       public List<MenuItem> SeeListOfItems()
        {
            return _listMenuItems;
        }

        // Update

        public bool UpdateExistingMenu(string itemId, MenuItem newItem)
        {
            MenuItem oldItem = GetItemByID(itemId);

            if(oldItem != null)
            {
                oldItem.MealName = newItem.MealName;
                oldItem.Description = newItem.Description;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Price = newItem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete 

        public bool RemoveItemFromMenu(string itemNumber)
        {
            MenuItem item = GetItemByID(itemNumber);

            if(item == null)
            {
                return false;
            }

            int initialCount = _listMenuItems.Count;
            _listMenuItems.Remove(item);

            if (initialCount > _listMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method 

        public MenuItem GetItemByID(string itemId)
        {
            foreach(MenuItem item in _listMenuItems)
            {
                if (item.MealNumber == itemId)
                {
                    return item;
                }
            }

            return null;
               
        }
    }
}
