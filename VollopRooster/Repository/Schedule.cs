using System.Collections.Generic;

namespace VollopRooster.Repository
{
    public class Schedule
    {
        public List<FilledShift> filledShifts = new List<FilledShift>();
        public List<FilledShift> notFilledShifts = new List<FilledShift>();
    }
}