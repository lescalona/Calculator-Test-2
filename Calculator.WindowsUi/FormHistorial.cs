using Calculator.WindowsUi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.WindowsUi.Common;
using System.Linq;
using AadiCapif.Sci.WindowsUi.Common;

namespace Calculator.WindowsUi
{
    public partial class FormHistorial : Form
    {
        public FormHistorial(HistorialViewModel model)
        {
            InitializeComponent();
            this.Bind(model);
            dgHistorial.AutoGenerateColumns = false;
            dgHistorial.Columns.Add(new DataGridViewTextBoxColumn()
                .Bind<DetallesHistorialViewModel>(m => m.Fecha)
                .SetDisplayName("Fecha")
                .AsReadonly()
                .With(column => column.DefaultCellStyle.Format = "dd/MM/yyyy")
                .With(column => column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells));
            dgHistorial.Columns.Add(new DataGridViewTextBoxColumn()
               .Bind<DetallesHistorialViewModel>(m => m.PrimerOperador)
               .SetDisplayName("Operando 1")
               .AsReadonly()
               .With(column => column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells));
            dgHistorial.Columns.Add(new DataGridViewTextBoxColumn()
               .Bind<DetallesHistorialViewModel>(m => m.Operacion)
               .SetDisplayName("Operación")
               .AsReadonly()
               .With(column => column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells));
            dgHistorial.Columns.Add(new DataGridViewTextBoxColumn()
               .Bind<DetallesHistorialViewModel>(m => m.SegundoOperador)
               .SetDisplayName("Operando 2")
               .AsReadonly()
               .With(column => column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells));
            dgHistorial.Columns.Add(new DataGridViewTextBoxColumn()
               .Bind<DetallesHistorialViewModel>(m => m.Resultado)
               .SetDisplayName("Resultado")
               .AsReadonly()
               .With(column => column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells));
            dgHistorial.BindSource(model, m => model.Detalles);
        }
    }
}
