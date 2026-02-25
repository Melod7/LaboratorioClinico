using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioClinico.Models
{
    public class RangoAceptable
    {
        public int Id { get; set; }
        public string NombreExamen { get; set; }
        public decimal ValorMinimo { get; set; }
        public decimal ValorMaximo { get; set; }
    }
}
