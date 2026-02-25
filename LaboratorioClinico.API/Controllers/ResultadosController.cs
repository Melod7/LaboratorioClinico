using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaboratorioClinico.Data;
using LaboratorioClinico.Models;

namespace LaboratorioClinico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadosController : ControllerBase
    {
        private readonly LaboratorioDbContext _context;

        public ResultadosController(LaboratorioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var resultados = _context.Resultados
                .Include(r => r.Paciente)
                .Include(r => r.Examen)
                .Include(r => r.RangoAceptable)
                .ToList();

            return Ok(resultados);
        }

        [HttpPost]
        public IActionResult Post(ResultadoExamen resultado)
        {
            _context.Resultados.Add(resultado);
            _context.SaveChanges();
            return Ok(resultado);
        }
    }
}