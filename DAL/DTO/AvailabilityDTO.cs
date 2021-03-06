﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public struct AvailabilityDTO
    {
        public AvailabilityDTO(int id, TimeSpan startMonday, TimeSpan endMonday, TimeSpan startTuesday, TimeSpan endTuesday, TimeSpan startWednesday, TimeSpan endWednesday, TimeSpan startThursday, TimeSpan endThursday, TimeSpan startFriday, TimeSpan endFriday, TimeSpan startSaturday, TimeSpan endSaturday, TimeSpan startSunday, TimeSpan endSunday)
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
            Leave = new List<DateTime>();
        }

        public int UserId { get; set; }
        public TimeSpan StartMonday { get; set; }
        public TimeSpan EndMonday { get; set; }
        public TimeSpan StartTuesday { get; set; }
        public TimeSpan EndTuesday { get; set; }
        public TimeSpan StartWednesday { get; set; }
        public TimeSpan EndWednesday { get; set; }
        public TimeSpan StartThursday { get; set; }
        public TimeSpan EndThursday { get; set; }
        public TimeSpan StartFriday { get; set; }
        public TimeSpan EndFriday { get; set; }
        public TimeSpan StartSaturday { get; set; }
        public TimeSpan EndSaturday { get; set; }
        public TimeSpan StartSunday { get; set; }
        public TimeSpan EndSunday { get; set; }
        public List<DateTime> Leave { get; set;}
    }
}
