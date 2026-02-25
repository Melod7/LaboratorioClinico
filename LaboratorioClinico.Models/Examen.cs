namespace LaboratorioClinico.Models
{
    public class Examen
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

        public ICollection<ResultadoExamen> Resultados { get; set; }
    }
}