using Microsoft.AspNetCore.Mvc;
using Agenda.Data;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AgendaDbConnect _db;

        public AppointmentController(AgendaDbConnect maConnexion)
        {
            _db = maConnexion;
        }

        public List<Broker> GetAllBrokers()
        {
            List<Broker> brokers = new List<Broker>();

            foreach(var broker in _db.Brokers)
            {
                brokers.Add(broker);
            }

            return brokers;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            foreach(var customer in _db.Customers)
            {
                customers.Add(customer);
            }

            return customers;
        }

        public bool VerifyDateHour (Appointment apt)
        {
            bool correct = true;
            foreach (var appointment in _db.Appointments)
            {
                if (appointment.dateHour == apt.dateHour && appointment.idBroker == apt.idBroker)
                {
                    correct = false;
                }
            }
            
            return correct;
        }

        public IActionResult ListAppointments()
        {
            IEnumerable<Appointment> appointments = _db.Appointments;
            return View(appointments);
        }

        public IActionResult AddAppointment()
        {
            ViewBag.Brokers = GetAllBrokers();
            ViewBag.Customers = GetAllCustomers();
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAppointment(Appointment apt)
        {
            if (ModelState.IsValid && VerifyDateHour(apt))
            {
                _db.Appointments.Add(apt);
                _db.SaveChanges();
                TempData["success"] = "le rdv a bien été ajouté";
                return RedirectToAction("ListAppointments");
            }
            else
            {
                foreach(var broker in _db.Brokers)
                {
                    if(broker.idBroker == apt.idBroker)
                    {
                        TempData["fail"] = broker.lastname + " " + broker.firstname + " a déjà un rdv le " + apt.dateHour;
                    }
                }
                return RedirectToAction("AddAppointment");
            }

            return View();
        }

        public IActionResult InfoAppointment(int? id)
        {
            ViewBag.Brokers = GetAllBrokers();
            ViewBag.Customers = GetAllCustomers();

            if (id == null || id == 0)
            {
                return RedirectToAction("ListAppointments");
            }

            var appointment = _db.Appointments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        public IActionResult DeleteAppointment(int? id)
        {
            ViewBag.Brokers = GetAllBrokers();
            ViewBag.Customers = GetAllCustomers();

            if (id == null || id == 0)
            {
                return RedirectToAction("ListAppointments");
            }
            var appointment = _db.Appointments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpPost]
        public IActionResult DeleteAppointment(Appointment apt)
        {
            _db.Appointments.Remove(apt);
            _db.SaveChanges();

            TempData["success"] = "le rdv a bien été supprimé";

            return RedirectToAction("ListAppointments");
        }
    }
}
