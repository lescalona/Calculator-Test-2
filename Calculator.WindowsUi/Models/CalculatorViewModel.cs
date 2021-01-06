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
        private readonly RelayCommand presionaSumaCommand;
        private readonly RelayCommand presionaResultadoCommand;
        private readonly RelayCommand verHistorialCommand;

        private string valorPantalla;

        public ICommand PresionaUnoCommand => presionaUnoCommand;
        public ICommand PresionaDosCommand => presionaDosCommand;
        public ICommand PresionaTesCommand => presionaTresCommand;
        public ICommand PresionaSumaCommand => presionaSumaCommand;
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
            presionaSumaCommand = new RelayCommand(PresionaSuma);
            presionaResultadoCommand = new RelayCommand(PresionaResultado);
            verHistorialCommand = new RelayCommand(VerHistorial);
        }

        private void PresionarUno()
        {
            
        }
        private void PresionaDos()
        {
            
        }
        private void PresionaTres()
        {
            
        }

        private void PresionaSuma()
        {
            
        }
        private void PresionaResultado()
        {
            
        }

        private void VerHistorial()
        {
            var historial = new FormHistorial(new HistorialViewModel());
            historial.Show();
        }
    }
}
