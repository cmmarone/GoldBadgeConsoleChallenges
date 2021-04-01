using ChallengeTwo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.UI
{
    public class Claims_UI
    {
        private readonly ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            SeedClaims();
            RunMenu();
        }

        public void RunMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("CLAIMS MAIN MENU");
                Console.WriteLine(" ");
                Console.WriteLine("Select a number:\n" +
                    "1: View All Claims\n" +
                    "2: Process Next Claim\n" +
                    "3: Create a New Claim\n" +
                    "4: Exit");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        GetNextClaim();
                        break;
                    case "3":
                        CreateClaim();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please make a selection between 1 and 4\n" + "Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ShowAllClaims()
        {
            BeginSubmenu("VIEW ALL CLAIMS");
            Queue<Claim> allClaims = _claimRepo.GetAllClaims();
            Console.WriteLine("    ___________________________________________________________________________________________________________________");
            Console.WriteLine("   |  Claim ID  |  Type  |                Description                |    Amount    | Date of Incident | Date of Claim |");
            Console.WriteLine("   |------------|--------|-------------------------------------------|--------------|------------------|---------------|");
            foreach (Claim claim in allClaims)
            {
                Console.WriteLine($"   |{TableMethods.TableMethods.GenerateCell(claim.ClaimID.ToString(), "number", 12)}|" +
                     $"{TableMethods.TableMethods.GenerateCell(claim.ClaimType.ToString(), "text", 8)}|" +
                     $"{TableMethods.TableMethods.GenerateCell(claim.Description, "text", 43)}|" +
                     $"{TableMethods.TableMethods.GenerateCell(claim.ClaimAmount.ToString("F2"), "money", 14)}|" +
                     $"{TableMethods.TableMethods.GenerateCell(claim.DateOfIncident.ToString("MM-dd-yy"), "number", 18)}|" +
                     $"{TableMethods.TableMethods.GenerateCell(claim.DateOfClaim.ToString("MM-dd-yy"), "number", 15)}|");
            }
            Console.WriteLine("   |-------------------------------------------------------------------------------------------------------------------|");
            EndSubmenu();
        }

        public void GetNextClaim()
        {
            BeginSubmenu("PROCESS NEXT CLAIM");
            Claim peekedClaim = _claimRepo.PeekNextClaim();
            Console.WriteLine($"Claim ID: {peekedClaim.ClaimID}");
            Console.WriteLine($"Type: {peekedClaim.ClaimType}");
            Console.WriteLine($"Description: {peekedClaim.Description}");
            Console.WriteLine($"Amount: {peekedClaim.ClaimAmount}");
            Console.WriteLine($"Date of Incident: {peekedClaim.DateOfIncident}");
            Console.WriteLine($"Date of Claim: {peekedClaim.DateOfClaim}");
            string isValid;
            if (peekedClaim.IsValid)
            {
                isValid = "Yes";
            }
            else
            {
                isValid = "No";
            }
            Console.WriteLine($"Is Claim Valid?: {isValid}");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Have you finished processing this claim (y/n)?");
            string processChoice = Console.ReadLine();
            if (processChoice == "y")
            {
                Claim dequeuedClaim = _claimRepo.RemoveTopClaim();
                Console.WriteLine($"Claim {dequeuedClaim.ClaimID} has been removed from the list of claims to be processed.");
            }
            EndSubmenu();

        }

        public void CreateClaim()
        {
            BeginSubmenu("CREATE A NEW CLAIM");
            Claim userClaim = new Claim();

            bool keepRunning1 = true;
            while (keepRunning1)
            {
                System.Threading.Thread.Sleep(500);
                Random rng = new Random();
                int generatedClaimID = rng.Next();
                foreach (Claim claim in _claimRepo.GetAllClaims())
                {
                    if (claim.ClaimID == generatedClaimID)
                    {
                        break;
                    }
                    else
                    {
                        userClaim.ClaimID = generatedClaimID;
                        keepRunning1 = false;
                    }
                }
            }

            Console.WriteLine("Choose the claim type:\n" +
                "1: Car\n" +
                "2: Home\n" +
                "3: Theft\n");
            bool keepRunning2 = true;
            while (keepRunning2)
            {
                string claimTypeInput = Console.ReadLine();
                switch (claimTypeInput)
                {
                    case "1":
                        userClaim.ClaimType = ClaimType.Car;
                        keepRunning2 = false;
                        break;
                    case "2":
                        userClaim.ClaimType = ClaimType.Home;
                        keepRunning2 = false;
                        break;
                    case "3":
                        userClaim.ClaimType = ClaimType.Theft;
                        keepRunning2 = false;
                        break;
                    default:
                        Console.WriteLine("Make a selection between 1 and 3.");
                        Console.ReadKey();
                        break;
                }
            }
            Console.WriteLine(" ");

            Console.WriteLine("Enter a description for the claim:");
            userClaim.Description = Console.ReadLine();
            Console.WriteLine(" ");

            Console.WriteLine("What is the claim amount? Do not include a dollar sign.");
            userClaim.ClaimAmount = double.Parse(Console.ReadLine());
            Console.WriteLine(" ");

            Console.WriteLine("Please enter the incident date (mm/dd/yyyy):");
            string incidentDateInput = Console.ReadLine();
            string[] arrayOfIncidentDateInput = incidentDateInput.Split('/');
            int incidentMonth = int.Parse(arrayOfIncidentDateInput[0]);
            int incidentDay = int.Parse(arrayOfIncidentDateInput[1]);
            int incidentYear = int.Parse(arrayOfIncidentDateInput[2]);
            userClaim.DateOfIncident = new DateTime(incidentYear, incidentMonth, incidentDay);
            Console.WriteLine(" ");

            Console.WriteLine("Please enter the claim date (mm/dd/yyyy):");
            string claimDateInput = Console.ReadLine();
            string[] arrayOfClaimDateInput = claimDateInput.Split('/');
            int claimMonth = int.Parse(arrayOfClaimDateInput[0]);
            int claimDay = int.Parse(arrayOfClaimDateInput[1]);
            int claimYear = int.Parse(arrayOfClaimDateInput[2]);
            userClaim.DateOfClaim = new DateTime(claimYear, claimMonth, claimDay);
            Console.WriteLine(" ");

            if ((userClaim.DateOfClaim - userClaim.DateOfIncident).TotalDays <= 30)
            {
                Console.WriteLine("This claim is valid.");
            }
            else
            {
                Console.WriteLine("This claim is not valid, but it will be stored as an unprocessed claim.");
            }

            _claimRepo.AddClaim(userClaim);
            Console.WriteLine(" ");
            Console.WriteLine($"The new claim (ID: {userClaim.ClaimID}) has been added to the list of unprocessed claims.");
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

        public void SeedClaims()
        {
            DateTime dt1a = new DateTime(20, 03, 22);
            DateTime dt1b = new DateTime(20, 03, 25);
            Claim one = new Claim(0020021844, ClaimType.Car, "Hail damage to roof and hood", 1100, dt1a, dt1b);
            _claimRepo.AddClaim(one);

            DateTime dt2a = new DateTime(20, 04, 01);
            DateTime dt2b = new DateTime(20, 04, 14);
            Claim two = new Claim(0701004244, ClaimType.Car, "Single-car accident on W. 86th St", 4500, dt2a, dt2b);
            _claimRepo.AddClaim(two);

            DateTime dt3a = new DateTime(20, 04, 03);
            DateTime dt3b = new DateTime(20, 05, 11);
            Claim three = new Claim(0485925118, ClaimType.Theft, "Prized spoon collection stolen", 520, dt3a, dt3b);
            _claimRepo.AddClaim(three);

            DateTime dt4a = new DateTime(20, 07, 04);
            DateTime dt4b = new DateTime(20, 07, 06);
            Claim four = new Claim(2146281544, ClaimType.Home, "Fireworks set the sunroom on fire", 7200, dt4a, dt4b);
            _claimRepo.AddClaim(four);

            DateTime dt5a = new DateTime(21, 01, 19);
            DateTime dt5b = new DateTime(21, 02, 25);
            Claim five = new Claim(0991759402, ClaimType.Car, "Fender bender in 1150 parking lot", 400, dt5a, dt5b);
            _claimRepo.AddClaim(five);
        }
    }
}
