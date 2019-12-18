using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.DTO;
using DAL.Interfaces;

namespace DAL.Memory
{
    public class AvailabilityMemory : IAvailabilityContext
    {
        private readonly List<AvailabilityDTO> availability = new List<AvailabilityDTO>();

        public AvailabilityMemory()
        {
            availability = new List<AvailabilityDTO>()
            {
                new AvailabilityDTO(1,new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),
                    new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1),
                    new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1)),

                new AvailabilityDTO(2,new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),
                    new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1),
                    new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1)),

                new AvailabilityDTO(3,new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),
                    new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1),
                    new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1)),

                new AvailabilityDTO(4,new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),new DateTime(1,1,1,1,1,1),
                    new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1),
                    new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1), new DateTime(1,1,1,1,1,1))
            };

        }
        public AvailabilityDTO GetAvailability(int id)
        {
            return availability.SingleOrDefault(i => i.UserId == id);
        }

        public List<DateTime> GetLeave()
        {
            //TODO: add leave
            throw new NotImplementedException();
        }

        public void UpdateAvailability(AvailabilityDTO dtotransfer)
        {
            availability.RemoveAll(i => i.UserId == dtotransfer.UserId);
            availability.Add(dtotransfer);
        }
    }
}
