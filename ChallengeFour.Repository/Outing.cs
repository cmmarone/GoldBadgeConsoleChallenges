using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFour.Repository
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert }
    public class Outing
    {
        public DateTime Date { get; set; }
        public EventType EventType { get; set; }
        public int Attendance { get; set; }
        public double HeadCost
        {
            get
            {
                return Math.Round((TotalCost / Attendance), 2);
            }
        }
        public double TotalCost { get; set; }

        public Outing() { }
        public Outing(DateTime date, EventType eventType, int attendance, double totalCost)
        {
            Date = date;
            EventType = eventType;
            Attendance = attendance;
            TotalCost = totalCost;
        }
    }
}
