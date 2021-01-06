using Calculator.WindowsUi.Common;
using System;
using System.IO;
using System.Windows.Forms;
using Calculator.WindowsUi.Models;

namespace Calculator.WindowsUi
{
    public partial class FormCalculator : Form
    {
        public FormCalculator(CalculatorViewModel model)
        {
            InitializeComponent();
            this.Bind(model);
            btnUno.Bind(model.PresionaUnoCommand);
            txtValorPantalla.BindValue(model, m => m.ValorPantalla);
            btnHistorial.Bind(model.VerHistorialCommand);
        }
    }
}
