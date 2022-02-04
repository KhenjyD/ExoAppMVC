using Microsoft.AspNetCore.Mvc;
using Agenda.Data;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class BrokerController : Controller
    {
        private readonly AgendaDbConnect _db;

        public BrokerController (AgendaDbConnect maConnexion)
        {
            _db = maConnexion;
        }

        public IActionResult ListBrokers()
        {
            IEnumerable<Broker> Brokers = _db.Brokers;
            return View(Brokers);
        }

        public IActionResult AddBroker()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBroker(Broker bkr)
        {
            if (ModelState.IsValid)
            {
                _db.Brokers.Add(bkr);
                _db.SaveChanges();
                TempData["success"] = "le courtier a bien été ajouté";
                return RedirectToAction("ListBrokers");
            }
            
            return View();
        }


        public IActionResult ProfilBroker(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("ListBrokers");
            }

            var broker = _db.Brokers.Find(id);

            if (broker == null)
            {
                return NotFound();
            }

            return View(broker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProfilBroker(Broker bkr)
        {
            if (ModelState.IsValid)
            {
                _db.Brokers.Update(bkr);
                _db.SaveChanges();
                TempData["success"] = "le courtier a bien été modifier";
                return RedirectToAction("ListBrokers");
            }

            return View();
        }
    }
}
