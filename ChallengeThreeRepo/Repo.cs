using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class Repo

    {
        //Working Methods vv

        public Dictionary<IdBadge, BadgeAccess> _badgeDic = new Dictionary<IdBadge, BadgeAccess>();

        public List<IdBadge> _idBadges = new List<IdBadge>();

        public Dictionary<IdBadge, BadgeAccess> SeeAllBadges()
        {
            return _badgeDic;
        }

        //AddToDictionary method's sole purpose is to add a new badge to the dictionary, you will add the doors to the BadgeAccess prior to adding the KeyValuePair to the dictionary.
        public void AddToDictionary(IdBadge idBadge, BadgeAccess door)
        {
            _badgeDic.Add(idBadge, door);
        }

        public IdBadge SingleBadgeByID(int idbadge)
        {
            foreach (IdBadge singleIdBadge in _idBadges)
            {
                if (singleIdBadge.BadgeID == idbadge)
                    return singleIdBadge;
            }
            return null;
        }


        public Dictionary<IdBadge, BadgeAccess> GetSingleBadge()
        {
            return _badgeDic;
        }

        //WHY DOES THIS NOT WORK!!!?????????
        //public bool RemoveDoorFromExistingBadge(int oldbadgeID, string accessCode)
        //{
        //    List<string> existingAccess;

        //    if (_badgeDic.TryGetValue(oldbadgeID out existingAccess))
        //    {
        //        if (existingAccess.Contains(accessCode))
        //            existingAccess.Remove(accessCode);

        //public bool DeleteBadge(idBadge)
        //{
        //    return _idBadges.Remove(idBadge);
        //}



        public bool RemoveBadge(int itemNumber)
        {
            IdBadge item = SingleBadgeByID(itemNumber);
          
            if (item == null)
            {
                return false;
            }

            int initialCount = _idBadges.Count;
            _idBadges.Remove(item);

            if (initialCount > _idBadges.Count)
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
