using ChallengeOneRepository;
using System;
using System.Collections.Generic;
using System.Linq;
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
                 "Welcome to your menue item management list.\n" +
                          "What you you like to do? Choose a number from  the items bellow:\n" +
                          "\n" +
                          "1. Show All Menu Items.\n" +
                          "2. Add New Item to Menu.\n" +
                          "3. Find Item By Item ID Number.\n" +
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
                    //DisplayContentById();
                    break;
                case "3":
                    //CreateNewMenuItem();
                    // Add New Content
                    break;
                case "4":
                    // Update Content
                    break;
                case "5":
                    // Remove Content
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
            List<MenuItems> listOfMenuItems = _menuRepo.SeeListOfItems();

            foreach( MenuItems menuItems in listOfMenuItems)
            {
                DisplayContent(menuItems);
            }
        }

        private void DisplayContent(MenuItems menuItems)
        {
            Console.WriteLine(
                $"Item Name: {menuItems.MealName}\n" +
                $"Item ID: {menuItems.MealNumber}\n" +
                $"Item Description: {menuItems.Description}\n" +
                $"Item Ingredients: {menuItems.Ingredients}\n" +
                $"Item Price: {menuItems.Price}"

                )
        }





        private void SeedContentList()
        {
            MenuItems pbj = new MenuItems("Penut Butter and Jelly", "36459", "Two pieces of bread with penut butter and jelly in the middle," "Bread. Penut Butter. Jelly" 10.99);

        }

    }
}
