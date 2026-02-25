using Microsoft.AspNetCore.Mvc;
using LaboratorioClinico.Data;
using LaboratorioClinico.Models;

namespace LaboratorioClinico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenesController : ControllerBase
    {
        private readonly LaboratorioDbContext _context;

        public ExamenesController(LaboratorioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Examenes.ToList());
        }

        [HttpPost]
        public IActionResult Post(Examen examen)
        {
            _context.Examenes.Add(examen);
            _context.SaveChanges();
            return Ok(examen);
        }
    }
}