using System;
using System.Collections.Generic;
using System.Net;
using ChallengeOneRepository;
using ChalkkengOneUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOneTest
{
    [TestClass]
    public class ChallengeOneTest
    {
        //Arrange
        private ProgramUI _programUI;
        private ChallengeOneRepo _repo;
        private MenuItem _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ChallengeOneRepo();
            _programUI = new ProgramUI();
            _menuItem = new MenuItem("Eggs Benny", "44", "Pure amazingness", "Love", 12.99m);

            _repo.AddNewItem(_menuItem);

        }

        [TestMethod]
        public void AddNewMenuItem_ShouldBeTrue()
        {
            ChallengeOneRepo repo = new ChallengeOneRepo();
            MenuItem newItem = new MenuItem("Green Bean Soup", "29", "It's Nasty... Do not order this crap!", "You really don't wanna know!", 9.99m);
            repo.AddNewItem(newItem);

            Assert.IsTrue(newItem.IdNumber == "29");
        }

      [TestMethod]
      public void UpdateExistingMenuItem_ShouldBeTrue()
        {
            _repo = new ChallengeOneRepo();
           _menuItem = new MenuItem("Green Bean Soup", "29", "It's Nasty... Do not order this crap!", "You really don't wanna know!", 9.99m);
            _repo.AddNewItem(_menuItem);

            string mealName = "Spook stew";
            string description = "This stuff is nasty";
            string ingredients = "Frog guts and other nasty things.";

            MenuItem updatedItem = new MenuItem(mealName, "29", description, ingredients, 9.99m);

            _repo.UpdateExistingMenu("29", updatedItem);

            Assert.IsTrue(_menuItem.MealName == "Spook stew");
           
        }

        [TestMethod]

        public void RemoveItemFromMenu_IsTrue()
        {
            string idNum = _menuItem.IdNumber;
         
            bool removeItemNum = _repo.RemoveItemFromMenu(idNum);

            Assert.IsTrue(removeItemNum);

        }

        [TestMethod]

        public void GetMenuItemById()
        {

            MenuItem findItem = _repo.GetItemByID("44");

            Assert.AreEqual(findItem.MealName, "Eggs Benny");
            
           
        }

        [TestMethod]

        public void DisplayMenuItem_IsTrue()
        {
            List<MenuItem> seeTheList = _repo.SeeListOfItems();

            bool seeTheListHasID = seeTheList.Contains(_menuItem);

            Assert.IsTrue(seeTheListHasID);
        }
            
        
    }
}
