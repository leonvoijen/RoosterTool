using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DTO;
using DAL.Interfaces;

namespace VollopRooster.Repository
{
    public class Availability
    {
        private readonly IAvailabilityContext availabilityContext;

        public Availability(DateTime startDate, DateTime endDate, int id)
        {
            StartDate = startDate;
            EndDate = endDate;
            UserId = id;
            GetGivenMonth(startDate.Year, startDate.Month);
            FillWeeklyAvailability();
            CalculateMonthlyAvailability();
        }

        public void GetGivenMonth(int year, int month)
        {
            MonthlyAvailability = Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                .Select(day => new DateTime(year, month, day)).ToList();
        }

        public void GetLeave()
        {
            Leave = availabilityContext.GetLeave();
        }

        public void FillWeeklyAvailability()
        {
            AvailabilityDTO dto = availabilityContext.GetAvailability(UserId);
            WeeklyAvailability.Add(dto.StartMonday);
            WeeklyAvailability.Add(dto.EndMonday);
            WeeklyAvailability.Add(dto.StartTuesday);
            WeeklyAvailability.Add(dto.EndTuesday);
            WeeklyAvailability.Add(dto.StartWednesday);
            WeeklyAvailability.Add(dto.EndWednesday);
            WeeklyAvailability.Add(dto.StartThursday);
            WeeklyAvailability.Add(dto.EndThursday);
            WeeklyAvailability.Add(dto.StartFriday);
            WeeklyAvailability.Add(dto.EndFriday);
            WeeklyAvailability.Add(dto.StartSaturday);
            WeeklyAvailability.Add(dto.EndSaturday);
            WeeklyAvailability.Add(dto.StartSunday);
            WeeklyAvailability.Add(dto.EndSunday);
        }

        public void CalculateMonthlyAvailability()
        {   var temp = new List<DateTime>();

            for (int x = 0; x < WeeklyAvailability.Count; x++)
            {
                if (MonthlyAvailability[x].DayOfWeek == WeeklyAvailability[x].DayOfWeek)
                {
                    DateTime replaceTime = new DateTime(MonthlyAvailability[x].Year,MonthlyAvailability[x].Month, MonthlyAvailability[x].Day,
                        WeeklyAvailability[x].Hour,WeeklyAvailability[x].Minute,WeeklyAvailability[x].Second);
                    MonthlyAvailability[x] = replaceTime;
                }
            }

            for (int x = 0; x < Leave.Count; x++)
            {
                for (int y = 0; y < MonthlyAvailability.Count; y++)
                {
                    if (Leave[x].Date == MonthlyAvailability[y].Date)
                    {
                        MonthlyAvailability.Remove(MonthlyAvailability[y]);
                    }
                }

            }
        }

        public int UserId { get; set;}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DateTime> MonthlyAvailability { get; set; }
        private List<DateTime> WeeklyAvailability { get; set; }
        public List<DateTime> Leave { get; set; }
    }
}