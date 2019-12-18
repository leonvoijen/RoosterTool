using System;
using System.Collections.Generic;

namespace VollopRooster.Repository
{
    public class Employee
    {
        public Employee(int id,DateTime startDate, DateTime endDate)
        {
            EmployeeId = id;
            EmployeeRole role = new EmployeeRole(id);
            FactorA factor = new FactorA(id);
            Availability availability = new Availability(startDate,endDate,id);

            EmployeeRole = role.RoleList;
            Factor = factor.Factor;
            Availability = availability.MonthlyAvailability;
        }
        public int EmployeeId { get; set; }
        public List<Role> EmployeeRole { get; set; }
        public double Factor { get; set;}
        public List<DateTime> Availability { get; set; }
    }
}