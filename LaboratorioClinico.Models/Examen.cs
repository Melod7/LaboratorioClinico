namespace LaboratorioClinico.Models
{
    public class Examen
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }

        public string TipoClinico { get; set; } = string.Empty;
        public ICollection<ResultadoExamen> Resultados { get; set; } = new List<ResultadoExamen>();
    }
}