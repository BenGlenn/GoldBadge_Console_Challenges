using ChallengeTwoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
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
                OpenMenuItem(userInput);
            }
        }

        private string OpenClaimsMenu()
        {
            Console.Clear();
            Console.WriteLine(
                 "Komodo Claims Department.\n" +
                          "What you you like to do? Choose a number from  the items bellow:\n" +
                          "\n" +
                          "1. View All Claims.\n" +
                          "2. Find Claim With ID.\n" +
                          "3. Add A New Claim.\n" +
                          "4. Update Existing Claim.\n" +
                          "5. Delete A Claim.\n" +
                          "6. Exit");
            string userInput = Console.ReadLine();
            return userInput;


        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    DisplayAllClaims();
                    break;
                case "2":
                    DisplayClaimById();
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

        private void DisplayContent(TheClaim claimID)
        {
            Console.WriteLine(
                $"Claim ID: {claimID.ClaimID}\n" +
                $"Claim Type: {claimID.ClaimType}\n" +
                $"Claim Description: {claimID.Description}\n" +
                $"Claim Amount: {claimID.ClaimAmount}\n" +
                $"Date Of Incident: {claimID.DateOfIncident}\n" +
                $"Date of Claim: {claimID.DateOfClaim}\n" +
                $"Is the Claim Still Valid: {claimID.IsValid}");
        }

        private void DisplayClaimById()
        {
            Console.WriteLine("Enter Item ID: ");
            double claimID = double.Parse(Console.ReadLine());
            if (claimID != null)
            {
                DisplayContentById(claimID);

            }
        }

        private void CreateNewClaim()
        {
            Console.Write("Enter Claim Number: ");
            double claimID = double.Parse(Console.ReadLine());
            Console.Write("Select Claim Type: ");
            ClaimType claimType = GetClaimType();
            Console.Write("Enter a description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Claim Amount: ");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the date of the incident: ");
            string incidentDate = Console.ReadLine();
            DateTime dateOfIncident = Convert.ToDateTime(incidentDate);
            Console.Write("Enter the date the claim was filed: ");
            string claimDate = Console.ReadLine();
            DateTime dateOfClaim = Convert.ToDateTime(claimDate);
            bool isValid = IsClaimValid();

            TheClaim newItem = new TheClaim ();
            _claimRepo.AddNewClaim(newItem);
        }


        private bool IsClaimValid()
        {
            Console.WriteLine("Is this Claim Valid? Y/N");
            string isValidSelection = Console.ReadLine();
            if(isValidSelection == "y")
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
            Console.WriteLine("Select a Claim Type:\n" +
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

        private void UpdateExistingClaim(TheClaim claim)
        {
            DisplayClaimById();

            Console.Write("\n" +
                    "Lets update your Claim .\n" +
                    "\n");
            Console.Write("Select Claim Type: ");
            ClaimType claimType = GetClaimType();
            Console.Write("Enter a description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Claim Amount: ");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the date of the incident: ");
            string incidentDate = Console.ReadLine();
            DateTime dateOfIncident = Convert.ToDateTime(incidentDate);
            Console.Write("Enter the date the claim was filed: ");
            string claimDate = Console.ReadLine();
            DateTime dateOfClaim = Convert.ToDateTime(claimDate);
            bool isValid = IsClaimValid(); 
             

                TheClaim updateItem = new TheClaim(claim.ClaimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim, isValid);
                _claimRepo.UpdateExistingClaim(claim.ClaimID, updateItem);


            }

            private void DisplayContentById(double itemID)
            {

                TheClaim searchResult = _claimRepo.GetClaimByID(itemID);

                if (searchResult != null)
                {
                    DisplayContent(searchResult);
                }
                else
                {
                    Console.WriteLine("Invalid Seclection");
                }


            }

       


        }

    }
