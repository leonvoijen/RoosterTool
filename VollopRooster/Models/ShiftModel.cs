using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DTO;

namespace VollopRooster.Models
{
    public class ShiftModel
    {

        public ShiftModel(int id, TimeSpan startTime, TimeSpan endTime, DateTime date, string description, int nrOfBar, int nrOfEvent, int nrOfExtra)
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

        public ShiftModel()
        {
        }

        public ShiftModel(TimeSpan startTime, TimeSpan endTime, DateTime date, string description, int nrOfBar, int nrOfEvent, int nrOfExtra)
        {
            StartTime = startTime;
            EndTime = endTime;
            Date = date;
            Description = description;
            NrOfBar = nrOfBar;
            NrOfEvent = nrOfEvent;
            NrOfExtra = nrOfExtra;
        }

        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public  DateTime Date { get; set; }
        public string Description { get; set; }
        public int NrOfBar { get; set; }
        public int NrOfEvent { get; set; }
        public int NrOfExtra { get; set; }
    }
}
