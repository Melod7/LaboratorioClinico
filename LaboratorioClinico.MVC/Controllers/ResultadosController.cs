using Microsoft.AspNetCore.Mvc;
using LaboratorioClinico.MVC.Services;
using LaboratorioClinico.Models;

namespace LaboratorioClinico.MVC.Controllers
{
    public class ResultadosController : Controller
    {
        private readonly ApiService _api;

        public ResultadosController(ApiService api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var resultados = await _api.GetAsync<ResultadoExamen>("resultados");
            return View(resultados);
        }
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ResultadoExamen resultado)
        {
            await _api.PostAsync("Resultados", resultado);
            return RedirectToAction("Index");
        }
    }
}