using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Interfaces;
using Logic.Interfaces;

namespace VollopRooster.Repository
{
    public class ScheduleLogic : IScheduleLogic
    {
        private readonly IScheduleContext _Context;
        private readonly IEmployeeContext _employeeContext;
        private readonly IShiftContext _shiftContext;
        private readonly IAvailabilityContext _availabilityContext;

        public ScheduleLogic(IScheduleContext Context, IEmployeeContext employeeContext, IShiftContext shiftContext, IAvailabilityContext availabilityContext)
        {
            _Context = Context;
            _employeeContext = employeeContext;
            _shiftContext = shiftContext;
            _availabilityContext = availabilityContext;
        }

        public List<EmployeeDTO> GetAllEmployeeData()
        {
            return _employeeContext.GetAllEmployees();
        }

        public List<AvailabilityDTO> GetAllAvailabilityData()
        {
            return _availabilityContext.GetAllAvailability();
        }

        public List<ShiftDTO> GetAllShiftData(DateTime startdate, DateTime enddate)
        {
            return _shiftContext.GetAllShiftsFromPeriod(startdate, enddate).ToList();
        }

        public int TotalHours()
        {
            return _employeeContext.GetTotalAvailabeHours();
        }

        public void CreateSchedule(DateTime startdate, DateTime enddate)
        {
           Schedule schedule = new Schedule();
           ScheduleCreator creator = new ScheduleCreator(GetAllEmployeeData(),GetAllAvailabilityData(),GetAllShiftData(startdate,enddate), TotalHours());
           schedule = creator.GetSchedule();
           FileCreator fileCreator = new FileCreator(schedule);
        }
    }
}
