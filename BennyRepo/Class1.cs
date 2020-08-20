using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BennyRepo
{
    class Class1
    {

        public class Ben
        {
            public Ben() { }
            public Ben(string fruit)
            {
                Fruit = fruit;
            }
            public string Fruit { get; set; }
        }



        public class IdBadge
        {
            public IdBadge() { }
            public IdBadge(int badgeID)
            {
                BadgeID = badgeID;
            }
            public int BadgeID { get; set; }
        }

        public class Badge
        {
            public Badge() { }
            public Badge(string doorName, string badgeName)
            {

                DoorName = doorName;
                NameBadge = badgeName;
            }
            public string DoorName { get; set; }
            public string NameBadge { get; set; }
        }

    }

            



}
