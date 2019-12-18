using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DTO;

namespace VollopRooster.Models
{
    public class ShiftModel
    {

        public ShiftModel(int id, DateTime startTime, DateTime endTime, DateTime date, string description, int nrOfBar, int nrOfEvent, int nrOfExtra)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Date = date;
            Description = description;
            NrOfBar = nrOfBar;
            NrOfEvent = nrOfEvent;
            NrOfExtra = nrOfExtra;
        }

        public ShiftModel(ShiftDTO dto)
        {
            Id = dto.Id;
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
            Date = dto.Date;
            Description = dto.Details;
            NrOfBar = dto.NrOfBar;
            NrOfEvent = dto.NrOfEvent;
            NrOfExtra = dto.NrOfIets;
        }

        public int Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public  DateTime Date { get; private set; }
        public string Description { get; private set; }
        public int NrOfBar { get; private set; }
        public int NrOfEvent { get; private set; }
        public int NrOfExtra { get; private set; }
    }
}
