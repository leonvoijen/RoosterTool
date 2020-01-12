using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IAvailabilityContext
    {
        AvailabilityDTO GetAvailability(int id);
        void UpdateAvailability(AvailabilityDTO dtotransfer);
        List<DateTime> GetLeave();
        List<AvailabilityDTO> GetAllAvailability();
    }
}
