using DAL.Interfaces;
using System.Collections.Generic;

namespace VollopRooster.Repository
{
    public class EmployeeRole
    {
        private readonly IEmployeeContext employeeContext;
        public EmployeeRole(int id)
        {
            foreach (var role in employeeContext.GetRoles(id))
            {
                if (role == "Bar")
                {

                    RoleList.Add(Role.Bar);
                }
                else if (role == "Event")
                {
                    RoleList.Add(Role.Event);
                }
                else if(role == "Other")
                {
                   RoleList.Add(Role.Other);
                }
            }
        }
        public List<Role> RoleList { get; set; }
    }
}