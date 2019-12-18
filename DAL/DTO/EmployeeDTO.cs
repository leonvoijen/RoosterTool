using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public struct EmployeeDTO
    {
        public EmployeeDTO(int id,string name, string phonenumber, string picurl, int hours, string availability, bool bar, bool events, bool overig)
        {
            Id = id;
            PicUrl = picurl;
            Name = name;
            PhoneNumber = phonenumber;
            MaxHours = hours;
            Availability = availability;
            Bar = bar;
            Events = events;
            Overig = overig;
        }

        public int Id { get; set; }
        public string Name { get; set;}
        public string PhoneNumber { get; set; }
        public string PicUrl { get; set; }
        public int MaxHours { get; set; }
        public string Availability { get; set;}
        public bool Bar { get; set; }
        public bool Events { get; set; }
        public bool Overig { get; set; }
    }
}
