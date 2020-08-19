using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class Repo
    {
        private List<Badge> _badge = new List<Badge>();

        public void AddNewBadge(Badge content)
        {
            _badge.Add(content);
        }

        public List<Badge> GetBadge()
        {
            return _badge;
        }

        public Badge GetTheBadgeByID(int badgeID)
        {
            foreach(Badge item in _badge)
            {
                if(item.BadgeID == badgeID)
                {
                    return item;
                }
            }
            return null;
        }

        public bool UpdateBadge(int badgeID, Badge updatedBadge)
        {
            Badge oldBadge = GetTheBadgeByID(badgeID);

            if (oldBadge != null)
            {
                oldBadge.DoorName = updatedBadge.DoorName;
                oldBadge.NameBadge = updatedBadge.NameBadge;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveBadge(int badgeID)
        {
            Badge badgeToRemove = GetTheBadgeByID(badgeID);

            if (badgeToRemove == null)
            {
                return false;
            }

            int initialCount = _badge.Count;
            _badge.Remove(badgeToRemove);

            if (initialCount > _badge.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
