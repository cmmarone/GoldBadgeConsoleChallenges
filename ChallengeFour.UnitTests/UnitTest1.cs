using ChallengeFour.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeFour.UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        private OutingRepository _outingRepo;
        private Outing _outing1;
        private Outing _outing2;
        private Outing _outing3;
        private Outing _outing4;

        [TestInitialize]
        public void Arrange()
        {
            _outingRepo = new OutingRepository();

            DateTime dt1 = new DateTime(2019, 4, 2);
            _outing1 = new Outing(dt1, EventType.Bowling, 9, 430.14);
            _outingRepo.AddOuting(_outing1);
            DateTime dt2 = new DateTime(2019, 5, 1);
            _outing2 = new Outing(dt2, EventType.Golf, 4, 559.81);
            _outingRepo.AddOuting(_outing2);
            DateTime dt3 = new DateTime(2019, 5, 14);
            _outing3 = new Outing(dt3, EventType.AmusementPark, 8, 947.32);
            _outingRepo.AddOuting(_outing3);
      
            _outing4 = new Outing(DateTime.Now, EventType.Golf, 3, 810.02);
            _outingRepo.AddOuting(_outing4);
        }






        [TestMethod]
        public void AddOuting_ShouldReturnTrue()
        {
            //Arrange
            OutingRepository outingRepo = new OutingRepository();
            Outing outing = new Outing();

            //Act
            bool addSucceeded = outingRepo.AddOuting(outing);

            //Assert
            Assert.IsTrue(addSucceeded);
        }

        [TestMethod]
        public void GetAllOutings_ShouldReutrnCorrectList()
        {
            //Arrange was done in Arrange()

            //Act
            List<Outing> listOfOutings = _outingRepo.GetAllOutings();
            bool addedOutingIsPresent = listOfOutings.Contains(_outing1);

            //Assert
            Assert.IsTrue(addedOutingIsPresent);
        }

        [TestMethod]
        public void GetOutingsYTD_ShouldReturnCorrectList()
        {
            //Arrange was done in Arrange()

            //Act
            List<Outing> listOfOutings = _outingRepo.GetOutingsYTD();
            bool relevantOutingIsPresent = listOfOutings.Contains(_outing4);
            bool irrelevantOutingIsPresent = listOfOutings.Contains(_outing1);

            //Assert
            Assert.IsTrue(relevantOutingIsPresent);
            Assert.IsFalse(irrelevantOutingIsPresent);
        }

        [TestMethod]
        public void GetAllOutingsByEventType_ShouldRetrunCorrectList()
        {
            //Arrange was done in Arrange()

            //Act
            List<Outing> listOfOutings = _outingRepo.GetAllOutingsByEventType(EventType.Bowling);
            bool relevantOutingIsPresent = listOfOutings.Contains(_outing1);
            bool irrelevantOutingIsPresent = listOfOutings.Contains(_outing2);

            //Assert
            Assert.IsTrue(relevantOutingIsPresent);
            Assert.IsFalse(irrelevantOutingIsPresent);
        }

        [TestMethod]
        public void GetOutingsByEventTypeYTD_ShouldReturnCorrectList()
        {
            //Arrange was done in Arrange()

            //Act
            List<Outing> listOfOutings = _outingRepo.GetOutingsByEventTypeYTD(EventType.Golf);
            bool relevantOutingIsPresent = listOfOutings.Contains(_outing4);
            bool irrelevantOutingIsPresent = listOfOutings.Contains(_outing2);

            //Assert
            Assert.IsTrue(relevantOutingIsPresent);
            Assert.IsFalse(irrelevantOutingIsPresent);
        }
    }
}
