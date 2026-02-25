using Microsoft.AspNetCore.Mvc;
using LaboratorioClinico.Models;
using LaboratorioClinico.MVC.Services;

namespace LaboratorioClinico.MVC.Controllers
{
    public class ExamenesController : Controller
    {
        private readonly ApiService _api;

        public ExamenesController(ApiService api)
        {
            _api = api;
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Examen examen)
        {
            await _api.PostAsync("Examenes", examen);
            return RedirectToAction("Index", "Resultados");
        }
    }
}