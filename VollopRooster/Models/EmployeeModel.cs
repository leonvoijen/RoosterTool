using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VollopRooster.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {

        }
        public EmployeeModel(string name, string phone, bool bar, bool @event, bool iets, int maxHours, string availability)
        {
            Name = name;
            Phone = phone;
            Bar = bar;
            Event = @event;
            Iets = iets;
            MaxHours = maxHours;
            Availability = availability;
        }

        public EmployeeModel(string name, string picUrl, string phone, int id, int maxHours, string availability, bool bar, bool @event, bool iets)
        {
            Name = name;
            PicUrl = picUrl;
            Phone = phone;
            Id = id;
            MaxHours = maxHours;
            Availability = availability;
            Bar = bar;
            Event = @event;
            Iets = iets;
        }

        public EmployeeModel(EmployeeDTO employeeDTO)
        {
            Name = employeeDTO.Name;
            PicUrl = employeeDTO.PicUrl;
            Phone = employeeDTO.PhoneNumber;
            Id = employeeDTO.Id;
            MaxHours = employeeDTO.MaxHours;
            Availability = employeeDTO.Availability;
            Bar = employeeDTO.Bar;
            Event = employeeDTO.Events;
            Iets = employeeDTO.Overig;
        }

        public string Name { get; set; }
        public string PicUrl { get; set; }
        public string Phone { get; set; }
        public int Id { get; set; }
        public bool Bar { get; set;}
        public bool Event { get; set;}
        public bool Iets { get; set;}
        public int MaxHours { get; set; }
        public string Availability { get; set; }
    }

}
