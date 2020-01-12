using System;
using System.Collections.Generic;
using DAL.DTO;

namespace VollopRooster.Repository
{
    public class FilledShift
    {
        public DateTime Date;
        public TimeSpan StartTime;
        public TimeSpan EndTime;
        public List<EmployeeDTO> Employees;
        public bool Filled;
    }
}