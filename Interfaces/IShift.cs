using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using VollopRooster.Models;

namespace Interfaces
{
    interface IShift
    {
        IEnumerable<ShiftModel> GetallShifts();
        void RemoveShift(int id);
        void AddShift(string start, string end, string date, string details);
        void ChangeShiftEmployee(string name1, string name2);
    }
}
