using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VollopRooster.ViewModels
{
    public class ShiftViewModel
    {
        public ShiftViewModel()
        {
        }

        public ShiftViewModel(int id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        public ShiftViewModel(int id, string description, DateTime date, DateTime startTime, DateTime endTime, int nrOfBar, int nrOfEvent, int nrOfExtra)
        {
            Id = id;
            Description = description;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NrOfBar { get; set; }
        public int NrOfEvent { get; set; }
        public int NrOfExtra { get; set; }
    }
}
