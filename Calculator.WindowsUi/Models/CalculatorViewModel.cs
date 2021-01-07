using Calculator.WindowsUi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.WindowsUi.Models
{
    public class CalculatorViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private readonly RelayCommand presionaUnoCommand;
        private readonly RelayCommand presionaDosCommand;
        private readonly RelayCommand presionaTresCommand;
        private readonly RelayCommand presionaCuatroCommand;
        private readonly RelayCommand presionaCincoCommand;
        private readonly RelayCommand presionaSeisCommand;
        private readonly RelayCommand presionaSieteCommand;
        private readonly RelayCommand presionaOchoCommand;
        private readonly RelayCommand presionaNueveCommand;
        private readonly RelayCommand presionaCeroCommand;

        private readonly RelayCommand presionaSumaCommand;
        private readonly RelayCommand presionaRestaCommand;
        private readonly RelayCommand presionaMultiplicacionCommand;
        private readonly RelayCommand presionaDivisionCommand;
        private readonly RelayCommand presionaComaCommand;

        private readonly RelayCommand presionaClearCommand;
        private readonly RelayCommand presionaResultadoCommand;
        private readonly RelayCommand verHistorialCommand;

        private string valorPantalla;
        private string Operacion;
        private string Operando1;
        private string Operando2;

        public ICommand PresionaUnoCommand => presionaUnoCommand;
        public ICommand PresionaDosCommand => presionaDosCommand;
        public ICommand PresionaTesCommand => presionaTresCommand;
        public ICommand PresionaCuatroCommand => presionaCuatroCommand;
        public ICommand PresionaCincoCommand => presionaCincoCommand;
        public ICommand PresionaSeisCommand => presionaSeisCommand;
        public ICommand PresionaSieteCommand => presionaSieteCommand;
        public ICommand PresionaOchoCommand => presionaOchoCommand;
        public ICommand PresionaNueveCommand => presionaNueveCommand;
        public ICommand PresionaCeroCommand => presionaCeroCommand;
        public ICommand PresionaSumaCommand => presionaSumaCommand;
        public ICommand PresionaRestaCommand => presionaRestaCommand;
        public ICommand PresionaMultiplicacionCommand => presionaMultiplicacionCommand;
        public ICommand PresionaDivisionCommand => presionaDivisionCommand;
        public ICommand PresionaComaCommand => presionaComaCommand;
        public ICommand PresionaClearCommand => presionaClearCommand;
        public ICommand PresionaResultadoCommand => presionaResultadoCommand;
        public ICommand VerHistorialCommand => verHistorialCommand;

        public string ValorPantalla
        {
            get { return valorPantalla; }
            set { SetProperty(ref valorPantalla, value, nameof(ValorPantalla)); }
        }

        public CalculatorViewModel()
        {
            presionaUnoCommand = new RelayCommand(PresionarUno);
            presionaDosCommand = new RelayCommand(PresionaDos);
            presionaTresCommand = new RelayCommand(PresionaTres);
            presionaCuatroCommand = new RelayCommand(PresionaCuatro);
            presionaCincoCommand = new RelayCommand(PresionaCinco);
            presionaSeisCommand = new RelayCommand(PresionaSeis);
            presionaSieteCommand = new RelayCommand(PresionaSiete);
            presionaOchoCommand = new RelayCommand(PresionaOcho);
            presionaNueveCommand = new RelayCommand(PresionaNueve);
            presionaCeroCommand = new RelayCommand(PresionaCero);

            presionaSumaCommand = new RelayCommand(PresionaSuma);
            presionaRestaCommand = new RelayCommand(PresionaResta);
            presionaMultiplicacionCommand = new RelayCommand(PresionaMultiplicacion);
            presionaDivisionCommand = new RelayCommand(PresionaDivision);
            presionaComaCommand = new RelayCommand(PresionaComa);
            presionaClearCommand = new RelayCommand(PresionaClear);
            presionaResultadoCommand = new RelayCommand(PresionaResultado);
            verHistorialCommand = new RelayCommand(VerHistorial);
        }

        private void PresionarUno()
        {
            ValorPantalla = ValorPantalla + "1";
        }
        private void PresionaDos()
        {
            ValorPantalla = ValorPantalla + "2";
        }
        private void PresionaTres()
        {
            ValorPantalla = ValorPantalla + "3";
        }

        private void PresionaCuatro()
        {
            ValorPantalla = ValorPantalla + "4";
        }

        private void PresionaCinco()
        {
            ValorPantalla = ValorPantalla + "5";
        }

        private void PresionaSeis()
        {
            ValorPantalla = ValorPantalla + "6";
        }

        private void PresionaSiete()
        {
            ValorPantalla = ValorPantalla + "7";
        }

        private void PresionaOcho()
        {
            ValorPantalla = ValorPantalla + "8";
        }

        private void PresionaNueve()
        {
            ValorPantalla = ValorPantalla + "9";
        }

        private void PresionaCero()
        {
            ValorPantalla = ValorPantalla + "0";
        }


        private void PresionaSuma()
        {
            Operacion = "+";
            Operando1 = ValorPantalla;
            ValorPantalla = "";
        }

        private void PresionaResta()
        {
            Operacion = "-";
            Operando1 = ValorPantalla;
            ValorPantalla = "";
        }

        private void PresionaMultiplicacion()
        {
            Operacion = "*";
            Operando1 = ValorPantalla;
            ValorPantalla = "";
        }

        private void PresionaDivision()
        {
            Operacion = "/";
            Operando1 = ValorPantalla;
            ValorPantalla = "";
        }

        private void PresionaComa()
        {
            ValorPantalla = ValorPantalla + ",";
        }

        private void PresionaClear()
        {
            ValorPantalla = "";
            Operando1 = "";
            Operando2 = "";
            Operacion = "";
        }

        private void PresionaResultado()
        {
            var dB = new HistoricoDB();
            Operando2 = valorPantalla;

            switch (Operacion)
            {
                case "+":
                    var resultadoSuma = (float.Parse(Operando1) + float.Parse(Operando2));
                    ValorPantalla = resultadoSuma.ToString();
                    dB.GuardarHistorico("Suma", float.Parse(Operando1), float.Parse(Operando2), resultadoSuma);
                    break;

                case "-":
                    var resultadoResta = (float.Parse(Operando1) - float.Parse(Operando2));
                    ValorPantalla = resultadoResta.ToString();
                    dB.GuardarHistorico("Suma", float.Parse(Operando1), float.Parse(Operando2), resultadoResta);
                    break;

                case "*":
                    var resultadoMultiplicacion = (float.Parse(Operando1) * float.Parse(Operando2));
                    ValorPantalla = resultadoMultiplicacion.ToString();
                    dB.GuardarHistorico("Suma", float.Parse(Operando1), float.Parse(Operando2), resultadoMultiplicacion);
                    break;

                case "/":
                    var resultadoDivision = (float.Parse(Operando1) / float.Parse(Operando2));
                    ValorPantalla = resultadoDivision.ToString();
                    dB.GuardarHistorico("Suma", float.Parse(Operando1), float.Parse(Operando2), resultadoDivision);
                    break;
                default:

                    break;
            }
        }

        private void VerHistorial()
        {
            var historial = new FormHistorial(new HistorialViewModel());
            historial.Show();
        }
    }
}
