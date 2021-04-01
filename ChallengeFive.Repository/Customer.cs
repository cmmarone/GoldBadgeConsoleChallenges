using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive.Repository
{
    public enum CustomerType { Current, Past, Potential }

    public class Customer
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Message
        {
            get
            {
                if (CustomerType == CustomerType.Current)
                {
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                }
                if (CustomerType == CustomerType.Past)
                {
                    return "It's been a long time since we've heard from you, we want you back.";
                }
                if (CustomerType == CustomerType.Potential)
                {
                    return "We currently have the lowest rates on Helicopter Insurance!";
                }
                return null;
            }
        }

        public Customer() { }
        public Customer(string lastName, string firstName, CustomerType customerType)
        {
            LastName = lastName;
            FirstName = firstName;
            CustomerType = customerType;
        }
    }
}
