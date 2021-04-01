using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour.Repository
{
    public class OutingRepository
    {
        List<Outing> _outingDirectory = new List<Outing>();

        public bool AddOuting(Outing outing)
        {
            int listSizeBefore = _outingDirectory.Count;
            _outingDirectory.Add(outing);
            bool addSucceeded = (_outingDirectory.Count > listSizeBefore) ? true : false;
            return addSucceeded;
        }

        public List<Outing> GetAllOutings()
        {
            return _outingDirectory;
        }

        public List<Outing> GetOutingsYTD()
        {
            List<Outing> listOfYear = new List<Outing>();
            foreach (Outing outing in _outingDirectory)
            {
                if (outing.Date.Year == DateTime.Now.Year)
                {
                    listOfYear.Add(outing);
                }
            }
            return listOfYear;
        }

        public List<Outing> GetAllOutingsByEventType(EventType eventType)
        {
            List<Outing> listOfEventType = new List<Outing>();
            foreach (Outing outing in _outingDirectory)
            {
                if (outing.EventType == eventType)
                {
                    listOfEventType.Add(outing);
                }
            }
            return listOfEventType;
        }

        public List<Outing> GetOutingsByEventTypeYTD(EventType eventType)
        {
            List<Outing> listOfEventTypeAndYear = new List<Outing>();
            foreach (Outing outing in _outingDirectory)
            {
                if ((outing.EventType == eventType) && (outing.Date.Year == DateTime.Now.Year))
                {
                    listOfEventTypeAndYear.Add(outing);
                }
            }
            return listOfEventTypeAndYear;
        }
    }
}
