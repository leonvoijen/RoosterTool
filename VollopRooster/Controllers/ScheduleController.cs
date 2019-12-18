using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VollopRooster.Controllers
{
    public class ScheduleController : Controller
    {
        public IActionResult ScheduleHome()
        {
            return View();
        }

        public IActionResult ChangeSchedule()
        {
            return View();
        }
    }
}