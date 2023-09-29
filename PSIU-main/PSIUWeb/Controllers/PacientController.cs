using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Data.Interfaces;
using PSIUWeb.Models;

namespace PSIUWeb.Controllers
{
    public class PacientController : Controller
    {
        private IPacientRepositor pacientRepositor;

        public PacientController(IPacientRepositor _pacientRepo)
        {
            pacientRepositor = _pacientRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(pacientRepositor.GetPacients());
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null)
                return NotFound();

            Pacient p = pacientRepositor.GetPacientById(id.Value);

            if (p == null)
                return NotFound();

            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pacientRepositor.Update(pacient);
                    return View("Index", pacientRepositor.GetPacients());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Pacient? p = pacientRepositor.GetPacientById(id.Value);

            if (p == null)
                return NotFound();

            return View(p);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteComfirmed(int id)
        {
            if (id == null || id == 0)
                return NotFound();
            pacientRepositor.Delete(id);

            return RedirectToAction( nameof(Index) );

        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Pacient p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pacientRepositor.Create(p);
                    return View("Index", pacientRepositor.GetPacients());
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return View();
        }
    }
}
