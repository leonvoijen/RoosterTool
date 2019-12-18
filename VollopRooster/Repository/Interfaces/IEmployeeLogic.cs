using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using VollopRooster.Models;

namespace Logic.Interfaces
{
    public interface IEmployeeLogic
    {
        void AddEmployee(EmployeeModel NewEmployee);
        IEnumerable<EmployeeModel> GetAllEmployee();
        EmployeeModel GetEmployee(int id);
        void RemoveEmployee(int id);
        void UpdateEmployee(EmployeeModel model);
    }
}
