using Microsoft.AspNetCore.Mvc;
using LaboratorioClinico.Models;
using LaboratorioClinico.MVC.Services;

namespace LaboratorioClinico.MVC.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ApiService _api;

        public PacientesController(ApiService api)
        {
            _api = api;
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Paciente paciente)
        {
            await _api.PostAsync("Pacientes", paciente);
            return RedirectToAction("Index", "Resultados");
        }
    }
}