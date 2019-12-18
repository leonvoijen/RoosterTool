using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DAL.DTO;

namespace VollopRooster.Models
{
    public class EventModel
    {
        public EventModel(string name, DateTime date, string description, DateTime startTime, DateTime endTime, int nrbar, int nrevent, int nriets)
        {
            Name = name;
            Date = date;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            Nrbar = nrbar;
            Nrevent = nrevent;
            Nriets = nriets;

        }

        public EventModel(EventDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Date = dto.Month;
            Description = dto.Description;
            StartTime = dto.StartTime;
            EndTime = dto.EndTime;
            
        }

        public EventModel()
        {
        }

        public int Id { get; set;}
        public string Name { get; set;}
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int Nrbar { get; set; }
        public int Nrevent { get; set; }
        public int Nriets { get; set; }

    }
}
