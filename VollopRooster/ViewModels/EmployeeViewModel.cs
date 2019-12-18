using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VollopRooster.Models;

namespace VollopRooster.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
        }

        public EmployeeViewModel(int id, string name, string phonenumber, string availability, bool bar, bool @event, bool iets, int maxhours)
        {
            Id = id;
            Name = name;
            Phonenumber = phonenumber;
            Availability = availability;
            Bar = bar;
            Event = @event;
            Iets = iets;
            MaxHours = maxhours;
        }

        public void LoadModel()
        {
            Name = "leon";
            Phonenumber = "0657810962";
            Availability = "onbekend";
            Bar = true;
            Event = false;
            Iets = false;
            MaxHours = 20;
        }

        public EmployeeViewModel Load()
        {
            LoadModel();
            return this;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phonenumber { get; set; }
        public string Availability { get; set; }
        public bool Bar { get; set; }
        public bool Event { get; set; }
        public bool Iets { get; set; }
        public int MaxHours { get; set; }
    }
}
