using Microsoft.AspNetCore.Mvc;
using Agenda.Data;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
