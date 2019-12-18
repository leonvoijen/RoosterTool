using System;
using System.Collections.Generic;
using System.Text;
using VollopRooster.Models;

namespace Logic.Interfaces
{
    public interface IShiftLogic
    {
        IEnumerable<ShiftModel> GetAllShifts();
        ShiftModel GetShift(int id);
        void AddShift(ShiftModel newShift);
        void RemoveShift(int id);
        void UpdateShift(ShiftModel model);
    }
}
