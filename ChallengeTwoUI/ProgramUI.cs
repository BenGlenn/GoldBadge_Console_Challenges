using ChallengeTwoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoUI
{

    public class ProgramUI
    {
        private bool _isRunning = true;
        private readonly Repo _claimRepo = new Repo();

        public void Start()
        {
            SeedContentList();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = OpenClaimsMenu();
                UserSelection(userInput);
            }
        }

        private string OpenClaimsMenu()
        {
            Console.Clear();
            Console.Write(
                 "\n" +
                 "\n" +
                 "\t\t\t\tKOMODO CLAIMS DEPARTMENT\n" +
                 "\n" +
                          "\t\tWhat would you like to do? Choose a number from the items bellow:\n" +
                          "\n" +
                          "\t\t\t1. View All Claims.\n" +
                          "\t\t\t2. Find A Claim With an ID.\n" +
                          "\t\t\t3. Add A New Claim.\n" +
                          "\t\t\t4. Update Existing Claim.\n" +
                          "\t\t\t5. Delete a Claim.\n" +
                          "\t\t\t6. Exit\n" +
                          "\n");
            string userInput = Console.ReadLine();
            return userInput;


        }

        private void UserSelection(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine($"\n {"Claim ID",-10}  {"Type",-10} {"Description",-30} {"Amount",-10} {"Date of Incident",-25}{"Date of Claim",-25} {"Is Valid",-20}\n");
                    DisplayAllClaims();
                    Console.WriteLine("\n" +
                        "\nSelect the claim ID of the claim you would like to work with.");
                    DisplayContentById();
                  
                    break;
                case "2":
                    DisplayContentById();
                    break;
                case "3":
                    CreateNewClaim();
                    break;
                case "4":
                    UpdateExistingClaim();
                    break;
                case "5":
                    DeleteClaim();
                    break;
                case "6":
                    _isRunning = false;
                    return;
                default:
                    break;
            }
            Console.WriteLine("Press a key to return to the menu...");
            Console.ReadKey();
            return;

        }

        private void DisplayAllClaims()
        {
            List<TheClaim> listOfMenuItems = _claimRepo.GetClaims();

            foreach (TheClaim menuItems in listOfMenuItems)
            {
                DisplayContent(menuItems);
            }
        }

        private void DisplayContent(TheClaim menuItem)
        {
            Console.WriteLine($"{menuItem.ClaimID,-10} {menuItem.ClaimType,-10}  {menuItem.Description,-30} {menuItem.ClaimAmount,-10} {menuItem.DateOfIncident,-25} {menuItem.DateOfClaim,-25} {menuItem.IsValid,-20}");
        }

        private void DisplaySingleClaim(TheClaim menuItem, double itemID)
        {

            TheClaim searchResult = _claimRepo.GetClaimByID(itemID);

            if (searchResult != null)
            {
                Console.WriteLine(
                    $"Claim ID: {menuItem.ClaimID}\n" +
                    $"\n" +
                    $"Claim Type: {menuItem.ClaimType}\n" +
                    $"\n" +
                    $"Claim Description: {menuItem.Description}\n" +
                    $"\n" +
                    $"Claim Amount: {menuItem.ClaimAmount}\n" +
                    $"\n" +
                    $"Date Of Incident: {menuItem.DateOfIncident}\n" +
                    $"\n" +
                    $"Date of Claim: {menuItem.DateOfClaim}\n" +
                    $"\n" +
                    $"Is the Claim Still Valid: {menuItem.IsValid}\n" +
                    $"\n" +
                    $"What would you like to do with this claim?\n" +
                    $"\n" +
                    $"1. Update Claim:\n" +
                    $"2. Delete Claim:\n" +
                    $"3. Find a new Claim:\n" +
                    $"4. Return to main menu.");
                string input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                        Console.Write("\n" +
               "Lets update your Claim .\n" +
               "\n");
                 
                        ClaimType claimType = GetClaimType();
                        Console.Write("Enter a description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter Claim Amount: ");
                        decimal claimAmount = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter the date of the incident (yyyy/mm/dd): ");
                        string incidentDate = Console.ReadLine();
                        DateTime dateOfIncident = Convert.ToDateTime(incidentDate);
                        Console.Write("Enter the date the claim was filed (yyyy/mm/dd): ");
                        string claimDate = Console.ReadLine();
                        DateTime dateOfClaim = Convert.ToDateTime(claimDate);
                        bool isValid = IsClaimValid();


                        TheClaim updateItem = new TheClaim(itemID, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);
                        _claimRepo.UpdateExistingClaim(itemID, updateItem);
                        Console.WriteLine("\n" +
                            "This Claim has been succesfuly updated!\n" +
                            "PRESS ANY KEY TO CONTINUE.");
                        
                        break;

                    case "2":
                        Console.WriteLine("Would you like to DELETE this claim? Y/N");
                        string deleteYesOrNO = Console.ReadLine();


                        if (deleteYesOrNO == "y")
                        {
                            _claimRepo.RemoveClaim(itemID);
                            Console.WriteLine("Your Claim was deleted");
                        }
                        else
                        {
                            Console.WriteLine("Your Claim could not be deleted");
                        }
                        break;
                    case "3":
                        UserSelection("1");
                        break;
                    case "4":
                        OpenClaimsMenu();
                        break;
                    default:
                        break;
                }
            }
        }

        private double DisplayContentById()
        {
            Console.WriteLine("Enter Item ID: ");
            double claimID = double.Parse(Console.ReadLine());
            Console.Clear();
            TheClaim searchResult = _claimRepo.GetClaimByID(claimID);

            if (searchResult != null)
            {
                DisplaySingleClaim(searchResult, claimID);
            }
            return claimID;
        }

        private void CreateNewClaim()
        {
            Console.Write("Enter Claim Number: ");
            double claimID = double.Parse(Console.ReadLine());
            ClaimType claimType = GetClaimType();
            Console.Write("Enter a description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Claim Amount: ");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the date of the incident (yyyy/mm/dd): ");
            string incidentDate = Console.ReadLine();
            DateTime dateOfIncident = Convert.ToDateTime(incidentDate);
            Console.Write("Enter the date the claim was filed (yyyy/mm/dd): ");
            string claimDate = Console.ReadLine();
            DateTime dateOfClaim = Convert.ToDateTime(claimDate);
            bool isValid = IsClaimValid();

            TheClaim newItem = new TheClaim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);
            _claimRepo.AddNewClaim(newItem);
        }

        private void UpdateExistingClaim()
        {
            double claimID = DisplayContentById();

            Console.Write("\n" +
                    "Lets update your Claim .\n" +
                    "\n");
            ClaimType claimType = GetClaimType();
            Console.Write("Enter a description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Claim Amount: ");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the date of the incident (yyyy/mm/dd): ");
            string incidentDate = Console.ReadLine();
            DateTime dateOfIncident = Convert.ToDateTime(incidentDate);
            Console.Write("Enter the date the claim was filed (yyyy/mm/dd): ");
            string claimDate = Console.ReadLine();
            DateTime dateOfClaim = Convert.ToDateTime(claimDate);
            bool isValid = IsClaimValid();


            TheClaim updateItem = new TheClaim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);
            _claimRepo.UpdateExistingClaim(claimID, updateItem);
            Console.WriteLine("\n" +
                "This Claim has been succesfuly updated!\n" +
                        "PRESS ANY KEY TO CONTINUE.");
        }

        private bool IsClaimValid()
        {
            Console.WriteLine("Is this Claim Valid? Y/N");
            string isValidSelection = Console.ReadLine();
            if (isValidSelection == "y")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private ClaimType GetClaimType()
        {
            Console.WriteLine("Select a Claim Type. Choose 1, 2 or 3:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft.");

            string claimType = Console.ReadLine();

            while (true)
            {
                switch (claimType)
                {
                    case "1":
                        return ClaimType.Car;
                    case "2":
                        return ClaimType.Home;
                    case "3":
                        return ClaimType.Theft;
                }
                Console.WriteLine("Invalid Selection.");
            }
        }

        private void DeleteClaim()
        {
            
            double claimID = DisplayContentById();
            Console.WriteLine("Would you like to delete this claim? Y/N");
            string deleteYesOrNO = Console.ReadLine();


            if (deleteYesOrNO == "y")
            {
                _claimRepo.RemoveClaim(claimID);
                Console.WriteLine("Your Claim was deleted");
            }
            else
            {
                Console.WriteLine("Your Claim was not be deleted");
            }
        }

        private void SeedContentList()
        {
            DateTime dateTimeOne = new DateTime(1998, 12, 8);
            DateTime dateTimeTwo = new DateTime(1980, 12, 29);
            DateTime dateTimeThree = new DateTime(2020, 11, 8);
            DateTime dateTimeFour = new DateTime(2020, 12, 8);
            DateTime dateTimeFive = new DateTime(2019, 10, 8);
            DateTime dateTimeSix = new DateTime(2019, 11, 1);

            TheClaim claimNumOne = new TheClaim(1, ClaimType.Car, "Car accident on gravel road", 4400, dateTimeOne, dateTimeTwo, false);
            TheClaim claimNumTwo = new TheClaim(2, ClaimType.Home, "My She Shed Burt Down", 10, dateTimeThree, dateTimeFour, true);
            TheClaim claimNumThree = new TheClaim(3, ClaimType.Theft, "Someone stole my DOG!", 200, dateTimeFive, dateTimeSix, true);

            _claimRepo.AddNewClaim(claimNumOne);
            _claimRepo.AddNewClaim(claimNumTwo);
            _claimRepo.AddNewClaim(claimNumThree);

        }




    }

}
