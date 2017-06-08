using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.SQL;
using UberFrba.Entidades;
using System.Data.SqlClient;

namespace UberFrba.Facturacion
{
    public partial class Facturar : Form
    {
        private Cliente clienteSeleccionado;

        public Facturar()
        {
            InitializeComponent();
            this.dateTimePickerInicio.Value = this.dateTimePickerInicio.Value.AddMonths(1);
            this.clienteSeleccionado = null;
        }

        private void cambioDeFecha(object sender, EventArgs e)
        {

            this.dateTimePickerFin.Value = this.dateTimePickerInicio.Value.AddMonths(1).AddDays(-1);
            this.mostrarViajes();
        }

        private void buttonCambiarCliente_Click(object sender, EventArgs e)
        {
            var form = new seleccionarCliente();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.clienteSeleccionado = form.cli;
                this.labelCliente.Text = this.clienteSeleccionado.nombre + " " + this.clienteSeleccionado.apellido;
                this.mostrarViajes();
            }
        }

        private void mostrarViajes()
        {
            if (this.clienteSeleccionado != null)
            {
                dgvListaViajes.DataSource = new BindingSource(new BindingList<Viaje>(new SqlViajes().getViajes(this.dateTimePickerInicio.Value, this.dateTimePickerFin.Value, clienteSeleccionado)), null);
                this.labelCantidadViajes.Text = dgvListaViajes.Rows.Count.ToString();
                this.labelTotalFactura.Text = new SqlViajes().getFacturacionViajes(this.dateTimePickerInicio.Value, this.dateTimePickerFin.Value, clienteSeleccionado).ToString() ;
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                new SqlFacturacion().facturar(this.dateTimePickerInicio.Value, this.dateTimePickerFin.Value, clienteSeleccionado);
                MessageBox.Show("Factura guardada con exito");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
