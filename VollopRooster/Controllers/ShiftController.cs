using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using VollopRooster.Models;
using VollopRooster.ViewModels;

namespace VollopRooster.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftLogic logic;
        public ShiftController(IShiftLogic logic)
        {
            this.logic = logic;
        }
        public IActionResult ShiftHome()
        {
            List<ShiftViewModel> shifts = new List<ShiftViewModel>();
            foreach (var shift in logic.GetAllShifts())
            {
                ShiftViewModel vm = new ShiftViewModel(shift.Id, shift.Date);
                shifts.Add(vm);

            }
            return View("ShiftHome", shifts);
        }

        public IActionResult CreateShift(int id, TimeSpan starttime,TimeSpan endtime, DateTime date, string description, int nrofbar, int nrofevent, int nrofextra)
        {
            ShiftModel model = new ShiftModel(id,starttime,endtime,date,description,nrofbar,nrofevent,nrofextra);
            logic.AddShift(model);
            return RedirectToAction("ShiftHome");
        }

        public IActionResult ChangeShift(int id)
        {
            var model = logic.GetShift(id);
            var vm = new ShiftViewModel()
            {
                Id = model.Id,
                Date = model.Date,
                Description = model.Description,
                EndTime = model.EndTime,
                NrOfBar = model.NrOfBar,
                NrOfEvent = model.NrOfEvent,
                NrOfExtra = model.NrOfExtra,
                StartTime = model.StartTime
            };

            return View("ChangeShift",vm);
        }

        public IActionResult Add()
        {
            return View("AddShift");
        }

        public IActionResult ShiftIndividual(int id)
        {
            ShiftModel model = logic.GetShift(id);
            ShiftViewModel vm = new ShiftViewModel(model.Id,model.Description,model.Date,model.StartTime,model.EndTime,model.NrOfBar,model.NrOfEvent,model.NrOfExtra);

            return View("ShiftIndividual",vm);
        }

        public IActionResult RemoveShift(int id)
        {
            logic.RemoveShift(id);
            return RedirectToAction("ShiftHome");
        }

        public IActionResult UpdateShift(int id, string description, DateTime date, TimeSpan starttime, TimeSpan endtime, int nrofbar, int nrofevent, int nrofextra)
        {
            ShiftModel model = new ShiftModel
            {
                Id = id,
                Date = date,
                Description = description,
                EndTime = endtime,
                StartTime = starttime,
                NrOfBar = nrofbar,
                NrOfEvent = nrofevent,
                NrOfExtra = nrofextra
                
            };
            logic.UpdateShift(model);

            ShiftModel viewmodeltransfer = logic.GetShift(id);

            var vm = new ShiftViewModel
            {
                Id = viewmodeltransfer.Id,
                Date = viewmodeltransfer.Date,
                Description = viewmodeltransfer.Description,
                EndTime = viewmodeltransfer.EndTime,
                StartTime = viewmodeltransfer.StartTime,
                NrOfBar = viewmodeltransfer.NrOfBar,
                NrOfEvent = viewmodeltransfer.NrOfEvent,
                NrOfExtra = viewmodeltransfer.NrOfExtra
            };
            return RedirectToAction("ChangeShift", vm);
        }
    }
}