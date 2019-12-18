using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VollopRooster.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel(int id, string name, string description, DateTime month, DateTime starTime, DateTime endTime, int nrOfBar, int nrOfEvent, int nrOfExtra)
        {
            Id = id;
            Name = name;
            Description = description;
            Month = month;
            StartTime = starTime;
            EndTime = endTime;
            NrOfBar = nrOfBar;
            NrOfEvent = nrOfEvent;
            NrOfExtra = nrOfExtra;

        }

        public int Id { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Month { get; set; }
        public DateTime StartTime  { get; set; }
        public DateTime EndTime { get; set; }
        public int NrOfBar { get; set;}
        public int NrOfEvent { get; set; }
        public int NrOfExtra { get; set; }
    }
}
