using Microsoft.AspNetCore.Mvc;
using PSIUWeb.Data.Interfaces;

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
    }
}
