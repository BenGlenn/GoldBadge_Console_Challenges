using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class Badge
    {
        public Badge() { }
        public Badge(int badgeID, string doorName, string badgeName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
            NameBadge = badgeName;
        }

        public int BadgeID { get; set; }
        public string DoorName { get; set; }
        public string NameBadge { get; set; }
    }
}
