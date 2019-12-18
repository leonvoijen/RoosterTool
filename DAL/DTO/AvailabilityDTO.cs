using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public struct AvailabilityDTO
    {
        public AvailabilityDTO(int id, DateTime startMonday, DateTime endMonday, DateTime startTuesday, DateTime endTuesday, DateTime startWednesday, DateTime endWednesday, DateTime startThursday, DateTime endThursday, DateTime startFriday, DateTime endFriday, DateTime startSaturday, DateTime endSaturday, DateTime startSunday, DateTime endSunday) : this()
        {
            UserId = id;
            StartMonday = startMonday;
            EndMonday = endMonday;
            StartTuesday = startTuesday;
            EndTuesday = endTuesday;
            StartWednesday = startWednesday;
            EndWednesday = endWednesday;
            StartThursday = startThursday;
            EndThursday = endThursday;
            StartFriday = startFriday;
            EndFriday = endFriday;
            StartSaturday = startSaturday;
            EndSaturday = endSaturday;
            StartSunday = startSunday;
            EndSunday = endSunday;
        }

        public int UserId { get; set; }
        public DateTime StartMonday { get; set; }
        public DateTime EndMonday { get; set; }
        public DateTime StartTuesday { get; set; }
        public DateTime EndTuesday { get; set; }
        public DateTime StartWednesday { get; set; }
        public DateTime EndWednesday { get; set; }
        public DateTime StartThursday { get; set; }
        public DateTime EndThursday { get; set; }
        public DateTime StartFriday { get; set; }
        public DateTime EndFriday { get; set; }
        public DateTime StartSaturday { get; set; }
        public DateTime EndSaturday { get; set; }
        public DateTime StartSunday { get; set; }
        public DateTime EndSunday { get; set; }
    }
}
