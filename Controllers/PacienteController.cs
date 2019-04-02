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

        // https://localhost:5001/Paciente/Edit/1
        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new SqliteDbContext())
            {
                var paciente = db.Pacientes.Find(id);
                if (paciente != null)
                {
                    return View(paciente);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, PacienteViewModel paciente)
        {
            if (ModelState.IsValid && id > 0)
            {
                using (var db = new SqliteDbContext())
                {
                    var pacienteExistente = db.Pacientes.Find(id);
                    if (pacienteExistente != null)
                    {
                        pacienteExistente.Nombre = paciente.Nombre;
                        pacienteExistente.Apellidos = paciente.Apellidos;
                        pacienteExistente.Edad = paciente.Edad;
                        pacienteExistente.Genero = paciente.Genero;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                using (var db = new SqliteDbContext())
                {
                    var paciente = db.Pacientes.Find(id);
                    db.Remove(paciente);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}