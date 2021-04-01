using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Repository
{
    public class ClaimRepository
    {
        Queue<Claim> _claimsQueue = new Queue<Claim>();

        public bool AddClaim(Claim newClaim)
        {
            int queueSizeBeforeAdd = _claimsQueue.Count;
            _claimsQueue.Enqueue(newClaim);
            bool claimWasAdded = (queueSizeBeforeAdd < _claimsQueue.Count) ? true : false;
            return claimWasAdded;
        }

        public Queue<Claim> GetAllClaims()
        {
            return _claimsQueue;
        }

        public Claim RemoveTopClaim()
        {
            Claim dequeuedClaim = _claimsQueue.Dequeue();
            return dequeuedClaim;
        }

        public Claim PeekNextClaim()
        {
            Claim nextClaim = _claimsQueue.Peek();
            return nextClaim;
        }
    }
}
