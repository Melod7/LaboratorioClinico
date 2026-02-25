using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioClinico.Models
{
    public class ResultadoExamen
    {
        public int Id { get; set; }

        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; } 

        public int ExamenId { get; set; }
        public Examen Examen { get; set; }

        public decimal Valor { get; set; }

        public int RangoAceptableId { get; set; }
        public RangoAceptable RangoAceptable { get; set; }
    }
}