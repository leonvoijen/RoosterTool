using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DTO;
using DAL.Interfaces;
using VollopRooster.Models;
using VollopRooster.Repository.Interfaces;

namespace VollopRooster.Repository
{
    public class AvailabilityLogic : IAvailabilityLogic
    {
        private readonly IAvailabilityContext Context;

        public AvailabilityLogic(IAvailabilityContext context)
        {
            this.Context = context;
        }

        public AvailabilityModel GetAvailability(int id)
        {
            AvailabilityDTO dto = new AvailabilityDTO();
            dto = Context.GetAvailability(id);

            var modeltransfer = new AvailabilityModel()
            {
                Id = dto.UserId,
                StartMonday = dto.StartMonday,
                EndMonday = dto.EndMonday,
                StartTuesday = dto.StartTuesday,
                EndTuesday = dto.EndTuesday,
                StartWednesday = dto.StartWednesday,
                EndWednesday = dto.EndWednesday,
                StartThursday = dto.StartThursday,
                EndThursday = dto.EndThursday,
                StartFriday = dto.StartFriday,
                EndFriday = dto.EndFriday,
                StartSaturday = dto.StartSaturday,
                EndSaturday = dto.EndSaturday,
                StartSunday = dto.StartSunday,
                EndSunday = dto.EndSunday
            };
            return modeltransfer;
        }

        public AvailabilityDTO GetAvailabilityDtos(int id)
        {
            return Context.GetAvailability(id);
        }

        public void UpdateAvailability(AvailabilityModel availabilitymodel)
        {
            AvailabilityDTO dtotransfer = new AvailabilityDTO()
            {
            UserId = availabilitymodel.Id,
            StartMonday = availabilitymodel.StartMonday,
            EndMonday = availabilitymodel.EndMonday,
            StartTuesday = availabilitymodel.StartTuesday,
            EndTuesday = availabilitymodel.EndTuesday,
            StartWednesday = availabilitymodel.StartWednesday,
            EndWednesday = availabilitymodel.EndWednesday,
            StartThursday = availabilitymodel.EndThursday,
            EndThursday = availabilitymodel.EndThursday,
            StartFriday = availabilitymodel.StartFriday,
            EndFriday = availabilitymodel.EndFriday,
            StartSaturday = availabilitymodel.StartSaturday,
            EndSaturday = availabilitymodel.EndSaturday,
            StartSunday = availabilitymodel.StartSunday,
            EndSunday = availabilitymodel.EndSunday

            };
            Context.UpdateAvailability(dtotransfer);
        }
    }
}
