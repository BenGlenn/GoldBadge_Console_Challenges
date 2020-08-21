using ChallengeThreeRepo;
using Microsoft.SqlServer.Server;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeUI
{
    class ProgramUI
    {
        private bool _isRunning = true;
        private readonly Repo _accessRepo = new Repo();

        public void Start()
        {

            SeedContentOne();
            SeedContentTwo();
            SeedContentThree();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = BadgeWelcomMenu();
                UserSelection(userInput);
            }
        }

        private string BadgeWelcomMenu()
        {
            Console.Clear();
            Console.Write(
                 "\n" +
                 "\n" +
                 "\tHELLO SECURITY ADMINISTRATOR\n" +
                 "\tYOU HAVE A LEVEL 5 TOP SECERTY CLEARNCE" +
                 "\n" +
                 "\n" +
                          "What would you like to do?\n" +
                          "Choose a number from the items below:\n" +
                          "\n" +
                          "1. ADD A BADGE.\n" +
                          "2. LIST ALL BADGES.\n" +
                          "\n");
            string userInput = Console.ReadLine();
            return userInput;
        }

        private void UserSelection(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    AddABadge();
                    break;
                case "2":
                    DisplayAllBadgeInfo();
                    break;

            }
            Console.WriteLine("\n" +
                "Press a key to return to the menu...");
            Console.ReadKey();
            return;
        }



        public void DisplayAllBadgeInfo()
        {

            // I Want to pull up all the ID BADGES (KEY) alnog with all the NAMES and DOORS(KEY) How do I write the syntax for this//
            Console.Clear();
            Dictionary<IdBadge, BadgeAccess> seeAllBadges = _accessRepo.SeeAllBadges();

            foreach (KeyValuePair<IdBadge, BadgeAccess> badgeItem in seeAllBadges) //this foreach iterates through the dictionary
            {
                Console.Write($"\n" +
                    $"Badge ID: {badgeItem.Key.BadgeID}\t");
                Console.Write($"Name/Access: {badgeItem.Value.NameBadge}\t");
                foreach (string door in badgeItem.Value.AccessCodes)
                {
                    Console.Write(door + " ");
                }

            }

            EditABadge();
        }

        public void SeeSingleBadge()
        {

            Console.Write("\n" +
                "\n" +
                "Enter The Badge ID Number You'd Like To Work With: ");
            int badgeId = int.Parse(Console.ReadLine());
            Console.Clear();
            Dictionary<IdBadge, BadgeAccess> oneBadge = _accessRepo.GetSingleBadge();

            foreach (KeyValuePair<IdBadge, BadgeAccess> badgeItem in oneBadge) //this foreach iterates through the dictionary
            {
                if (badgeItem.Key.BadgeID == badgeId)
                {
                    Console.Write($"\n" +
                   $"Badge ID: {badgeItem.Key.BadgeID}\t");
                    Console.Write($"Name/Access: {badgeItem.Value.NameBadge}\t");
                    foreach (string door in badgeItem.Value.AccessCodes)
                    {
                        Console.Write(door + " ");
                    }

                }

            }
            EditABadge();
        }

        public void AddABadge()
        {
            Console.Clear();
            Console.Write("\n" +
                "Lets start by making a new ID Badge Number.\n" +
                "Please Note ID Badges can only contain numbers:\n" +
                "\n" +
                "\n" +
                "Please Enter Your New ID Badge NUmber: ");

            int newIdBadgeNumber = int.Parse(Console.ReadLine());
            // IdBadge is being instantiated, we will use it in our KeyValuePair later in this method
            IdBadge addingNewID = new IdBadge(newIdBadgeNumber);
            //_accessRepo.AddNewBadgeId(addingNewID);    CW- we don't need this

            Console.WriteLine("Great! Your New ID Badge has been created. Now you can give your new ID Badge a name as well as give it access to multiple doors.\n" +
                "\n" +
                "Add a Name to you ID Badge:");
            //storing the name in a string, to be assigned to our BadgeAccess's BadgeName property later
            string name = Console.ReadLine();
            Console.WriteLine("Great! Your Name has been added. Now lets give this badge some access.\n" +
                "\n" +
                "Enter in your first access door");

            List<string> listOfDoors = new List<string>();
            //now we need to start a while loop, this loop will ask the user what door they would like to add, it will add it, it will ask the user if they would like to add another door, it will break the while loop if they do not, or it will continue it if they do.
            bool doorAdding = true;
            while (doorAdding == true)
            {

                string doorToAdd = Console.ReadLine();
                listOfDoors.Add(doorToAdd);


                Console.WriteLine("Would you like to enter another Access Door? (y/n)");
                string continueOrBreak = Console.ReadLine().ToLower();
                switch (continueOrBreak)
                {
                    case "y":
                        Console.Clear();
                        Console.WriteLine("Enter in your next access door");
                        break;
                    case "n":
                        // Add Crap to Dictionary
                        BadgeAccess accessAdding = new BadgeAccess(name, listOfDoors);
                        _accessRepo.AddToDictionary(addingNewID, accessAdding);

                        Console.WriteLine("You have successfully added a new ID Badge with Access\n" +
                      "PRESS ANY KEY TO CONTINUE:  ");
                        Console.ReadKey();
                        doorAdding = false;
                        RunMenu();
                        break;
                    default:
                        break;
                }
            }
        }
        // This code does not work at all... I re-factored it all night and was up a 5 to try again... I clearly do not know how to
        // work with dictionays and lists... I know what I want to do, but I will say that in this proccess of trying EVERYTHING to make an MVP
        // I may have confused my self a whole lot more... POOP!



        public void EditABadge()
        { //This method is not working.

            Console.Write("\n" +
              "\n" +
              "Enter The Badge ID Number You'd Like To Work With: ");
            int oldBadgeId = int.Parse(Console.ReadLine());
            _accessRepo.RemoveBadge(oldBadgeId); //This Didn't Work//
            Console.WriteLine("For SECRITY PURPOSES please re-enter the Badge Id you would like to work with.");
            int updatedId = int.Parse(Console.ReadLine());

            IdBadge addingOldIdWithNewAccessCodes = new IdBadge(updatedId);
            Console.Clear();
            Dictionary<IdBadge, BadgeAccess> oneBadge = _accessRepo.GetSingleBadge();

            foreach (KeyValuePair<IdBadge, BadgeAccess> badgeItem in oneBadge) //this foreach iterates through the dictionary
            {
                if (badgeItem.Key.BadgeID == updatedId)
                {
                    Console.Write($"\n" +
                   $"Badge ID: {badgeItem.Key.BadgeID}\t");
                    Console.Write($"Name/Access: {badgeItem.Value.NameBadge}\t");
                    foreach (string door in badgeItem.Value.AccessCodes)
                    {
                        Console.Write(door + " ");
                    }

                }

            }

            Console.WriteLine("\n" +
                "\n" +
                "Choose from the numbers below.\n" +
                        "1. Add/Remove Access Code\n" +
                        "2. Remove An Entire Badge");
            string userInput = Console.ReadLine();
            foreach (KeyValuePair<IdBadge, BadgeAccess> badgeItem in oneBadge) //this foreach iterates through the dictionary
            {
                if (badgeItem.Key.BadgeID == updatedId)
                {
                    if (userInput == "1")
                    {
                        bool doorAdding = true;
                        while (doorAdding == true)
                        {
                            Console.WriteLine("\tPLEASE NOTE:\n" +
                                "To Update This ID Badge You will need to add ALL previos and new the Access Codes\n" +
                                "you want this badge to have. If you would like to remove an\n" +
                                "excisting Access Code, DO NOT add it into the update.");
                            Console.WriteLine("Enter Your First Access Code?");
                            List<string> listOfDoors = new List<string>();
                            string doorToAdd = Console.ReadLine();
                            listOfDoors.Add(doorToAdd);


                            Console.WriteLine("Would you like to enter another Access Code? (y/n)");
                            string continueOrBreak = Console.ReadLine().ToLower();
                            switch (continueOrBreak)
                            {
                                case "y":
                                    Console.Clear();
                                    Console.WriteLine("Enter in your next Access Code");
                                    break;
                                case "n":
                            
                                    BadgeAccess accessAdding = new BadgeAccess(badgeItem.Value.NameBadge, listOfDoors);
                                    _accessRepo.AddToDictionary(addingOldIdWithNewAccessCodes, accessAdding);
                                    Console.WriteLine("You have successfully updated this ID Badge\n" +
                                  "PRESS ANY KEY TO CONTINUE:  ");
                                    Console.ReadKey();
                                    doorAdding = false;
                                    RunMenu();
                                    break;
                                default:
                                    break;
                            }

                        }

                    }
                    else
                    {
                        Console.WriteLine("For SECRITY PURPOSES please re-enter the Badge Id you would like to DELETE");
                        int removeBadge = int.Parse(Console.ReadLine());
                        _accessRepo.RemoveBadge(removeBadge); // This didn't work //
                        Console.WriteLine("Your Badge has been DELETED");
                        Console.WriteLine("\n" +
                            "PRESS ANY KEY TO CONTINUE");
                        Console.ReadKey();
                        RunMenu();



                    }
                }
            }

        }
        public void SeedContentOne()
        {
            int newIdBadgeNumber = 8;

            IdBadge addingNewID = new IdBadge(newIdBadgeNumber);
            string name = "Betty";

            List<string> listOfDoors = new List<string>();

            string doorToAdd = "A7";
            listOfDoors.Add(doorToAdd);
            string anotherDoor = "A4";
            listOfDoors.Add(anotherDoor);

            BadgeAccess accessAdding = new BadgeAccess(name, listOfDoors);
            _accessRepo.AddToDictionary(addingNewID, accessAdding);

        }

        public void SeedContentTwo()
        {
            int newIdBadgeNumber2 = 9;

            IdBadge addingNewID2 = new IdBadge(newIdBadgeNumber2);
            string name = "Bob";

            List<string> listOfDoors2 = new List<string>();

            string doorToAdd2 = "A7";
            listOfDoors2.Add(doorToAdd2);
            string anotherDoor2 = "A3";
            listOfDoors2.Add(anotherDoor2);
            string doorThree2 = "A8";
            listOfDoors2.Add(doorThree2);

            BadgeAccess accessAdding2 = new BadgeAccess(name, listOfDoors2);
            _accessRepo.AddToDictionary(addingNewID2, accessAdding2);
        }

        public void SeedContentThree()
        {
            int newIdBadgeNumber = 10;

            IdBadge addingNewID3 = new IdBadge(newIdBadgeNumber);
            string name = "Benny";

            List<string> listOfDoors = new List<string>();

            string doorToAdd = "A7";
            listOfDoors.Add(doorToAdd);
            string anotherDoor = "A3";
            listOfDoors.Add(anotherDoor);
            string doorThree = "A8";
            listOfDoors.Add(doorThree);
            string doorFour = "A10";
            listOfDoors.Add(doorFour);

            BadgeAccess accessAdding = new BadgeAccess(name, listOfDoors);
            _accessRepo.AddToDictionary(addingNewID3, accessAdding);
        }

    }
}
