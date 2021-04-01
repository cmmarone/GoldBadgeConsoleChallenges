using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive.Repository
{
    public class CustomerRepository
    {
        List<Customer> _customerDirectory = new List<Customer>();

        public bool AddCustomer(Customer customer)
        {
            int listSizeBefore = _customerDirectory.Count;
            _customerDirectory.Add(customer);
            bool addSucceeded = (_customerDirectory.Count > listSizeBefore) ? true : false;
            return addSucceeded;
        }

        public List<Customer> GetCustomers()
        {
            return _customerDirectory;
        }

        public bool UpdateCustomer(string lastName, string firstName, Customer updatedCustomer)
        {
            Customer existingCustomer = GetCustomerByFullName(lastName, firstName);
            if (existingCustomer != null)
            {
                existingCustomer.LastName = updatedCustomer.LastName;
                existingCustomer.FirstName = updatedCustomer.LastName;
                existingCustomer.CustomerType = updatedCustomer.CustomerType;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveCustomer(Customer existingCustomer)
        {
            bool isDeleted = _customerDirectory.Remove(existingCustomer);
            return isDeleted;
        }

        public Customer GetCustomerByFullName(string lastName, string firstName)
        {
            foreach (Customer customer in _customerDirectory)
            {
                if ((customer.LastName.ToLower() == lastName.ToLower()) && (customer.FirstName.ToLower() == firstName.ToLower()))
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
