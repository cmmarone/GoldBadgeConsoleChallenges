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

        public bool AddBadge(Badge badge)
        {
            int dictionarySizeBeforeAdd = _badgeDictionary.Count;
            _badgeDictionary.Add(badge.BadgeID, badge.DoorAccess);
            bool wasAdded = (_badgeDictionary.Count > dictionarySizeBeforeAdd);
            return wasAdded;
        }


        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeDictionary;
        }

        public bool UpdateDoorAccess(int badgeID, List<string> updatedDoorAccess)
        {
            KeyValuePair<int, List<string>> existingBadge = GetBadgeByBadgeID(badgeID);

            if (existingBadge.Value != null)
            {
                existingBadge.Value.Clear();
                existingBadge.Value.AddRange(updatedDoorAccess);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveAllDoorAccess(int badgeID)
        {
            KeyValuePair<int, List<string>> existingBadge = GetBadgeByBadgeID(badgeID);

            if (existingBadge.Value != null)
            {
                existingBadge.Value.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        public KeyValuePair<int, List<string>> GetBadgeByBadgeID(int badgeID)
        {
            KeyValuePair<int, List<string>> emptyBadge = new KeyValuePair<int, List<string>>();
            foreach (KeyValuePair<int, List<string>> badge in _badgeDictionary)
            {
                if (badge.Key == badgeID)
                {
                    return badge;
                }
            }
            return emptyBadge;
        }
    }
}
