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
        public BadgeAccess( string badgeName, List<string> accessCodes)
        {

            NameBadge = badgeName;
            AccessCodes = accessCodes;
           
        }
        public List <string> AccessCodes { get; set; }
        public string NameBadge { get; set; }
    }
}

//Casey's Notes to Successfully use the Badge Dictionary!

//you have a dictionary with Key: IdBadge and Value: Badge Access
//Badge Access has a property that is a List<string>
//you will retrieve the Badge Access object/class from the dictionary

//then you will have a BadgeAccess object, you will iterate through the List<string> to display the doors
//you will call the List<string>'s Add method to add doors to the access, and the Remove to remove doors from the access