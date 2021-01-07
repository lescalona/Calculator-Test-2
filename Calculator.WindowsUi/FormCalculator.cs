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
            //this.Bind(model);
            btnUno.Bind(model.PresionaUnoCommand);
            btnDos.Bind(model.PresionaDosCommand);
            btnTres.Bind(model.PresionaTesCommand);
            btnCuatro.Bind(model.PresionaCuatroCommand);
            btnCinco.Bind(model.PresionaCincoCommand);
            btnSeis.Bind(model.PresionaSeisCommand);
            btnSiete.Bind(model.PresionaSieteCommand);
            btnOcho.Bind(model.PresionaOchoCommand);
            btnNueve.Bind(model.PresionaNueveCommand);
            btnCero.Bind(model.PresionaCeroCommand);

            btnSuma.Bind(model.PresionaSumaCommand);
            btnResta.Bind(model.PresionaRestaCommand);
            btnMultiplica.Bind(model.PresionaMultiplicacionCommand);
            btnDivide.Bind(model.PresionaDivisionCommand);
            btnDecinal.Bind(model.PresionaComaCommand);
            btnLimpiar.Bind(model.PresionaClearCommand);
            btnResultado.Bind(model.PresionaResultadoCommand);
            txtValorPantalla.BindValue(model, m => m.ValorPantalla);
            btnHistorial.Bind(model.VerHistorialCommand);
        }
    }
}
