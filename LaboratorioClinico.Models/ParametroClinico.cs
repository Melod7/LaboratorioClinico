using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioClinico.Models
{
    public class ParametroClinico
    {
        public int Id { get; set; }
        public string NombreExamen { get; set; } = string.Empty;

        public decimal Bajo { get; set; }
        public decimal NormalMin { get; set; }
        public decimal NormalMax { get; set; }
        public decimal Alto { get; set; }
    }
}