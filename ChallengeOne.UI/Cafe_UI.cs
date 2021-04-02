using ChallengeOne.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.UI
{
    public class Cafe_UI
    {
        MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            SeedMenuItems();
            RunProgramMenu();
        }

        public void RunProgramMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("KOMODO CAFE MAIN MENU");
                Console.WriteLine(" ");
                Console.WriteLine("Select a number:\n" +
                    "1: View Current Menu\n" +
                    "2: Add a Dish to the Menu\n" +
                    "3: Edit a Dish in the Current Menu\n" +
                    "4: Remove a Dish from the Current Menu\n" +
                    "5: Exit");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        ViewMenu();
                        break;
                    case "2":
                        CreateMenuItem();
                        break;
                    case "3":
                        EditMenuItem();
                        break;
                    case "4":
                        RemoveMenuItem();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Make a selection between 1 and 5\n" + "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ViewMenu()
        {
            BeginSubmenu("VIEW CURRENT MENU");
            List<Menu> fullMenu = ShowCurrentMenu();
            Console.WriteLine("Would you like to see descriptions or ingredients for any of these dishes?\n" +
                "1: Yes\n" +
                "2: No, return to main menu\n");
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("Please enter the dish number you would like to view.");
                    string menuItemSelection = Console.ReadLine();
                    foreach (Menu menuItem in fullMenu)
                    {
                        if (menuItem.Number == int.Parse(menuItemSelection))
                        {
                            BeginSubmenu("VIEW DISH DETAILS");
                            Console.WriteLine($"Number: {menuItem.Number}");
                            Console.WriteLine($"Name: {menuItem.Name}");
                            Console.WriteLine($"Price: ${menuItem.Price}");
                            Console.WriteLine($"Description: {menuItem.Description}");
                            Console.WriteLine("Ingredients:\n");
                            foreach (string ingredient in menuItem.Ingredients)
                            {
                                Console.WriteLine($"-{ingredient}");
                            }
                            EndSubmenu();
                        }
                    }
                    break;
                case "2":
                    break;
                default:
                    break;
            }
        }

        public void CreateMenuItem()
        {
            BeginSubmenu("ADD AN DISH TO THE MENU");
            Menu userMenuItem = new Menu();
            Console.WriteLine("Please assign a number to the new dish:\n");
            bool keepRunning = true;
            while (keepRunning)
            {
                int itemNumberInput = int.Parse(Console.ReadLine());
                foreach (Menu menuItem in _menuRepo.GetAllMenuItems())
                {
                    if (menuItem.Number == itemNumberInput)
                    {
                        Console.WriteLine($"That number is already assigned to {menuItem.Name}. Please enter another number.\n");
                    }
                    else
                    {
                        userMenuItem.Number = itemNumberInput;
                        keepRunning = false;
                    }
                }
            }
            Console.WriteLine("Enter a name for the dish:\n");
            userMenuItem.Name = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Enter a description for the dish:\n");
            userMenuItem.Description = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Now for the ingredients...");
            Console.WriteLine(" ");
            List<string> ingredientsListInput = new List<string>();
            bool keepRunning2 = true;
            while (keepRunning2)
            {

                Console.WriteLine("Add a dish ingredient:");
                string ingredientInput = Console.ReadLine();
                ingredientsListInput.Add(ingredientInput);
                Console.WriteLine("The ingredient was added. Do you have more ingredients to add (y/n)?");
                string userAnswer = Console.ReadLine();
                switch (userAnswer)
                {
                    case "y":
                        break;
                    case "n":
                        keepRunning2 = false;
                        break;
                    default:
                        keepRunning2 = false;
                        break;
                }
            }
            userMenuItem.Ingredients = ingredientsListInput;
            Console.WriteLine(" ");
            Console.WriteLine("Enter a price for the dish without dollar sign (Ex. 8.99):\n");
            userMenuItem.Price = double.Parse(Console.ReadLine());
            _menuRepo.AddMenuItem(userMenuItem);
            Console.WriteLine("Your dish has been added to the menu!");
            EndSubmenu();
        }

        public void EditMenuItem()
        {
            BeginSubmenu("EDIT A DISH IN THE CURRENT MENU");
            ShowCurrentMenu();
            Console.WriteLine("Please enter the number of the dish you would like to edit:\n");
            int userNumberSelection = int.Parse(Console.ReadLine());
            Menu existingMenuItem = _menuRepo.GetMenuItemByNumber(userNumberSelection);
            Console.WriteLine($"Edit the dish \"{existingMenuItem.Name}\".");
            Menu userUpdatedMenuItem = new Menu();
            Console.WriteLine("Enter a name for the dish:\n");
            userUpdatedMenuItem.Name = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Enter a description for the dish:\n");
            userUpdatedMenuItem.Description = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine("Enter the dish ingredients, hitting enter after each ingredient.  Type 'done' and enter when finished.");
            List<string> updatedIngredientsList = new List<string>();
            bool keepRunning4 = true;
            while (keepRunning4)
            {
                string updatedIngredientInput = Console.ReadLine();
                if (updatedIngredientInput == "done")
                {
                    keepRunning4 = false;
                }
                else
                {
                    updatedIngredientsList.Add(updatedIngredientInput);
                }
            }
            userUpdatedMenuItem.Ingredients = updatedIngredientsList;
            Console.WriteLine(" ");
            Console.WriteLine("Enter a price for the dish without dollar sign (Ex. 8.99):\n");
            userUpdatedMenuItem.Price = double.Parse(Console.ReadLine());
            userUpdatedMenuItem.Number = existingMenuItem.Number;
            _menuRepo.UpdateMenuItem(userNumberSelection, userUpdatedMenuItem);
            Console.WriteLine("The dish has been successfully updated!");
            EndSubmenu();
        }

        public void RemoveMenuItem()
        {
            BeginSubmenu("REMOVE A DISH FROM THE MENU");
            ShowCurrentMenu();
            Console.WriteLine("Please enter the number of the dish you would like to remove:\n");
            int userNumberSelection = int.Parse(Console.ReadLine());
            Menu existingMenuItem = _menuRepo.GetMenuItemByNumber(userNumberSelection);
            string deletedDishName = existingMenuItem.Name;
            Console.WriteLine($"Are you sure you want to remove {existingMenuItem.Name} from the menu?\n" +
                "1: Yes\n" +
                "2: No\n");
            string deleteConfirm = Console.ReadLine();
            switch (deleteConfirm)
            {
                case "1":
                    bool isDeleted = _menuRepo.RemoveMenuItem(existingMenuItem);
                    if (isDeleted)
                    {
                        Console.WriteLine($"The dish {deletedDishName} has been successfully removed from the menu.");
                    }
                    break;
                case "2":
                    Console.WriteLine("The dish was not removed from the menu.");
                    break;
                default:
                    Console.WriteLine("Invalid choice, the dish was not deleted.");
                    break;
            }
            EndSubmenu();
        }

        public List<Menu> ShowCurrentMenu()
        {
            Console.WriteLine("    ___________________________________________________________");
            Console.WriteLine("   | Number |                   Name                   | Price |");
            Console.WriteLine("   |--------|------------------------------------------|-------|");
            List<Menu> fullMenu = _menuRepo.GetAllMenuItems().OrderBy(x => x.Number).ToList();
            foreach (Menu menuItem in fullMenu)
            {
                Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(menuItem.Number.ToString(), "number", 8)}|" +
                    $"{TableMethods.TableMethods.GenerateCell(menuItem.Name, "text", 42)}|" +
                    $"{TableMethods.TableMethods.GenerateCell(menuItem.Price.ToString("F2"), "money", 7)}|");
            }
            Console.WriteLine("   |-----------------------------------------------------------|");
            Console.WriteLine(" ");
            return fullMenu;
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

        public void SeedMenuItems()
        {
            List<string> ingredientsOne = new List<string>()
            {
                "1 box Creamette thin spaghetti",
                "1 jar Ragu spaghetti sauce",
                "Dash of Kraft grated parmesan cheese"
            };
            Menu one = new Menu(900, "Spaghetti a la Collin", "A Wednesday night delicacy. Bon appetit!", ingredientsOne, 3.99);
            _menuRepo.AddMenuItem(one);
            List<string> ingredientsTwo = new List<string>()
            {
                "2 slices of bread",
                "1 block of colby cheese",
                "2 tbsp butter"
            };
            Menu two = new Menu(901, "Grilled Cheese", "Opulence, defined.", ingredientsTwo, 4.49);
            _menuRepo.AddMenuItem(two);

        }
    }
}
