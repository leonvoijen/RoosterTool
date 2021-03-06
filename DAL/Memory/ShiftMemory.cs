﻿using DAL.DTO;
using System;
using System.Collections.Generic;
using DAL.Interfaces;

namespace DAL.Memory
{
    public class ShiftMemory : IShiftContext
    {
        private List<ShiftDTO> shifts = new List<ShiftDTO>();

        public ShiftMemory()
        {
            shifts = new List<ShiftDTO>()
            {
                new ShiftDTO(0,DateTime.Now.AddHours(2), new TimeSpan(16,0,0), new TimeSpan(23,0,0), "details",2,2,2),
                new ShiftDTO(1,DateTime.Now.AddHours(2), new TimeSpan(16,0,0), new TimeSpan(23,0,0), "details",1,1,1),
                new ShiftDTO(2,DateTime.Now.AddHours(2), new TimeSpan(16,0,0), new TimeSpan(23,0,0), "details",1,0,1),
                new ShiftDTO(3,DateTime.Now.AddHours(2), new TimeSpan(16,0,0), new TimeSpan(23,0,0), "details",0,0,0),
                new ShiftDTO(4,DateTime.Now.AddHours(2), new TimeSpan(16,0,0), new TimeSpan(23,0,0), "details",1,1,2),
            };
        }

        public void AddShift(ShiftDTO dto)
        {
            shifts.Add(dto);
        }

        public void ChangeShift(ShiftDTO dto)
        {
            shifts.RemoveAt(dto.Id);
            shifts.Add(dto);
        }

        public List<ShiftDTO> GetAllShifts()
        {
            return shifts;
        }

        public IEnumerable<ShiftDTO> GetAllShiftsFromPeriod(DateTime startdate, DateTime enddate)
        {
            var dtos = new List<ShiftDTO>();
            foreach (var shift in shifts)
            {
                if (shift.Date >= startdate && shift.Date <= enddate)
                {
                    dtos.Add(shift);
                }
            }

            return dtos;
        }

        public IEnumerable<string> GetRoles(int id)
        {
            //TODO: TOEVOEGEN AAN DTO
        //    List<string> Roles = new List<string>();
        //    if (shifts[id].Bar == true)
        //    {
        //        Roles.Add("Bar");
        //    }
        //    else if (shifts[id].Events == true)
        //    {
        //        Roles.Add("Event");
        //    }
        //    else if (shifts[id].Overig == true)
        //    {
        //        Roles.Add("Other");
        //    }

        //    return Roles;
        List<string> strings = new List<string>();
        strings.Add("Bar");
        strings.Add("Event");
        strings.Add("Other");
        return strings;
        }

        public ShiftDTO GetShift(int id)
        {
            return shifts[id];
        }

        public void RemoveShift(int id)
        {
            shifts.RemoveAt(id);
        }
    }
}
