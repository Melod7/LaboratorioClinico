using Microsoft.AspNetCore.Mvc;
using LaboratorioClinico.Data;
using LaboratorioClinico.Models;

namespace LaboratorioClinico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RangosController : ControllerBase
    {
        private readonly LaboratorioDbContext _context;

        public RangosController(LaboratorioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Rangos.ToList());
        }

        [HttpPost]
        public IActionResult Post(RangoAceptable rango)
        {
            _context.Rangos.Add(rango);
            _context.SaveChanges();
            return Ok(rango);
        }
    }
}