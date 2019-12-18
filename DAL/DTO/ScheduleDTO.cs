using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public struct ScheduleDTO
    {
        public ScheduleDTO(List<ShiftDTO> Diensten)
        {
            this.Diensten = Diensten;
        }

        public List<ShiftDTO> Diensten { get; set; }
    }
}
