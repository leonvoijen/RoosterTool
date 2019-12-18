using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VollopRooster.Models;

namespace VollopRooster.Repository.Interfaces
{
    public interface IAvailabilityLogic
    {
        AvailabilityModel GetAvailability(int id);
        void UpdateAvailability(AvailabilityModel availabilitymodel);
    }
}
