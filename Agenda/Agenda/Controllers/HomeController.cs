using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Agenda.Data;
using System.Diagnostics;

namespace Agenda.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly AgendaDbConnect _db;

        public HomeController(ILogger<HomeController> logger /*AgendaDbConnect maConnexion*/)
        {
            _logger = logger;
            //_db = maConnexion;
        }

        public IActionResult Index()
        {
            //IEnumerable<Appointment> appointments = _db.Appointments;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}