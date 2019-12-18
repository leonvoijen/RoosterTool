using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IEmployeeContext
    {
        List<EmployeeDTO> GetAllEmployees();
        void AddEmployee(EmployeeDTO dto);

        EmployeeDTO GetEmployee(int id);
        IEnumerable<string> GetRoles(int id);
        void RemoveEmployee(int id);

        void ChangeEmployee(EmployeeDTO dto);
        int GetMaxHours(int id);
        int GetTotalEmployees();
        int GetTotalAvailabeHours();
    }
}
