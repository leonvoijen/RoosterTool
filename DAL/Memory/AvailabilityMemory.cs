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
            TimeSpan endtime = new TimeSpan(23,59,59);
            TimeSpan starttime = new TimeSpan(1,1,1);
            availability = new List<AvailabilityDTO>()
            {
                new AvailabilityDTO(1,starttime,endtime,starttime,endtime,starttime,
                    endtime, starttime, endtime, starttime, endtime,
                    starttime,endtime, starttime, endtime),

                new AvailabilityDTO(2,starttime,starttime,starttime,starttime,starttime,
                    starttime, starttime, starttime, starttime, starttime,
                    starttime, starttime, starttime, starttime),

                new AvailabilityDTO(3,starttime,endtime,starttime,endtime,starttime,
                    endtime, starttime, endtime, starttime, endtime,
                    starttime, endtime, starttime, endtime),

                new AvailabilityDTO(4,starttime,endtime,starttime,endtime,starttime,
                    endtime, starttime, endtime, starttime, endtime,
                    starttime, endtime, starttime, endtime)
            };

            DateTime leave1 = DateTime.Now;
            DateTime leave2 = DateTime.Now.AddDays(1);
            availability[0].Leave.Add(leave2);
            availability[1].Leave.Add(leave1);

        }

        public List<AvailabilityDTO> GetAllAvailability()
        {
            return availability;
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
