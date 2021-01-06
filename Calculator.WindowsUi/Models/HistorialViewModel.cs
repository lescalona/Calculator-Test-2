using Calculator.WindowsUi.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.WindowsUi.Models
{
    public class HistorialViewModel: ViewModelBase, INotifyPropertyChanged
    {
        public List<DetallesHistorialViewModel> Detalles { get; set; }
        public HistorialViewModel()
        {

        }
    }
}
