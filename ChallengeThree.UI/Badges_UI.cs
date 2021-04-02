using ChallengeThree.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.UI
{
    public class Badges_UI
    {
        BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedBadges();
            RunMenu();
        }

        public void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("KOMODO INSURANCE BADGE MENU");
                Console.WriteLine(" ");
                Console.WriteLine("Select a number:\n" +
                    "1: View All Badges\n" +
                    "2: Create a New Badge\n" +
                    "3: Change Door Access for Badge\n" +
                    "4: Exit");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        ViewAllBadges();
                        break;
                    case "2":
                        CreateNewBadge();
                        break;
                    case "3":
                        ChangeDoorAccess();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Make a selection between 1 and 4\n" + "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ViewAllBadges()
        {
            BeginSubmenu("VIEW ALL BADGES");
            Console.WriteLine("    ______________________________________________________________________________");
            Console.WriteLine("   |  Badge ID  |                           Door Access                           |");
            Console.WriteLine("   |------------|-----------------------------------------------------------------|");
            Dictionary<int, List<string>> allBadges = _badgeRepo.GetAllBadges();
            foreach (KeyValuePair<int, List<string>> badge in allBadges)
            {
                Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(badge.Key.ToString(), "number", 12)}|" +
                    $"{TableMethods.TableMethods.GenerateCell(string.Join(", ", badge.Value), "text", 65)}|");
            }
            Console.WriteLine("   |------------------------------------------------------------------------------|");
            EndSubmenu();
        }

        public void CreateNewBadge()
        {
            BeginSubmenu("CREATE A NEW BADGE");
            Badge newUserBadge = new Badge();
            Console.WriteLine("What is the number on the badge?");
            int badgeNumberInput = int.Parse(Console.ReadLine());
            newUserBadge.BadgeID = badgeNumberInput;
            List<string> userDoorAccessList = new List<string>();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("List a door the badge needs to open:");
                string doorAccessInput = Console.ReadLine().ToUpper();
                userDoorAccessList.Add(doorAccessInput);
                Console.WriteLine("The door was added. Does the badge need access to more doors (y/n)?");
                string userAnswer = Console.ReadLine().ToLower();
                switch (userAnswer)
                {
                    case "y":
                        break;
                    case "n":
                        keepRunning = false;
                        break;
                    default:
                        keepRunning = false;
                        break;
                }
            }
            newUserBadge.DoorAccess = userDoorAccessList;
            _badgeRepo.AddBadge(newUserBadge);
            Console.WriteLine($"The new badge {newUserBadge.BadgeID} was added with access to doors {string.Join(", ", userDoorAccessList)}");
            EndSubmenu();
        }

        public void ChangeDoorAccess()
        {
            BeginSubmenu("CHANGE DOOR ACCESS FOR A BADGE");
            bool keepRunning0 = true;
            while (keepRunning0)
            {
                Console.WriteLine("Enter the badge number you want to change:");
                int badgeNumberInput = int.Parse(Console.ReadLine());
                KeyValuePair<int, List<string>> foundBadge = _badgeRepo.GetBadgeByBadgeID(badgeNumberInput);
                if (foundBadge.Value == null)
                {
                    Console.WriteLine($"Cannot find badge {badgeNumberInput}, check the badge number and try again.");
                    Console.WriteLine(" ");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    string doorAccessStatusString;
                    if (foundBadge.Value.Count == 0)
                    {
                        doorAccessStatusString = "does not have access to any doors";
                    }
                    else if (foundBadge.Value.Count == 1)
                    {
                        doorAccessStatusString = $"has access to door {foundBadge.Value.Single()}";
                    }
                    else
                    {
                        doorAccessStatusString = $"has access to doors {string.Join(", ", foundBadge.Value)}";
                    }
                    Console.WriteLine($"Badge {foundBadge.Key} {doorAccessStatusString}.");
                    Console.WriteLine(" ");
                    Console.WriteLine("How would you like to change access?\n" +
                        "    1:  Add a door\n" +
                        "    2:  Remove a door\n" +
                        "    3:  Remove all doors\n" +
                        "    4:  Don't change door access\n");
                    string userSelection = Console.ReadLine();
                    List<string> expandedDoorAccessList = new List<string>();
                    List<string> shrunkenDoorAccessList = new List<string>();
                    foreach (string door in foundBadge.Value)
                    {
                        shrunkenDoorAccessList.Add(door);
                    }
                    switch (userSelection)
                    {
                        case "1":
                            bool keepRunning1 = true;
                            while (keepRunning1)
                            {
                                Console.WriteLine("Enter a door to add:");
                                string doorAccessInput = Console.ReadLine().ToUpper();
                                expandedDoorAccessList.Add(doorAccessInput);
                                Console.WriteLine("The door was added. Add more doors (y/n)?");
                                string userAnswer = Console.ReadLine().ToLower();
                                switch (userAnswer)
                                {
                                    case "y":
                                        break;
                                    case "n":
                                        keepRunning1 = false;
                                        break;
                                    default:
                                        keepRunning1 = false;
                                        break;
                                }
                            }
                            expandedDoorAccessList.AddRange(foundBadge.Value);
                            _badgeRepo.UpdateDoorAccess(foundBadge.Key, expandedDoorAccessList);
                            Console.WriteLine("The badge has been updated.");
                            EndSubmenu();
                            break;
                        case "2":
                            bool keepRunning2 = true;
                            while (keepRunning2)
                            {
                                Console.WriteLine("Enter a door to remove:");
                                string doorAccessInput = Console.ReadLine().ToUpper();
                                shrunkenDoorAccessList.Remove(doorAccessInput);
                                Console.WriteLine("The door was removed. Remove any more doors (y/n)?");
                                string userAnswer = Console.ReadLine().ToLower();
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

                            _badgeRepo.UpdateDoorAccess(foundBadge.Key, shrunkenDoorAccessList);
                            Console.WriteLine(" ");
                            Console.WriteLine("The badge has been updated.");
                            EndSubmenu();
                            break;
                        case "3":
                            Console.WriteLine(" ");
                            Console.WriteLine("Are you sure you want to remove all doors from this badge (y/n)?");
                            string removeDoorsConfirm = Console.ReadLine().ToLower();
                            switch (removeDoorsConfirm)
                            {
                                case "y":
                                    _badgeRepo.RemoveAllDoorAccess(foundBadge.Key);
                                    break;
                                default:
                                    Console.WriteLine("No doors were removed from the badge.");
                                    EndSubmenu();
                                    break;
                            }
                            break;
                        case "4":
                            EndSubmenu();
                            break;
                        default:
                            EndSubmenu();
                            break;
                    }
                }
                keepRunning0 = false;
            }
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

        public void SeedBadges()
        {
            List<string> doorAccess1 = new List<string>() { "A1", "A2", "A3" };
            Badge badge1 = new Badge(1111111111, doorAccess1);
            _badgeRepo.AddBadge(badge1);

            List<string> doorAccess2 = new List<string>() { "B1", "B2", "B3", "B4" };
            Badge badge2 = new Badge(1111111112, doorAccess2);
            _badgeRepo.AddBadge(badge2);

            List<string> doorAccess3 = new List<string>() { "C1", "C2" };
            Badge badge3 = new Badge(1111111113, doorAccess3);
            _badgeRepo.AddBadge(badge3);

            List<string> doorAccess4 = new List<string>() { "A1", "B2", "C1", "F5", "F6", "F7", "F8" };
            Badge badge4 = new Badge(1111111114, doorAccess4);
            _badgeRepo.AddBadge(badge4);
        }
    }
}
