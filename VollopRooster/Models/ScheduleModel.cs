using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VollopRooster.Models
{
    public class ScheduleModel
    {
        public ScheduleModel(DateTime Startdate, DateTime Enddate, List<ShiftModel> Shifts)
        {
            Startdate = this.Startdate;
            Enddate = this.Enddate;
            Shifts = this.Shifts;
        }

        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }

        private List<ShiftModel> Shifts { get; set;}
    }
}
