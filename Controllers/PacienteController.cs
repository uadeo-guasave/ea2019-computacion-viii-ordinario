using System.Linq;
using C8ProyectoFinalPorEquipos.Models;
using Microsoft.AspNetCore.Mvc;

namespace C8ProyectoFinalPorEquipos.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new SqliteDbContext())
            {
                var pacientes = db.Pacientes.ToList();
                return View(pacientes);
            }
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(PacienteViewModel paciente)
        {
            if (paciente != null && ModelState.IsValid)
            {
                using (var db = new SqliteDbContext())
                {
                    db.Add(paciente);
                    db.SaveChanges();
                }
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

        }

        [HttpPost]
        public IActionResult Edit(int id, PacienteViewModel paciente)
        {
            
        }

        public IActionResult Delete(int id)
        {

        }
    }
}