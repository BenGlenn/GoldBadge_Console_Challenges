using ChallengeThreeRepo;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
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

            SeedContent();
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
                 "\t\t\t\tHELLO SECURITY ADMIN\n" +
                 "\n" +
                          "\t\tWhat would you like to do? Choose a number from the items bellow:\n" +
                          "\n" +
                          "\t\t\t1. ADD A BADGE.\n" +
                          "\t\t\t2. EDIT A BADGE.\n" +
                          "\t\t\t3. LIST ALL BADGES.\n" +
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
                    AddABadge();
                    break;
                case "2":
                    break;
                case "3":
                    break;
            }
            Console.WriteLine("Press a key to return to the menu...");
            Console.ReadKey();
            return;
        }

        public void AddABadge()
        {

            Console.Write("Lets start by making a new ID Badge Number. Please Note ID Badges can only contain numbers:\n" +
                "\n" +
                "Please Enter Your New ID Badge NUmber: ");

            int newIdBadgeNumber = int.Parse(Console.ReadLine());

            IdBadge addingNewID = new IdBadge(newIdBadgeNumber);
            _accessRepo.AddNewBadgeId(addingNewID);

            Console.WriteLine("Great! Your New ID Badge has been created. Now you can give you new ID Badge a name as well as give it access to multiple doors.\n" +
                "\n" +
                "Add a Name to you ID Badge:");

            string name = Console.ReadLine();
            Console.WriteLine("Great! Your Name has been added. Now lets give this badge some access.\n" +
                "\n" +
                "Enter in your first access door");
            List<string> listItem = new List<string>();
            listItem.Add(Console.ReadLine());

            BadgeAccess accessAdding = new BadgeAccess(name, listItem);
            _accessRepo.AddNewBadgeAccess(accessAdding);

            Console.WriteLine("Would you like to enter another Access Door? (y/n)");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    Console.WriteLine("Enter in your next access door");
                    List<string> listNextItem = new List<string>();
                    listItem.Add(Console.ReadLine());

                    BadgeAccess accessAdding2 = new BadgeAccess(name, listNextItem);
                    _accessRepo.AddNewBadgeAccess(accessAdding2);
                    break;
                case "n":
                    Dictionary<IdBadge, BadgeAccess> addingToDic = new Dictionary<IdBadge, BadgeAccess>();
                    addingToDic.Add(addingNewID, accessAdding);
                    //addingToDic.Add(addingNewID, accessAdding2);


                    Console.WriteLine("You have successfully added a new ID Badge with Access\n" +
                  "PRESS ANY KEY TO CONTINUE:  ");
                    Console.ReadKey();
                    BadgeWelcomMenu();
                    break;
                default:
                    break;
            }


            if (userInput == "y")
            {
                Console.WriteLine("Enter in your next access door");
                List<string> listItem2 = new List<string>();
                listItem.Add(Console.ReadLine());

                BadgeAccess accessAdding2 = new BadgeAccess(name, listItem2);
                _accessRepo.AddNewBadgeAccess(accessAdding2);
            }
            else
            {
                Console.WriteLine("You have successfully added a new ID Badge with Access\n" +
                    "PRESS ANY KEY TO CONTINUE:  ");
                Console.ReadKey();
                BadgeWelcomMenu();

            }









        }

        public void EditABadge()
        {

        }

        public void SeedContent()
        {

        }
    }
}
