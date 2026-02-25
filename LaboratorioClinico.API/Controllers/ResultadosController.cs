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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resultado = _context.Resultados
                .Include(r => r.Paciente)
                .Include(r => r.Examen)
                .Include(r => r.RangoAceptable)
                .FirstOrDefault(r => r.Id == id);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpPost]
        public IActionResult Post(ResultadoExamen resultado)
        {
            var examen = _context.Examenes.Find(resultado.ExamenId);
            var rango = _context.Rangos.Find(resultado.RangoAceptableId);

            if (examen == null || rango == null)
                return BadRequest("Datos de examen o rango inválidos");

            
            if (resultado.Valor < rango.ValorMinimo || resultado.Valor > rango.ValorMaximo)
            {
            }

            _context.Resultados.Add(resultado);
            _context.SaveChanges();

            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ResultadoExamen resultado)
        {
            var existente = _context.Resultados.Find(id);
            if (existente == null)
                return NotFound();

            existente.PacienteId = resultado.PacienteId;
            existente.ExamenId = resultado.ExamenId;
            existente.Valor = resultado.Valor;
            existente.RangoAceptableId = resultado.RangoAceptableId;

            _context.SaveChanges();

            return Ok(existente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resultado = _context.Resultados.Find(id);
            if (resultado == null)
                return NotFound();

            _context.Resultados.Remove(resultado);
            _context.SaveChanges();

            return Ok();
        }
    }
}