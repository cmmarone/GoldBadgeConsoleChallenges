using ChallengeThree.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThree.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private BadgeRepository _badgeRepo;
        private Badge _badge1;
        private Badge _badge2;
     
        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepository();

            List<string> doorAccess1 = new List<string>() { "A1", "A2", "A3" };
            _badge1 = new Badge(1111111111, doorAccess1);
            _badgeRepo.AddBadge(_badge1);

            List<string> doorAccess2 = new List<string>() { "B1", "B2", "B3", "B4" };
            _badge2 = new Badge(1111122222, doorAccess2);
            _badgeRepo.AddBadge(_badge2);
        }


        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            //Arrange
            BadgeRepository badgeRepo = new BadgeRepository();
            Badge badge = new Badge();

            //Act
            bool addSucceeded = badgeRepo.AddBadge(badge);

            //Assert
            Assert.IsTrue(addSucceeded);
        }

        [TestMethod]
        public void GetAllBadges_ShouldReturnCorrectDictionary()
        {
            //Arrange
            Dictionary<int, List<string>> dictionaryOfBadges = _badgeRepo.GetAllBadges();

            //Act
            bool addedBadgeIsPresent = dictionaryOfBadges.ContainsKey(_badge1.BadgeID);

            //Assert
            Assert.IsTrue(addedBadgeIsPresent);
        }

        [TestMethod]
        public void UpdateDoorAccess_ShouldReturnTrue()
        {
            //Arrange
            List<string> updatedDoorAccess = new List<string>() { "A1", "A2", "A4" };
            Badge newBadge = new Badge(1111111111, updatedDoorAccess);

            //Act
            bool updateSucceeded = _badgeRepo.UpdateDoorAccess(1111111111, updatedDoorAccess);

            //Assert
            Assert.IsTrue(updateSucceeded);
        }

        [TestMethod]
        public void RemoveAllDoorAccess_ShouldReturnTrue()
        {
            //Arrange already done in Arrange()

            //Act
            bool removeSucceeded = _badgeRepo.RemoveAllDoorAccess(1111111111);

            //Assert
            Assert.IsTrue(removeSucceeded);
        }

        [TestMethod]
        public void GetBadgeByBadgeID_ShouldReturnCorrectKeyValuePair()
        {
            //Arranged by Arrange() method

            //Act
            KeyValuePair<int, List<string>> foundBadge = _badgeRepo.GetBadgeByBadgeID(_badge1.BadgeID);

            //Assert
            Assert.AreEqual(_badge1.DoorAccess, foundBadge.Value);

        }
    }
}
