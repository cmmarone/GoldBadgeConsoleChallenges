using ChallengeTwo.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwo.UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        private ClaimRepository _claimRepo;
        private Claim _claim1;
        private Claim _claim2;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepository();

            DateTime dt1a = new DateTime(20, 03, 22);
            DateTime dt1b = new DateTime(20, 03, 25);
            _claim1 = new Claim(0020021844, ClaimType.Car, "Hail damage to roof and hood", 1100, dt1a, dt1b);
            _claimRepo.AddClaim(_claim1);

            DateTime dt2a = new DateTime(20, 04, 01);
            DateTime dt2b = new DateTime(20, 04, 14);
            _claim2 = new Claim(0701004244, ClaimType.Car, "Single-car accident on W. 86th St", 4500, dt2a, dt2b);
            _claimRepo.AddClaim(_claim2);
        }






        [TestMethod]
        public void AddClaim_ShouldReturnTrue()
        {
            //Arrange
            ClaimRepository claimRepo = new ClaimRepository();
            Claim claim = new Claim();

            //Act
            bool addSucceeded = claimRepo.AddClaim(claim);

            //Assert
            Assert.IsTrue(addSucceeded);
        }

        [TestMethod]
        public void GetAllClaims_ShouldReturnCorrectQueue()
        {
            //Arrange
            Queue<Claim> queueOfClaims = _claimRepo.GetAllClaims();

            //Act
            bool addedClaimIsPresent = queueOfClaims.Contains(_claim1);

            //Assert
            Assert.IsTrue(addedClaimIsPresent);
        }

        [TestMethod]
        public void RemoveTopClaim_ShouldReturnClaim()
        {
            //Arrange done in Arrange() (there are claims to dequeue in _claimRepo)

            //Act
            Claim removedClaim = _claimRepo.RemoveTopClaim();

            //Assert
            Assert.IsNotNull(removedClaim);
        }

        [TestMethod]
        public void PeekNextClaim_ShouldReturnAClaim()
        {
            //Arrange done in Arrange() (there are claims to peek in _claimRepo)

            //Act
            Claim peekedClaim = _claimRepo.PeekNextClaim();

            //Assert
            Assert.IsNotNull(peekedClaim);
        }
    }
}
