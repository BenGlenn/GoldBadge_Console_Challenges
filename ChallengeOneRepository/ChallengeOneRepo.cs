using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepository
{
    public class ChallengeOneRepo
    {
        private List<MenuItems> _listMenuItems = new List<MenuItems>();

        //Create
        public void AddNewItem(MenuItems menuItem)
        {
            _listMenuItems.Add(menuItem);
        }

        //Read
       public List<MenuItems> SeeListOfItems()
        {
            return _listMenuItems;
        }

        // Update

        public bool UpdateExistingMenu(string itemId, MenuItems newItem)
        {
            MenuItems oldItem = GetItemByID(itemId);

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
            MenuItems item = GetItemByID(itemNumber);

            if(item == null)
            {
                return false;
            }

            int initialCount = _listMenuItems.Count;
            _listMenuItems.Remove(item);

            if(initialCount > _listMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method 

        public MenuItems GetItemByID(string itemId)
        {
            foreach(MenuItems item in _listMenuItems)
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
