using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepo
{
    public class Repo
    {
        private List<TheClaim> _ListOFClaims = new List<TheClaim>();
      
        public void AddNewClaim(TheClaim content)
        {
            _ListOFClaims.Add(content);
        }

        public List<TheClaim> GetClaims()
        {
            return _ListOFClaims;
        }

        public TheClaim GetClaimByID(double claimID)
        {
            foreach (TheClaim item in _ListOFClaims)
            {
                if (item.ClaimID == claimID)
                {
                    return item;
                }
            }
            return null;
        }

        public bool UpdateExistingClaim(double claimID, TheClaim updatedClaim )
        {
            TheClaim oldClaim = GetClaimByID(claimID);

            if (oldClaim != null)
            {
                oldClaim.ClaimType = updatedClaim.ClaimType;
                oldClaim.Description = updatedClaim.Description;
                oldClaim.ClaimAmount = updatedClaim.ClaimAmount;
                oldClaim.DateOfIncident = updatedClaim.DateOfIncident;
                oldClaim.DateOfClaim = updatedClaim.DateOfClaim;
                oldClaim.IsValid = updatedClaim.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveClaim(double itemNumber)
        {
            TheClaim item = GetClaimByID(itemNumber);

            if (item == null)
            {
                return false;
            }

            int initialCount = _ListOFClaims.Count;
            _ListOFClaims.Remove(item);

            if (initialCount > _ListOFClaims.Count)
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
