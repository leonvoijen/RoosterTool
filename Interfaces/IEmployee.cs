using System;
using System.Collections.Generic;
using System.Text;
using VollopRooster.Models;

namespace Interfaces
{
    interface IEmployee
    {
        void AddEmployee(string name, string PicUrl, List<Role> Roles);
        void RemoveEmployee(int id);

        string GetName(int id);

        string GetPicUrl(int id);

        string GetMaxHours(int id);
    }
}
