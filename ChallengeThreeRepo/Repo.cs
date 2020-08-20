using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class Repo

    {
        // Add New ID
        public List<IdBadge> _idBadge = new List<IdBadge>();

        public void AddNewBadgeId(IdBadge badgeID)
        {
            _idBadge.Add(badgeID);
        }

        // Add New Door
        public List<BadgeAccess> _badgeAccesses = new List<BadgeAccess>();

        public void AddNewBadgeAccess(BadgeAccess doors)
        {
            _badgeAccesses.Add(doors);
        }

        //See all Badges

        public Dictionary<IdBadge, BadgeAccess> _badgeDic = new Dictionary<IdBadge, BadgeAccess>();

        public void AddToDictioany(IdBadge idBadge, BadgeAccess door)
        {
            _badgeDic.Add(idBadge, door);
        }

        public Dictionary<IdBadge, BadgeAccess> SeeAllBadges()
        {
            return _badgeDic;
        }
        //Get Badge by ID
        public IdBadge GetByBadgeID(int badgeID)
        {
            foreach (IdBadge item in _idBadge)
            {
                if (item.BadgeID == badgeID)
                {
                    return item;
                }
            }
            return null;
        }





        //public bool UpdateBadge(int badgeID, Badge updatedBadge)
        //{
        //    Badge oldBadge = GetTheBadgeByID(badgeID);

        //    if (oldBadge != null)
        //    {
        //        oldBadge.DoorName = updatedBadge.DoorName;
        //        oldBadge.NameBadge = updatedBadge.NameBadge;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}
