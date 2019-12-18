using System;
using System.Collections.Generic;
using DAL.Interfaces;

namespace VollopRooster.Repository
{
    public class ShiftRole
    {
        private readonly IShiftContext shiftContext;
        public ShiftRole(int id)
        {
            foreach (var role in shiftContext.GetRoles(id))
            {
                if (role == "Bar")
                {

                    RoleList.Add(Role.Bar);
                }
                else if (role == "Event")
                {
                    RoleList.Add(Role.Event);
                }
                else if (role == "Other")
                {
                    RoleList.Add(Role.Other);
                }
            }
        }
        public List<Role> RoleList {get; set;}
    }
}