using Microsoft.EntityFrameworkCore;
using LaboratorioClinico.Models;

namespace LaboratorioClinico.Data
{
    public class LaboratorioDbContext : DbContext
    {
        public LaboratorioDbContext(DbContextOptions<LaboratorioDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<RangoAceptable> Rangos { get; set; }
        public DbSet<ResultadoExamen> Resultados { get; set; }
    }
}