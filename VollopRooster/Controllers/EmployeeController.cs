using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VollopRooster.Models;
using VollopRooster.ViewModels;
using Logic.Interfaces;
using VollopRooster.Repository.Interfaces;

namespace VollopRooster.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeLogic EmployeeLogic;
        private readonly IAvailabilityLogic AvailabilityLogic;
        public EmployeeController(IEmployeeLogic employeeLogic, IAvailabilityLogic availabilityLogic)
        {
            this.EmployeeLogic = employeeLogic;
            this.AvailabilityLogic = availabilityLogic;
        }
        [HttpGet]
        public IActionResult EmployeeHome()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            foreach(var employee in EmployeeLogic.GetAllEmployee())
            {
                EmployeeViewModel vm = new EmployeeViewModel(employee.Id,employee.Name, employee.Phone, employee.Availability, employee.Bar,
                employee.Event, employee.Iets, employee.MaxHours);
                employees.Add(vm);
            }
            return View("EmployeeHome",employees);
        }
        public IActionResult ChangeEmployee(int id)
        {
            var model = EmployeeLogic.GetEmployee(id);
            var vm = new EmployeeViewModel()
            {
                Id = model.Id,
                Availability = model.Availability,
                Bar = model.Bar,
                Event = model.Event,
                Iets = model.Iets,
                MaxHours = model.MaxHours,
                Name = model.Name,
                Phonenumber = model.Phone
            };

            return View("ChangeEmployee", vm);
        }

        public IActionResult UpdateEmployee(int id, string availability, bool bar, bool _event, bool iets, int maxhours, string name, string phone)
        {
            var model = new EmployeeModel()
            {
                Id = id,
                Availability = availability,
                Bar = bar,
                Event = _event,
                Iets = iets,
                MaxHours = maxhours,
                Name = name,
                Phone = phone
            };
            EmployeeLogic.UpdateEmployee(model);

            EmployeeModel viewmodeltransfer = EmployeeLogic.GetEmployee(id);
            var vm = new EmployeeViewModel()
            {
                Id = viewmodeltransfer.Id,
                Availability = viewmodeltransfer.Availability,
                Bar = viewmodeltransfer.Bar,
                Event = viewmodeltransfer.Event,
                Iets = viewmodeltransfer.Iets,
                MaxHours = viewmodeltransfer.MaxHours,
                Name = viewmodeltransfer.Name,
                Phonenumber = viewmodeltransfer.Phone
            };
            return View("ChangeEmployee", vm);
        }
        public IActionResult EmployeeIndividual(int id)
        {
            EmployeeModel model = EmployeeLogic.GetEmployee(id);
            EmployeeViewModel vm = new EmployeeViewModel()
            {
                Id = model.Id,
                Availability = model.Availability,
                Bar = model.Bar,
                Event = model.Event,
                Iets = model.Iets,
                MaxHours = model.MaxHours,
                Name = model.Name,
                Phonenumber = model.Phone
            };
            return View("Employeeindividual", vm);
        }
        public IActionResult Remove(int id)
        {
            EmployeeLogic.RemoveEmployee(id);
            return RedirectToAction("EmployeeHome");
        }

        public IActionResult Add()
        {
            return View("AddEmployee", new EmployeeModel());
        }

        [HttpPost]
        public IActionResult CreateEmployee(string Name, string Phone, int MaxHours, string Availability, bool Bar, bool Event, bool Overig, string PicUrl)
        {
            EmployeeModel newEmployee = new EmployeeModel(Name,PicUrl,Phone,MaxHours," ",Bar,Event,Overig);
            EmployeeLogic.AddEmployee(newEmployee);
            return RedirectToAction("EmployeeHome");
        }

        public IActionResult AddAvailability(int id)
        {
            AvailabilityModel model = AvailabilityLogic.GetAvailability(id);
            return View("AddAvailability", model);
        }

        public IActionResult UpdateAvailability(int id, TimeSpan startmonday, TimeSpan endmonday, TimeSpan starttuesday, TimeSpan endtuesday, TimeSpan startwednesday, TimeSpan endwednesday,
            TimeSpan startthursday, TimeSpan endthursday, TimeSpan startfriday, TimeSpan endfriday, TimeSpan startsaturday, TimeSpan endsaturday, TimeSpan startsunday,
            TimeSpan endsunday)
        {
            var availabilitymodel = new AvailabilityModel(id,startmonday,endmonday,starttuesday,endtuesday,startwednesday,endwednesday,
                startthursday,endthursday,startfriday,endfriday,startsaturday,endsaturday,startsunday, endsunday);
            AvailabilityLogic.UpdateAvailability(availabilitymodel);
            return RedirectToAction("EmployeeHome");
        }
    }
}