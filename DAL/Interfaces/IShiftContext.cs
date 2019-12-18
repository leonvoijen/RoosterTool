using System;
using System.Collections.Generic;
using System.Text;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IShiftContext
    {
        IEnumerable<ShiftDTO> GetAllShifts();
        ShiftDTO GetShift(int id);
        void AddShift(ShiftDTO dto);
        void RemoveShift(int id);
        IEnumerable<string> GetRoles(int id);
        void ChangeShift(ShiftDTO dto);
    }
}
