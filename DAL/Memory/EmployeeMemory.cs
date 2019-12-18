using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DAL.DTO;
using DAL.Interfaces;

namespace DAL.Memory
{
    public class EmployeeMemory :IEmployeeContext
    {
        private readonly List<EmployeeDTO> Employees = new List<EmployeeDTO>();

        public EmployeeMemory()
        {
            Employees = new List<EmployeeDTO>()
            {
                new EmployeeDTO(1, "Leon", "0657810962", " ", 40, " ", true, false, false),
                new EmployeeDTO(2, "Piet", "0638382381", " ", 20, " ", true, false, false),
                new EmployeeDTO(3, "Klaas", "0638382381", " ", 10, " ", false, false, true),
                new EmployeeDTO(4, "Berta", "0638382381", " ", 0, " ", false, true, false),
            };
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            return Employees;
        }
        public EmployeeDTO GetEmployee(int id)
        {
            return Employees.SingleOrDefault(i => i.Id == id);
        }
        public void AddEmployee(EmployeeDTO employee)
        {
            Employees.Add(employee);
        }
        public void RemoveEmployee(int id)
        {
            Employees.RemoveAll(i => i.Id == id);
        }
        public void ChangeEmployee(EmployeeDTO dto)
        {
            Employees.RemoveAll(i => i.Id == dto.Id);
            Employees.Add(dto);
        }

        public int GetTotalEmployees()
        {
            return Employees.Count;
        }

        public int GetTotalAvailabeHours()
        {
            int totalHours = 0;
            foreach (var employee in Employees)
            {
                totalHours += employee.MaxHours;
            }
            return totalHours;
        }

        public int GetMaxHours(int id)
        {
            return Employees.SingleOrDefault(i => i.Id == id).MaxHours;
        }

        public IEnumerable<string> GetRoles(int id)
        {
            List<string> Roles = new List<string>();
            if (Employees[id].Bar == true)
            {
                Roles.Add("Bar");
            }
            else if(Employees[id].Events == true)
            {
                Roles.Add("Event");
            }
            else if(Employees[id].Overig == true)
            {
               Roles.Add("Other");
            }

            return Roles;
        }
    }
}
