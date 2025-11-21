using Microsoft.AspNetCore.Mvc;
using ProyectoParqueo.Data;
using ProyectoParqueo.Models;
using System;
using System.Linq;

namespace ProyectoParqueo.Controllers
{
    public class ParqueoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParqueoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Registrar
        public IActionResult Registrar()
        {
            return View(new Vehiculo());
        }

        // POST: Registrar
        [HttpPost]
        public IActionResult Registrar(Vehiculo vehiculo)
        {
            if (!ModelState.IsValid)
                return View(vehiculo);

            vehiculo.HoraEntrada = DateTime.Now;
            vehiculo.Estado = "Dentro";
            vehiculo.HorasTotal = 0;
            vehiculo.Regalo = "N/A";

            try
            {
                _context.Vehiculos.Add(vehiculo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Muestra el error exacto si falla
                ModelState.AddModelError("", $"Error al guardar: {ex.Message}");
                return View(vehiculo);
            }

            return RedirectToAction("Listado");
        }

        // GET: Listado
        public IActionResult Listado()
        {
            var lista = _context.Vehiculos
                        .OrderByDescending(v => v.HoraEntrada)
                        .ToList();
            return View(lista);
        }

        // GET: Registrar salida
        public IActionResult Salida(int id)
        {
            var v = _context.Vehiculos.Find(id);

            if (v == null || v.Estado == "Fuera")
                return NotFound();

            v.HoraSalida = DateTime.Now;

            if (v.HoraEntrada.HasValue && v.HoraSalida.HasValue)
            {
                var horas = (v.HoraSalida.Value - v.HoraEntrada.Value).TotalHours;
                v.HorasTotal = (decimal)horas;

                var regalos = new string[] { "Limpiavidrios", "Vaselina", "Ambientador" };
                v.Regalo = horas > 10 ? regalos[new Random().Next(regalos.Length)] : "N/A";
            }
            else
            {
                v.HorasTotal = 0;
                v.Regalo = "N/A";
            }

            v.Estado = "Fuera";

            _context.SaveChanges();

            return RedirectToAction("Listado");
        }
    }
}
