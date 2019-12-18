using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VollopRooster.Repository
{
    public class Shift
    {   
        public void GetAllShiftRoles()
        {
        }
        public int Id { get; set; }
        public List<ShiftRole> Roles { get; set;}
        public List<Employee> Employees { get; set;}
        public bool Filled { get; set;}
    }
}