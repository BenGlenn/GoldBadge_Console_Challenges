using BennyRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BennyTrials
{
    class BennyPlay
    {
        static void Main(string[] args)
        {
            //DateTime date1 = new DateTime(2020, 11, 25);
            //DateTime date2 = new DateTime(2020, 12, 12);


            //TimeSpan diff1 = date2 - date1;

            //Console.WriteLine(diff1);
            //Console.ReadLine();


            Dictionary<int, string> fruit = new Dictionary<int, string>();
            fruit.Add(3, "grapes");
            fruit.Add(4, "orange");
            fruit.Add(5, "bannana");

            var keyNum = fruit[3];
            Console.WriteLine("{0}",keyNum);




            var thebadges = BenRepo.GetInforBen();

            var badgeDic = thebadges[1];
            Console.WriteLine("{0}",badgeDic.DoorName);
            Console.ReadKey();


            List<string> newList = new List<string>();
            newList.Add("Turd");
            newList.Add("Orange");
            newList.Add("WaterMelon");
            newList.Add("Peach");

            foreach (string s in newList)
            {
                Console.WriteLine(s);
            }

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "apple");
            dictionary.Add(5, "grape");

            if (dictionary.ContainsKey(1))
            {
                string value = dictionary[1];
                Console.WriteLine(value);
                Console.ReadLine();
            }




            //bool isTrue = true;
            //if(diff1 < Datetime.Now)
            //{
            //    isTrue = true;
            //}
            //else
            //{
            //    isTrue = false;
            //}


            //Console.WriteLine(badgeId);
            //Console.ReadLine();

            //List<string> doors = new List<string>();
            //doors.Add("a1");
            //doors.Add("b1");

            //Dictionary<int, List<string>> dictionay = new Dictionary<int, List<string>>();
            //dictionay.Add(1, doors);

            //Console.WriteLine(value);
            //Console.ReadLine();




        }
    }
}
//new Dictionary<int, List<string>> or new Dictionary<int, string[]>
