using LaboratorioClinico.Data;
using LaboratorioClinico.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioClinico.API.Controllers
{
    public class PacienteController
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

            [HttpPost]
            public IActionResult Post(Paciente paciente)
            {
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
                return Ok(paciente);
            }
        }
    }
}
