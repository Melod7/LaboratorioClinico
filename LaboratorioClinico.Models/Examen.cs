namespace LaboratorioClinico.Models
{
    public class Examen
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }

        public ICollection<ResultadoExamen> Resultados { get; set; }
    }
}