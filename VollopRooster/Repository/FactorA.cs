using System;
using System.Collections.Generic;
using DAL.Interfaces;

namespace VollopRooster.Repository
{
    public class FactorA
    {
        private readonly IEmployeeContext EmployeeContext;
        public FactorA(int id)
        {
            AvailableHours = EmployeeContext.GetMaxHours(id);
        }

        public double CalculateFactor(int id)
        {
            double temp = 0;
            //total employees/total availability * (availability employee - already planned hours)
            TotalEmployees = EmployeeContext.GetTotalEmployees();
            TotalAvailableHours = EmployeeContext.GetTotalAvailabeHours();
            temp = TotalEmployees / TotalAvailableHours * AvailableHours;
            Factor = temp;
            return Factor;
        }
        public double Factor { get; set; }
        public int AvailableHours { get; set; }
        public int TotalEmployees { get; set; }
        public int TotalAvailableHours { get; set; }
    }
}