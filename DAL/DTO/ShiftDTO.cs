using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public struct ShiftDTO
    {
        public ShiftDTO(int id, DateTime date, DateTime startTime, DateTime endTime, string details, int nrOfBar, int nrOfEvent, int nrOfIets) : this()
        {
            Id = id;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Details = details;
            NrOfBar = nrOfBar;
            NrOfEvent = nrOfEvent;
            NrOfIets = nrOfIets;
        }

        public int Id               { get; set; }
        public DateTime Date        { get; set; }
        public DateTime StartTime   { get; set; }
        public DateTime EndTime     { get; set; }
        public string Details       { get; set; }
        public int NrOfBar             { get; set; }
        public int NrOfEvent           { get; set; }
        public int NrOfIets            { get; set; }

    }

   

   
}
