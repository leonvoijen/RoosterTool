using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VollopRooster.Models;
using VollopRooster.ViewModels;
using VollopRooster.Repository.Interfaces;

namespace VollopRooster.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventLogic logic;

        public EventController(IEventLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IActionResult EventHome()
        {
            List<EventViewModel> events = new List<EventViewModel>();
            foreach (var item in logic.GetAllEvents())
            {
                EventViewModel vm = new EventViewModel(item.Id, item.Name, item.Description, item.Date, item.StartTime,
                    item.EndTime,item.Nrbar,item.Nrevent,item.Nriets);
                events.Add(vm);
            }

            return View(events);
        }
        public IActionResult EventIndividual(int id)
        {
            EventModel vm = logic.GetEvent(id);
            return View("EventIndividual",vm);
        }
        public IActionResult ChangeEvent()
        {
            return View("ChangeEvent");
        }

        public IActionResult Add()
        {
            return View("AddEvent");
        }

        public IActionResult AddEvent()
        {
            return View("AddEvent");
        }

        public IActionResult CreateEvent(string name, DateTime date, string description, DateTime starttime, DateTime endtime, int nrbar, int nrevent, int nriets)
        {
            EventModel newEvent = new EventModel(null, date, description, starttime, endtime, nrbar, nrevent, nriets);
            logic.AddEvent(newEvent);
            return RedirectToAction("EmployeeHome");
        }
    }
}