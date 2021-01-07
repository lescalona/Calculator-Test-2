using Calculator.WindowsUi.Common;
using System.Collections.Generic;
using System.ComponentModel;

namespace Calculator.WindowsUi.Models
{
    public class HistorialViewModel: ViewModelBase, INotifyPropertyChanged
    {
        public List<DetallesHistorialViewModel> Detalles { get; set; }
        public HistorialViewModel()
        {
            var db = new HistoricoDB();
            Detalles = db.TraerHistorico();
        }
    }
}
