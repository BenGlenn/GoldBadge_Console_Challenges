using ChallengeOneRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace MenuUserUI
{
    public class ProgramUI
    {
        private bool _isRunning = true;
        private readonly ChallengeOneRepo _menuRepo = new ChallengeOneRepo();

        public void Start()
        {
            SeedContentList();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = OpenMainMenu();
                OpenMenuItem(userInput);
            }
        }

        private string OpenMainMenu()
        {
           Console.Clear();
            Console.WriteLine(
                 "Welcome to your menu item management list.\n" +
                          "What you you like to do? Choose a number from  the items bellow:\n" +
                          "\n" +
                          "1. Show All Menu Items.\n" +
                          "2. Find Item By Item ID.\n" +
                          "3. Add New Item.\n" +
                          "4. Update Item on Menu.\n" +
                          "5. Delete Item on Menu.\n" +
                          "6. Exit");
            string userInput = Console.ReadLine();
            return userInput;
                

        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayAllMenuItems();
                    break;
                case "2":
                    DisplayById();
                    break;
                case "3":
                    CreateNewMenuItem();
                 
                    break;
                case "4":
                    UpdateMenuItem();
                    break;
                case "5":
                    DeleteItemFromMenu();
                    break;
                case "6":
                    _isRunning = false;
                    return;
                default:
                    break;
            }
            Console.WriteLine("Press a key to return to the menu...");
            Console.ReadKey();
            return;

        }

        private void DisplayAllMenuItems()
        {
            List<MenuItem> listOfMenuItems = _menuRepo.SeeListOfItems();

            foreach( MenuItem menuItems in listOfMenuItems)
            {
                DisplayContent(menuItems);
            }
        }

        private void DisplayContent(MenuItem menuItems)
        {
            Console.WriteLine(
                $"Item Name: {menuItems.MealName}\n" +
                $"Item ID: {menuItems.IdNumber}\n" +
                $"Item Description: {menuItems.Description}\n" +
                $"Item Ingredients: {menuItems.Ingredients}\n" +
                $"Item Price: {menuItems.Price}");
        }

        private void DisplayById()
        {
            Console.WriteLine("Enter Item ID: ");
            string itemID = Console.ReadLine();
            if( itemID != null)
            {
                DisplayContentById(itemID);
               
            }
        }

        private void CreateNewMenuItem()
        {
            Console.Write("Lets add a new item to your menu! Enter the name of your Item: ");
            string mealName = Console.ReadLine();
            Console.Write("Enter Item ID Number: ");
            string mealID = Console.ReadLine();
            Console.Write("Enter a description: ");
            string description = Console.ReadLine();
            Console.Write("Enter the ingredients: ");
            string ingredients = Console.ReadLine();
            Console.Write("Enter a price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            MenuItem newItem = new MenuItem(mealName, mealID, description, ingredients, price);
            _menuRepo.AddNewItem(newItem);
        }

        private void UpdateMenuItem()
        {
            Console.Write("Enter the ID  number of the item you would like to update: ");
            string itemID = Console.ReadLine();
            if (itemID != null)
            {
                DisplayContentById(itemID);
                Console.Write("\n" +
                    "Lets update your menu item.\n" +
                    "\n" +
                    "What is your new name for this item: ");
                string mealName = Console.ReadLine();
                Console.Write("Enter a description: ");
                string description = Console.ReadLine();
                Console.Write("Enter the ingredients: ");
                string ingredients = Console.ReadLine();
                Console.Write("Enter a price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                MenuItem updateItem = new MenuItem(mealName, itemID, description, ingredients, price);
                _menuRepo.UpdateExistingMenu(itemID, updateItem);


            }
        }

     


        private void DeleteItemFromMenu()
        {
            DisplayAllMenuItems();
            Console.Write("Enter the ID of the item you would like to remove: ");
            string input = Console.ReadLine();

            bool wasDeleted = _menuRepo.RemoveItemFromMenu(input);

            if (wasDeleted)
            {
                Console.WriteLine("Your menu item was deleted");
            }
            else
            {
                Console.WriteLine("Your item could not be deleted");
            }


           
        }


        // Helper Multi Use Method 
        private void DisplayContentById(string itemID)
        {

            MenuItem searchResult = _menuRepo.GetItemByID(itemID);

            if (searchResult != null)
            {
                DisplayContent(searchResult);
            }
            else
            {
                Console.WriteLine("Invalid Item. What do you think this is, McDonalds?");
            }

        }



        private void SeedContentList()
        {
            MenuItem pbj = new MenuItem("Penut Butter and Jelly", "59", "Two pieces of bread with penut butter and jelly in the middle", "Bread. Penut. ButterJelly.", 10.99m);

            MenuItem benny = new MenuItem("Egg Benny", "49", "The most amazing eggs in the world!", "LOVE!", 12.99m);

            MenuItem sos = new MenuItem("S--t on a Shingle", "39", "Burnt toast with gravy on it", "Toast. Bean Gravy.", 4.99m);

            _menuRepo.AddNewItem(pbj);
            _menuRepo.AddNewItem(benny);
            _menuRepo.AddNewItem(sos);


        }

    }
}
