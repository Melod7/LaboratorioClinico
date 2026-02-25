using System;
using System.Collections.Generic;
using System.Text;


namespace LaboratorioClinico.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }= string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public ICollection<ResultadoExamen> Resultados { get; set; } = new List<ResultadoExamen>();

    }
}
