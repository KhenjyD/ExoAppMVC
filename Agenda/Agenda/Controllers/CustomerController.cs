using Microsoft.AspNetCore.Mvc;
using Agenda.Data;
using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AgendaDbConnect _db;

        public CustomerController(AgendaDbConnect maConnexion)
        {
            _db = maConnexion;
        }

        public IActionResult ListCustomers()
        {
            IEnumerable<Customer> Customers = _db.Customers.FromSqlRaw("SELECT * FROM dbo.customers ORDER BY dbo.customers.lastname");
            return View(Customers);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomer(Customer cst)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Add(cst);
                _db.SaveChanges();
                TempData["success"] = "le client a bien été ajouté";
                return RedirectToAction("ListCustomers");
            }

            return View();
        }


        public IActionResult ProfilCustomer(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("ListCustomers");
            }

            var customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProfilCustomer(Customer cst)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(cst);
                _db.SaveChanges();
                TempData["success"] = "le client a bien été modifier";
                return RedirectToAction("ListCustomers");
            }

            return View();
        }

        public IActionResult DeleteCustomer(int? id)
        {
            if (id == null || id == 0)
            {
                return RedirectToAction("ListCustomers");
            }
            var customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult DeleteCustomer(Customer cst)
        {
            _db.Customers.Remove(cst);
            _db.SaveChanges();

            TempData["success"] = "le client a bien été supprimé";

            return RedirectToAction("ListCustomers");
        }
    }
}
