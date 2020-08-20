using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class IdBadge
    {
        public IdBadge() { }
        public IdBadge(int badgeID)
        {
            BadgeID = badgeID;
        }
        public int BadgeID { get; set; }
    }

        



    public class BadgeAccess
    {

        public BadgeAccess() { }
        public BadgeAccess( string badgeName, List<string> doorName)
        {

            NameBadge = badgeName;
            DoorName = doorName;
           
        }
        public List <string> DoorName { get; set; }
        public string NameBadge { get; set; }



    }
}
