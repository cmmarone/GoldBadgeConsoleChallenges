using ChallengeFour.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour.UI
{
    public class Outings_UI
    {
        private readonly OutingRepository _outingRepo = new OutingRepository();
        public void Run()
        {
            SeedOutings();
            RunMenu();
        }
        public void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("COMPANY OUTINGS MAIN MENU");
                Console.WriteLine(" ");
                Console.WriteLine("Select a number:\n" +
                    "1: Add Outing to Directory\n" +
                    "2: View Outings by Type\n" +
                    "3: View All Outings\n" +
                    "4: Exit");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        CreateOuting();
                        break;
                    case "2":
                        CostsSubmenu();
                        break;
                    case "3":
                        ViewOutingsSubmenu();
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

        public void CostsSubmenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                BeginSubmenu("VIEW OUTING COSTS");
                Console.WriteLine("Select a number:\n" +
                    "1: View Current Year Outing Costs By Event Type\n" +
                    "2: View All Years Outing Costs By Event Type\n" +
                    "3: Return to Main Menu");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        ShowCostsByTypeYTD();
                        break;
                    case "2":
                        ShowAllCostsByType();
                        break;
                    case "3":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5\n" + "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ViewOutingsSubmenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                BeginSubmenu("VIEW OUTINGS");
                Console.WriteLine("Select a number:\n" +
                    "1: View Current Year's Outings Only\n" +
                    "2: View All Outings\n" +
                    "3: Return to Main Menu");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        ShowCurrentYearOutings();
                        break;
                    case "2":
                        ShowAllOutings();
                        break;
                    case "3":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5\n" + "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void CreateOuting()
        {
            BeginSubmenu("CREATE A NEW OUTING");
            Outing userOuting = new Outing();
            Console.WriteLine("Please enter the outing date (mm/dd/yyyy):");
            string dateInput = Console.ReadLine();
            string[] arrayOfDateInput = dateInput.Split('/');
            int month = int.Parse(arrayOfDateInput[0]);
            int day = int.Parse(arrayOfDateInput[1]);
            int year = int.Parse(arrayOfDateInput[2]);
            userOuting.Date = new DateTime(year, month, day);
            Console.WriteLine(" ");
            Console.WriteLine("Choose the event type:\n" +
                "1:  Golf\n" +
                "2:  Bowling\n" +
                "3: Amusement Park\n" +
                "4: Concert\n");
            string eventTypeInput = Console.ReadLine();
            switch (eventTypeInput)
            {
                case "1":
                    userOuting.EventType = EventType.Golf;
                    break;
                case "2":
                    userOuting.EventType = EventType.Bowling;
                    break;
                case "3":
                    userOuting.EventType = EventType.AmusementPark;
                    break;
                case "4":
                    userOuting.EventType = EventType.Concert;
                    break;
                default:
                    Console.WriteLine("Make a selection between 1 and 4.");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine(" ");
            Console.WriteLine("How many people attended the outing?");
            int attendanceInput = int.Parse(Console.ReadLine());
            userOuting.Attendance = attendanceInput;
            Console.WriteLine(" ");
            Console.WriteLine("What was the total cost of the outing? Do not include a dollar sign.");
            double totalCostInput = int.Parse(Console.ReadLine());
            userOuting.TotalCost = totalCostInput;

            _outingRepo.AddOuting(userOuting);
            Console.WriteLine(" ");
            Console.WriteLine("The new outing has been added to the directory!");
            EndSubmenu();
        }

        public void ShowCostsByTypeYTD()
        {
            //extract method and put in repo - see about combining with alloutings by type below
            List<Outing> golfOutingsYTD = _outingRepo.GetOutingsByEventTypeYTD(EventType.Golf);
            double golfCostsTotal = 0;
            int golfOccurrences = 0;
            foreach (Outing outing in golfOutingsYTD)
            {
                golfOccurrences = golfOccurrences + 1;
                golfCostsTotal = golfCostsTotal + outing.TotalCost;
            }
            List<Outing> bowlingOutingsYTD = _outingRepo.GetOutingsByEventTypeYTD(EventType.Bowling);
            double bowlingCostsTotal = 0;
            int bowlingOccurrences = 0;
            foreach (Outing outing in bowlingOutingsYTD)
            {
                bowlingOccurrences = bowlingOccurrences + 1;
                bowlingCostsTotal = bowlingCostsTotal + outing.TotalCost;
            }
            List<Outing> amusementParkOutingsYTD = _outingRepo.GetOutingsByEventTypeYTD(EventType.AmusementPark);
            double amusementParkCostsTotal = 0;
            int amusementParkOccurrences = 0;
            foreach (Outing outing in amusementParkOutingsYTD)
            {
                amusementParkOccurrences = amusementParkOccurrences + 1;
                amusementParkCostsTotal = amusementParkCostsTotal + outing.TotalCost;
            }
            List<Outing> concertOutingsYTD = _outingRepo.GetOutingsByEventTypeYTD(EventType.Concert);
            double concertCostsTotal = 0;
            int concertOccurrences = 0;
            foreach (Outing outing in concertOutingsYTD)
            {
                concertOccurrences = concertOccurrences + 1;
                concertCostsTotal = concertCostsTotal + outing.TotalCost;
            }
            //end extract method
      
            BeginSubmenu("TOTAL COSTS BY CATEGORY, CURRENT YEAR ONLY");
            Console.WriteLine("    _________________________________________");
            Console.WriteLine("   |   Event Type   | Count |    YTD Cost    |");
            Console.WriteLine("   |----------------|-------|----------------|");
            Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(EventType.Golf.ToString(), "text", 16)}|" +
                $"{TableMethods.TableMethods.GenerateCell(golfOccurrences.ToString(), "number", 7)}|" +
                $"{TableMethods.TableMethods.GenerateCell(golfCostsTotal.ToString("F2"), "money", 16)}|");
            Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(EventType.Bowling.ToString(), "text", 16)}|" +
                $"{TableMethods.TableMethods.GenerateCell(bowlingOccurrences.ToString(), "number", 7)}|" +
                $"{TableMethods.TableMethods.GenerateCell(bowlingCostsTotal.ToString("F2"), "money", 16)}|");
            Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(EventType.AmusementPark.ToString(), "text", 16)}|" +
                $"{TableMethods.TableMethods.GenerateCell(amusementParkOccurrences.ToString(), "number", 7)}|" +
                $"{TableMethods.TableMethods.GenerateCell(amusementParkCostsTotal.ToString("F2"), "money", 16)}|");
            Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(EventType.Concert.ToString(), "text", 16)}|" +
                $"{TableMethods.TableMethods.GenerateCell(concertOccurrences.ToString(), "number", 7)}|" +
                $"{TableMethods.TableMethods.GenerateCell(concertCostsTotal.ToString("F2"), "money", 16)}|");
            Console.WriteLine("   |-----------------------------------------|");
            EndSubmenu();
        }

        public void ShowAllCostsByType()
        {
            List<Outing> golfOutings = _outingRepo.GetAllOutingsByEventType(EventType.Golf);
            double golfCostsTotal = 0;
            int golfOccurrences = 0;
            foreach (Outing outing in golfOutings)
            {
                golfOccurrences = golfOccurrences + 1;
                golfCostsTotal = golfCostsTotal + outing.TotalCost;
            }
            List<Outing> bowlingOutings = _outingRepo.GetAllOutingsByEventType(EventType.Bowling);
            double bowlingCostsTotal = 0;
            int bowlingOccurrences = 0;
            foreach (Outing outing in bowlingOutings)
            {
                bowlingOccurrences = bowlingOccurrences + 1;
                bowlingCostsTotal = bowlingCostsTotal + outing.TotalCost;
            }
            List<Outing> amusementParkOutings = _outingRepo.GetAllOutingsByEventType(EventType.AmusementPark);
            double amusementParkCostsTotal = 0;
            int amusementParkOccurrences = 0;
            foreach (Outing outing in amusementParkOutings)
            {
                amusementParkOccurrences = amusementParkOccurrences + 1;
                amusementParkCostsTotal = amusementParkCostsTotal + outing.TotalCost;
            }
            List<Outing> concertOutings = _outingRepo.GetAllOutingsByEventType(EventType.Concert);
            double concertCostsTotal = 0;
            int concertOccurrences = 0;
            foreach (Outing outing in concertOutings)
            {
                concertOccurrences = concertOccurrences + 1;
                concertCostsTotal = concertCostsTotal + outing.TotalCost;
            }

            BeginSubmenu("TOTAL COSTS BY CATEGORY, ALL YEARS");
            Console.WriteLine("    _________________________________________");
            Console.WriteLine("   |   Event Type   | Count |    YTD Cost    |");
            Console.WriteLine("   |----------------|-------|----------------|");
            Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(EventType.Golf.ToString(), "text", 16)}|" +
                $"{TableMethods.TableMethods.GenerateCell(golfOccurrences.ToString(), "number", 7)}|" +
                $"{TableMethods.TableMethods.GenerateCell(golfCostsTotal.ToString("F2"), "money", 16)}|");
            Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(EventType.Bowling.ToString(), "text", 16)}|" +
                $"{TableMethods.TableMethods.GenerateCell(bowlingOccurrences.ToString(), "number", 7)}|" +
                $"{TableMethods.TableMethods.GenerateCell(bowlingCostsTotal.ToString("F2"), "money", 16)}|");
            Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(EventType.AmusementPark.ToString(), "text", 16)}|" +
                $"{TableMethods.TableMethods.GenerateCell(amusementParkOccurrences.ToString(), "number", 7)}|" +
                $"{TableMethods.TableMethods.GenerateCell(amusementParkCostsTotal.ToString("F2"), "money", 16)}|");
            Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(EventType.Concert.ToString(), "text", 16)}|" +
                $"{TableMethods.TableMethods.GenerateCell(concertOccurrences.ToString(), "number", 7)}|" +
                $"{TableMethods.TableMethods.GenerateCell(concertCostsTotal.ToString("F2"), "money", 16)}|");
            Console.WriteLine("   |-----------------------------------------|");
            EndSubmenu();
        }

        public void ShowCurrentYearOutings()
        {
            BeginSubmenu("ALL OUTINGS THIS YEAR");
            Console.WriteLine("    __________________________________________________________________________");
            Console.WriteLine("   |   Date   |   Event Type   | Attendees | Cost Per Person |   Total Cost   |");
            Console.WriteLine("   |----------|----------------|-----------|-----------------|----------------|");
            List<Outing> currentYearOutings = _outingRepo.GetOutingsYTD().OrderBy(x => x.Date).ToList();
            foreach (Outing outing in currentYearOutings)
            {
                Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(outing.Date.ToString("MM-dd-yy"), "number", 10)}|" +
                    $"{TableMethods.TableMethods.GenerateCell(outing.EventType.ToString(), "text", 16)}|" +
                    $"{TableMethods.TableMethods.GenerateCell(outing.Attendance.ToString(), "number", 11)}|" +
                    $"{TableMethods.TableMethods.GenerateCell(outing.HeadCost.ToString("F2"), "money", 17)}|" +
                    $"{TableMethods.TableMethods.GenerateCell(outing.TotalCost.ToString("F2"), "money", 16)}|");
            }
            Console.WriteLine("   |--------------------------------------------------------------------------|");
            double grandTotalYTD = 0;
            foreach (Outing outing in currentYearOutings)
            {
                grandTotalYTD = grandTotalYTD + outing.TotalCost;
            }
            Console.WriteLine("                             " +
                $"TOTAL COST OF ALL OUTINGS (YTD): {TableMethods.TableMethods.GenerateCell(grandTotalYTD.ToString("F2"), "money", 16)}");
            EndSubmenu();
        }

        public void ShowAllOutings()
        {
            BeginSubmenu("ALL OUTINGS");
            Console.WriteLine("    __________________________________________________________________________");
            Console.WriteLine("   |   Date   |   Event Type   | Attendees | Cost Per Person |   Total Cost   |");
            Console.WriteLine("   |----------|----------------|-----------|-----------------|----------------|");
            List<Outing> allOutings = _outingRepo.GetAllOutings().OrderBy(x => x.Date).ToList();
            foreach (Outing outing in allOutings)
            {
                Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(outing.Date.ToString("MM-dd-yy"), "number", 10)}|" +
                                   $"{TableMethods.TableMethods.GenerateCell(outing.EventType.ToString(), "text", 16)}|" +
                                   $"{TableMethods.TableMethods.GenerateCell(outing.Attendance.ToString(), "number", 11)}|" +
                                   $"{TableMethods.TableMethods.GenerateCell(outing.HeadCost.ToString("F2"), "money", 17)}|" +
                                   $"{TableMethods.TableMethods.GenerateCell(outing.TotalCost.ToString("F2"), "money", 16)}|");
            }
            Console.WriteLine("   |--------------------------------------------------------------------------|");
            double grandTotal = 0;
            foreach (Outing outing in allOutings)
            {
                grandTotal = grandTotal + outing.TotalCost;
            }
            Console.WriteLine("                                   " +
                $"TOTAL COST OF ALL OUTINGS: {TableMethods.TableMethods.GenerateCell(grandTotal.ToString("F2"), "money", 16)}");
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

        public void SeedOutings()
        {
            DateTime dt1 = new DateTime(2019, 4, 2);
            Outing one = new Outing(dt1, EventType.Bowling, 9, 430.14);
            DateTime dt2 = new DateTime(2019, 5, 1);
            Outing two = new Outing(dt2, EventType.Concert, 4, 559.81);
            DateTime dt3 = new DateTime(2019, 5, 14);
            Outing three = new Outing(dt3, EventType.AmusementPark, 8, 947.32);
            DateTime dt4 = new DateTime(2019, 6, 9);
            Outing four = new Outing(dt4, EventType.Golf, 3, 810.02);
            DateTime dt5 = new DateTime(2019, 6, 21);
            Outing five = new Outing(dt5, EventType.Bowling, 4, 210.94);
            DateTime dt6 = new DateTime(2019, 7, 14);
            Outing six = new Outing(dt6, EventType.Concert, 12, 1562.40);
            DateTime dt7 = new DateTime(2019, 11, 13);
            Outing seven = new Outing(dt7, EventType.AmusementPark, 2, 243.12);
            DateTime dt8 = new DateTime(2020, 2, 15);
            Outing eight = new Outing(dt8, EventType.Golf, 9, 1813.72);
            DateTime dt9 = new DateTime(2020, 3, 14);
            Outing nine = new Outing(dt9, EventType.Golf, 6, 1480.68);
            DateTime dt10 = new DateTime(2021, 1, 25);
            Outing ten = new Outing(dt10, EventType.Bowling, 2, 94.22);
            DateTime dt11 = new DateTime(2021, 2, 21);
            Outing eleven = new Outing(dt11, EventType.Golf, 3, 519.72);
            DateTime dt12 = new DateTime(2021, 3, 8);
            Outing twelve = new Outing(dt12, EventType.Golf, 11, 1539.39);

            _outingRepo.AddOuting(one);
            _outingRepo.AddOuting(two);
            _outingRepo.AddOuting(three);
            _outingRepo.AddOuting(four);
            _outingRepo.AddOuting(five);
            _outingRepo.AddOuting(six);
            _outingRepo.AddOuting(seven);
            _outingRepo.AddOuting(eight);
            _outingRepo.AddOuting(nine);
            _outingRepo.AddOuting(ten);
            _outingRepo.AddOuting(eleven);
            _outingRepo.AddOuting(twelve);
        }
    }
}
