using System;
using System.Collections.Generic;
using ChallengeTwoRepo;
using ChallengeTwoUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeTwoTest
{
    [TestClass]
    public class ClaimTest
    {
        //Arrange
        private ProgramUI _programUI;
        private Repo _repo;
        private TheClaim _theClaim;



        [TestInitialize]
        public void Arrange()
        {
            DateTime dateTimeOne = new DateTime(1998, 12, 8);
            DateTime dateTimeTwo = new DateTime(1980, 12, 29);
            _repo = new Repo();
            _theClaim = new TheClaim(3, ClaimType.Car, "Someone hit a cow!", 300, dateTimeOne, dateTimeTwo, false);

            _repo.AddNewClaim(_theClaim);
        }

        [TestMethod]
        public void AddNewClaim_IsTrue()
        {
            DateTime dateTimeThree = new DateTime(2020, 11, 8);
            DateTime dateTimeFour = new DateTime(2020, 12, 8);
            Repo repo = new Repo();
            TheClaim newClaim = new TheClaim(2, ClaimType.Home, "My She Shed Burt Down", 10, dateTimeThree, dateTimeFour, true);
            repo.AddNewClaim(newClaim);

            Assert.IsTrue(newClaim.ClaimID == 2);
        }

        [TestMethod]
       public void UpdateClaim_IsWorking()
        {
            DateTime dateTimeThree = new DateTime(2020, 11, 8);
            DateTime dateTimeFour = new DateTime(2020, 12, 8);
            _repo = new Repo();
            _theClaim = new TheClaim(2, ClaimType.Home, "My She Shed Burt Down", 10, dateTimeThree, dateTimeFour, true);
            _repo.AddNewClaim(_theClaim);

            decimal newAmound = 100m;

            TheClaim updateClaim = new TheClaim(2, ClaimType.Home, "My She Shed Burt Down", 100, dateTimeThree, dateTimeFour, true);

            _repo.UpdateExistingClaim(2, updateClaim);

            Assert.IsTrue(_theClaim.ClaimAmount == 100);
        }

        [TestMethod]

        public void DeleteClaim_IsWorking()
        {
            double idNum = _theClaim.ClaimID;

            bool removeItemNum = _repo.RemoveClaim(idNum);

            Assert.IsTrue(removeItemNum);

        }

        [TestMethod]

        public void GetMenuItemById()
        {
            TheClaim findItem = _repo.GetClaimByID(3);

            Assert.AreEqual(findItem.ClaimAmount, 300);

        }

        [TestMethod]

        public void DisplayMenuItem_IsTrue()
        {
            List<TheClaim> seeTheList = _repo.GetClaims();

            bool seeTheListHasID = seeTheList.Contains(_theClaim);

            Assert.IsTrue(seeTheListHasID);
        }





    }
}
