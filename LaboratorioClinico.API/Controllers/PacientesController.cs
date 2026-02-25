using Microsoft.AspNetCore.Mvc;
using LaboratorioClinico.Data;
using LaboratorioClinico.Models;

namespace LaboratorioClinico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly LaboratorioDbContext _context;

        public PacientesController(LaboratorioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Pacientes.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null) return NotFound();
            return Ok(paciente);
        }

        [HttpPost]
        public IActionResult Post(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return Ok(paciente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Paciente paciente)
        {
            var existente = _context.Pacientes.Find(id);
            if (existente == null) return NotFound();

            existente.Nombre = paciente.Nombre;
            existente.Cedula = paciente.Cedula;
            existente.FechaNacimiento = paciente.FechaNacimiento;

            _context.SaveChanges();
            return Ok(existente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var paciente = _context.Pacientes.Find(id);
            if (paciente == null) return NotFound();

            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();

            return Ok();
        }
    }
}