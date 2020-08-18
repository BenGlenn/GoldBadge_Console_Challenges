using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepo
{
    public class Repo
    {
        private List<TheClaim> _theClaims = new List<TheClaim>();

        //Create
        public void AddNewClaim(TheClaim content)
        {
            _theClaims.Add(content);
        }

        //Read

     public List<TheClaim> GetClaims()
        {
            return _theClaims;
        }

        public TheClaim GetClaimByID(double claimID)
        {
            foreach (TheClaim item in _theClaims)
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


    }
}
