using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public struct EventDTO
    {
 
        public EventDTO(int id, string name, string description, DateTime month, DateTime startTime, DateTime endTime, int nrbar, int nrevent, int nriets) 
        {
            Id = id;
            Name = name;
            Description = description;
            Month = month;
            StartTime = startTime;
            EndTime = endTime;
            Nrbar = nrbar;
            Nrevent = nrevent;
            Nriets = nriets;
        }

        public int Id { get; set;}
        public string Name { get; set;}
        public string Description { get; set; }
        public DateTime Month { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Nrbar { get; set; }
        public int Nrevent { get; set; }
        public int Nriets { get; set; }
    }
}
