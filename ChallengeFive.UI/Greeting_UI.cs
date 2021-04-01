using ChallengeFive.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFive.UI
{
    public class Greeting_UI
    {
        private readonly CustomerRepository _customerRepo = new CustomerRepository();
        public void Run()
        {
            SeedCustomers();
            RunMenu();
        }

        public void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("CUSTOMER DIRECTORY MAIN MENU");
                Console.WriteLine(" ");
                Console.WriteLine("Select a number:\n" +
                    "1: View All Customers\n" +
                    "2: Find a Customer\n" +
                    "3: Add a Customer\n" +
                    "4: Edit Customer Information\n" +
                    "5: Delete a Customer\n" +
                    "6: Exit");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        ShowAllCustomers();
                        break;
                    case "2":
                        FindCustomer();
                        break;
                    case "3":
                        CreateCustomer();
                        break;
                    case "4":
                        EditCustomer();
                        break;
                    case "5":
                        DeleteCustomer();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please make a selection between 1 and 6\n" + "Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ShowAllCustomers()
        {
            BeginSubmenu("ALL CUSTOMERS");
            Console.WriteLine("    _________________________________________________________________________________________________________________________________");
            Console.WriteLine("   |   First Name   |     Last Name     |    Type    |                                 Email Message                                 |");
            Console.WriteLine("   |----------------|-------------------|------------|-------------------------------------------------------------------------------|");
            List<Customer> allCustomers = _customerRepo.GetCustomers().OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            foreach (Customer customer in allCustomers)
            {
                Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(customer.FirstName, "text", 16)}|" +
                    $"{TableMethods.TableMethods.GenerateCell(customer.LastName, "text", 19)}|" +
                    $"{TableMethods.TableMethods.GenerateCell(customer.CustomerType.ToString(), "text", 12)}|" +
                    $"{TableMethods.TableMethods.GenerateCell(customer.Message, "text", 79)}|");
            }
            Console.WriteLine("   |---------------------------------------------------------------------------------------------------------------------------------|");
            EndSubmenu();
        }

        public void FindCustomer()
        {
            BeginSubmenu("FIND A CUSTOMER");
            Console.WriteLine("Enter the customer's first name:\n");
            string firstNameInput = Console.ReadLine().ToLower();
            Console.WriteLine(" ");
            Console.WriteLine("Enter the customer's last name:\n");
            string lastNameInput = Console.ReadLine().ToLower();
            Console.WriteLine("    _________________________________________________________________________________________________________________________________");
            Console.WriteLine("   |   First Name   |     Last Name     |    Type    |                                 Email Message                                 |");
            Console.WriteLine("   |----------------|-------------------|------------|-------------------------------------------------------------------------------|");
            Customer foundCustomer = _customerRepo.GetCustomerByFullName(lastNameInput, firstNameInput);
            Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(foundCustomer.FirstName, "text", 16)}|" +
                $"{TableMethods.TableMethods.GenerateCell(foundCustomer.LastName, "text", 19)}|" +
                $"{TableMethods.TableMethods.GenerateCell(foundCustomer.CustomerType.ToString(), "text", 12)}|" +
                $"{TableMethods.TableMethods.GenerateCell(foundCustomer.Message, "text", 79)}|");
            Console.WriteLine("   |---------------------------------------------------------------------------------------------------------------------------------|");
            EndSubmenu();
        }

        public void CreateCustomer()
        {
            BeginSubmenu("ADD CUSTOMER TO DIRECTORY");
            Customer userCustomer = new Customer();
            Console.WriteLine("Enter the customer's first name:\n");
            userCustomer.FirstName = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Enter the customer's last name:\n");
            userCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Choose the type of customer:\n" +
                "1: Current Customer\n" +
                "2: Past Customer\n" +
                "3: Potential Customer\n");
            string typeInput = Console.ReadLine();
            switch (typeInput)
            {
                case "1":
                    userCustomer.CustomerType = CustomerType.Current;
                    break;
                case "2":
                    userCustomer.CustomerType = CustomerType.Past;
                    break;
                case "3":
                    userCustomer.CustomerType = CustomerType.Potential;
                    break;
                default:
                    Console.WriteLine("Please choose a number 1-3.");
                    break;
            }
            _customerRepo.AddCustomer(userCustomer);
            Console.WriteLine("The new customer has been added!");
            EndSubmenu();
        }

        public void EditCustomer()
        {
            BeginSubmenu("EDIT CUSTOMER INFORMATION");
            Console.WriteLine("Enter the customer's first name:\n");
            string firstNameInput = Console.ReadLine().ToLower();
            Console.WriteLine(" ");
            Console.WriteLine("Enter the customer's last name:\n");
            string lastNameInput = Console.ReadLine().ToLower();
            Console.WriteLine("    _________________________________________________________________________________________________________________________________");
            Console.WriteLine("   |   First Name   |     Last Name     |    Type    |                                 Email Message                                 |");
            Console.WriteLine("   |----------------|-------------------|------------|-------------------------------------------------------------------------------|");
            Customer foundCustomer = _customerRepo.GetCustomerByFullName(lastNameInput, firstNameInput);
            Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(foundCustomer.FirstName, "text", 16)}|" +
                $"{TableMethods.TableMethods.GenerateCell(foundCustomer.LastName, "text", 19)}|" +
                $"{TableMethods.TableMethods.GenerateCell(foundCustomer.CustomerType.ToString(), "text", 12)}|" +
                $"{TableMethods.TableMethods.GenerateCell(foundCustomer.Message, "text", 79)}|");
            Console.WriteLine("   |---------------------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Please enter customer information as you would like it stored:\n");
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Customer updatedCustomer = new Customer();
            Console.WriteLine("Enter the customer's first name:\n");
            updatedCustomer.FirstName = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Enter the customer's last name:\n");
            updatedCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Choose the type of customer:\n" +
                "1: Current Customer\n" +
                "2: Past Customer\n" +
                "3: Potential Customer\n");
            string typeInput = Console.ReadLine();
            switch (typeInput)
            {
                case "1":
                    updatedCustomer.CustomerType = CustomerType.Current;
                    break;
                case "2":
                    updatedCustomer.CustomerType = CustomerType.Past;
                    break;
                case "3":
                    updatedCustomer.CustomerType = CustomerType.Potential;
                    break;
                default:
                    Console.WriteLine("Please choose a number 1-3.");
                    break;
            }
            _customerRepo.UpdateCustomer(lastNameInput, firstNameInput, updatedCustomer);
            Console.WriteLine("The customer has been successfully updated!");
            EndSubmenu();
        }

        public void DeleteCustomer()
        {
            BeginSubmenu("REMOVE CUSTOMER FROM DIRECTORY");
            Console.WriteLine("Enter the customer's first name:\n");
            string firstNameInput = Console.ReadLine().ToLower();
            Console.WriteLine(" ");
            Console.WriteLine("Enter the customer's last name:\n");
            string lastNameInput = Console.ReadLine().ToLower();
            Console.WriteLine("    _________________________________________________________________________________________________________________________________");
            Console.WriteLine("   |   First Name   |     Last Name     |    Type    |                                 Email Message                                 |");
            Console.WriteLine("   |----------------|-------------------|------------|-------------------------------------------------------------------------------|");
            Customer foundCustomer = _customerRepo.GetCustomerByFullName(lastNameInput, firstNameInput);
            Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(foundCustomer.FirstName, "text", 16)}|" +
                $"{TableMethods.TableMethods.GenerateCell(foundCustomer.LastName, "text", 19)}|" +
                $"{TableMethods.TableMethods.GenerateCell(foundCustomer.CustomerType.ToString(), "text", 12)}|" +
                $"{TableMethods.TableMethods.GenerateCell(foundCustomer.Message, "text", 79)}|");
            Console.WriteLine("   |---------------------------------------------------------------------------------------------------------------------------------|");
            Console.WriteLine(" ");
            Console.WriteLine("Do you want to permanantly remove this customer from the directory?\n" +
                "1: Yes\n" +
                "2: No\n");
            string userConfirm = Console.ReadLine();
            switch (userConfirm)
            {
                case "1":
                    _customerRepo.RemoveCustomer(foundCustomer);
                    break;
                case "2":
                    Console.WriteLine("The customer remains in the directory.");
                    break;
                default:
                    Console.WriteLine("Select option 1 or 2.");
                    break;
            }
            EndSubmenu();
        }

        public void BeginSubmenu(string submenuHeader)
        {
            Console.Clear();
            Console.WriteLine(submenuHeader);
            Console.WriteLine(" ");
        }

        public void EndSubmenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }

        public void SeedCustomers()
        {
            Customer one = new Customer("Bluth", "Michael", CustomerType.Past);
            Customer two = new Customer("Funke", "Lindsay", CustomerType.Past);
            Customer three = new Customer("Bluth", "Gob", CustomerType.Potential);
            Customer four = new Customer("Bluth", "Buster", CustomerType.Potential);
            Customer five = new Customer("Bluth", "Lucille", CustomerType.Current);
            Customer six = new Customer("Bluth", "George", CustomerType.Past);
            Customer seven = new Customer("Bluth", "Oscar", CustomerType.Potential);
            Customer eight = new Customer("Bluth", "Geroge-Michael", CustomerType.Potential);
            Customer nine = new Customer("Funke", "Maeby", CustomerType.Current);
            Customer ten = new Customer("Funke", "Tobias", CustomerType.Past);
            Customer eleven = new Customer("Parmesan", "Gene", CustomerType.Current);


            _customerRepo.AddCustomer(three);
            _customerRepo.AddCustomer(four);
            _customerRepo.AddCustomer(five);
            _customerRepo.AddCustomer(six);
            _customerRepo.AddCustomer(seven);
            _customerRepo.AddCustomer(eight);
            _customerRepo.AddCustomer(nine);
            _customerRepo.AddCustomer(ten);
            _customerRepo.AddCustomer(eleven);
        }
    }
}
