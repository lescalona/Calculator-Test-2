using System;


namespace Calculator.WindowsUi.Models
{
    public class DetallesHistorialViewModel
    {
        public DateTime Fecha { get; set; }
        public string Operacion { get; set; }
        public decimal PrimerOperador { get; set; }
        public decimal SegundoOperador { get; set; }
        public decimal Resultado { get; set; } 
    }
}
