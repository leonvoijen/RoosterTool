using System;
using System.Collections.Generic;
using System.Text;
using DAL.DTO;

namespace Logic.Interfaces
{
    public interface IScheduleLogic
    {
        void CreateSchedule(DateTime starttime, DateTime Endtime);
        List<EmployeeDTO> GetAllEmployeeData();
        List<ShiftDTO> GetAllShiftData(DateTime startdate, DateTime enddate);
        List<AvailabilityDTO> GetAllAvailabilityData();
    }
}
