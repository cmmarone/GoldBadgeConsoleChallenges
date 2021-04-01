using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Repository
{
    public class BadgeRepository
    {

        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        

        public bool AddBadge(int newBadgeID, List<string> newDoorAccess)
        {
            int dictionarySizeBeforeAdd = _badgeDictionary.Count;
            _badgeDictionary.Add(newBadgeID, newDoorAccess);
            bool wasAdded = (_badgeDictionary.Count > dictionarySizeBeforeAdd);
            return wasAdded;
        }

        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeDictionary;
        }

        public bool UpdateDoorAccess(int badgeID, List<string> updatedDoorAccess)
        {
            Badge existingBadge = GetBadgeByID(badgeID);
            if (existingBadge != null)
            {
                existingBadge.BadgeID = existingBadge.BadgeID;
                existingBadge.DoorAccess = updatedDoorAccess;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveAllDoorAccess(int badgeID)
        {
            Badge existingBadge = GetBadgeByID(badgeID);
            if (existingBadge != null)
            {
                existingBadge.DoorAccess.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Badge GetBadgeByID(int badgeID)
        {
            List<string> doorAccess = new List<string>();
            foreach (KeyValuePair in _badgeDictionary)
            {
                if ( )
                {
                 
                }
            }
            return null;
        }



      
    }
}
