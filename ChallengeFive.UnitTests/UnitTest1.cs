using ChallengeFive.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeFive.UnitTests
{
    [TestClass]
    public class UnitTest1
    {


        private CustomerRepository _customerRepo;
        private Customer _customer1;
        private Customer _customer2;

        [TestInitialize]

        public void Arrange()
        {
            _customerRepo = new CustomerRepository();

            _customer1 = new Customer("Bluth", "Michael", CustomerType.Past);
            _customerRepo.AddCustomer(_customer1);
            _customer2 = new Customer("Funke", "Lindsay", CustomerType.Past);
            _customerRepo.AddCustomer(_customer2);
        }





        [TestMethod]
        public void AddCustomer_ShouldReturnTrue()
        {
            //Arrange
            CustomerRepository customerRepo = new CustomerRepository();
            Customer customer = new Customer();

            //Act
            bool addSucceeded = customerRepo.AddCustomer(customer);

            //Assert
            Assert.IsTrue(addSucceeded);
        }

        [TestMethod]
        public void GetCustomers_ShouldReturnCorrectList()
        {
            //Arrange is done in Arrange()

            //Act
            List<Customer> listOfCustomers = _customerRepo.GetCustomers();
            bool addedCustomerIsPresent = listOfCustomers.Contains(_customer1);

            //Assert
            Assert.IsTrue(addedCustomerIsPresent);
        }

        [TestMethod]
        public void UpdateCustomer_ShouldReturnTrue()
        {
            //Arrange
            Customer newCustomer = new Customer("Funke", "Lindsay", CustomerType.Current);

            //Act
            bool updateSucceeded = _customerRepo.UpdateCustomer("Funke", "Lindsay", newCustomer);

            //Assert
            Assert.IsTrue(updateSucceeded);
        }

        [TestMethod]
        public void RemoveCustomer_ShouldReturnTrue()
        {
            //Arrange is done in Arrange()

            //Act
            bool removeSucceeded = _customerRepo.RemoveCustomer(_customer2);

            //Assert
            Assert.IsTrue(removeSucceeded);
        }

        [TestMethod]
        public void GetCustomerByFullName_ShouldReturnCorrectCustomer()
        {
            //Arranged by Arrange() method

            //Act
            Customer foundCustomer = _customerRepo.GetCustomerByFullName("Bluth", "Michael");

            //Assert
            Assert.AreEqual(_customer1, foundCustomer);

        }
    }
}
