using ChallengeOne.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOne.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMenuItem_ShouldReturnTrue()
        {
            //Arrange
            MenuRepository menuRepo = new MenuRepository();
            Menu menuItem = new Menu();
            
            //Act
            bool addSucceeded = menuRepo.AddMenuItem(menuItem);

            //Assert
            Assert.IsTrue(addSucceeded);
        }

        [TestMethod]
        public void GetAllMenuItems_ShouldReturnCorrectList()
        {
            //Arrange
            MenuRepository menuRepo = new MenuRepository();
            Menu menuItem = new Menu();

            //Act
            menuRepo.AddMenuItem(menuItem);
            List<Menu> listOfMenus = menuRepo.GetAllMenuItems();
            bool addedMenuItemIsPresent = listOfMenus.Contains(menuItem);

            //Assert
            Assert.IsTrue(addedMenuItemIsPresent);
        }

        private MenuRepository _menuRepo;
        private Menu _menuItem;
        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new MenuRepository();

            List<string> ingredients = new List<string>()
            {
                "1 box Creamette thin spaghetti",
                "1 jar Ragu spaghetti sauce",
                "Dash of Kraft grated parmesan cheese"
            };
            _menuItem = new Menu(900, "Spaghetti a la Collin", "A Wednesday night delicacy. Bon appetit!", ingredients, 3.99);
            _menuRepo.AddMenuItem(_menuItem);
        }

        [TestMethod]
        public void UpdateMenuItem_ShouldReturnTrue()
        {
            //Arrange
            List<string> newIngredients = new List<string>()
            {
                "1 box Barilla spaghetti",
                "1 jar artisan marinara sauce",
                "1 cup of fresh shredded parmesan cheese"
            };
            Menu newMenuItem = new Menu(901, "Spaghetti a la Erin", "A Thursday evening treat. Dig in!", newIngredients, 4.99);

            //Act
            bool updateSucceeded = _menuRepo.UpdateMenuItem(900, newMenuItem);

            //Assert
            Assert.IsTrue(updateSucceeded);
        }

        [TestMethod]
        public void RemoveMenuItem_ShouldReturnTrue()
        {
            //Arrange
            Menu menuItem = _menuRepo.GetMenuItemByNumber(900);

            //Act
            bool removeSucceeded = _menuRepo.RemoveMenuItem(menuItem);

            //Assert
            Assert.IsTrue(removeSucceeded);
        }

        [TestMethod]
        public void GetMenuItemByNumber_ShouldReturnCorrectMenuItem()
        {
            //Arranged by Arrange() method

            //Act
            Menu foundMenuItem = _menuRepo.GetMenuItemByNumber(900);

            //Assert
            Assert.AreEqual(_menuItem, foundMenuItem);
        }
    }
}
