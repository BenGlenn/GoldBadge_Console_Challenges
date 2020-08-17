using System;
using ChallengeOneRepository;
using MenuUserUI;
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
            
            //Act
            //Assert
        
    }
}
