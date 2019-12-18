using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace VollopRooster.Repository
{
    public class ScheduleManager
    {
        private readonly IEmployeeContext employeeContext;
        public ScheduleManager(DateTime startDate, DateTime endDate)
        {
            GetAllEmployees(startDate,endDate);
            GetAllShifts(startDate,endDate);
        }

        public void Fillshifts()
        {
            //GET and fill all shifts with employees
 
        }

        public List<Shift> GetAllShifts(DateTime startDate,DateTime endDate)
        {
            List<Shift> allshifts = new List<Shift>();
            return allshifts;
        }

        public void GetAllEmployees(DateTime startDate, DateTime endDate)
        {
            for(int x = 0; x < employeeContext.GetTotalEmployees(); x++)
            {
                Employee tempEmployee = new Employee(x, startDate, endDate);
                AllEmployees.Add(tempEmployee);
            }
        }

        public List<Employee> AllEmployees { get; set; }
        public List<Shift> AllShifts { get; set; }
    }
}
