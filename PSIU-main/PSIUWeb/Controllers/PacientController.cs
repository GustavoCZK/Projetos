using Microsoft.AspNetCore.Mvc;
using PSIUWeb.Data.Interfaces;
using PSIUWeb.Models;

namespace PSIUWeb.Controllers
{
    public class PacientController : Controller
    {
        private IPacientRepositor pacientRepositor;

        public  PacientController(IPacientRepositor _pacientRepo)
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
            if(ModelState.IsValid)
            {
                try
                {
                    pacientRepositor.Update(pacient);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
          
            }
            return View("Index");
        }
    }
}
