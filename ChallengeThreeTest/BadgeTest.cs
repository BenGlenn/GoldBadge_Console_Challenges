using System;
using ChallengeThreeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThreeTest
{
    [TestClass]
    public class BadgeTest
    {
       
        //Arrange
      
        private Repo _repo;
        private IdBadge _badges;

        // Clearly I have no idea what I am doing with this challenge!

        [TestInitialize]
        public void Arrange()
        {
           
                int newIdBadgeNumber = 8;

                IdBadge addingNewID = new IdBadge(newIdBadgeNumber);
                string name = "Betty";

                List<string> listOfDoors = new List<string>();

                string doorToAdd = "A7";
                listOfDoors.Add(doorToAdd);
                string anotherDoor = "A4";
                listOfDoors.Add(anotherDoor);

                BadgeAccess accessAdding = new BadgeAccess(name, listOfDoors);
                _accessRepo.AddToDictionary(addingNewID, accessAdding);

           

        }

        [TestMethod]
        public void AddNewBadge_IsTrue()
        {
           
        }

    }
}
