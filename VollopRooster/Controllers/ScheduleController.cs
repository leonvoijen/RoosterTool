using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace VollopRooster.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleLogic _scheduleLogic;
        public ScheduleController(IScheduleLogic scheduleLogic)
        {
            _scheduleLogic = scheduleLogic;
        }

        public IActionResult ScheduleHome()
        {
            return View();
        }

        public IActionResult CreateSchedule(DateTime startdate, DateTime enddate)
        {
            startdate = DateTime.Now;
            enddate = DateTime.MaxValue;
            _scheduleLogic.CreateSchedule(startdate, enddate);
            return RedirectToAction("ScheduleHome");
        }

    }
}