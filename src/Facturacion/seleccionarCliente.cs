using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Entidades;
using UberFrba.SQL;

namespace UberFrba.Facturacion
{
    public partial class seleccionarCliente : Form
    {
        public Cliente cli { get; set; }
        public seleccionarCliente()
        {
            InitializeComponent();
            this.buttonLimpiar_Click(null, null);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxDNI.Clear();
            this.dataGridView1.DataSource = new BindingSource(new BindingList<Cliente>(new SqlClientes().getClientes(15)), null);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            String busqueda = "";
            if (textBoxNombre.TextLength > 0)
            {
                busqueda = busqueda + "Cliente_Nombre LIKE '%" + textBoxNombre.Text + "%'";
            }
            if (textBoxApellido.TextLength > 0)
            {
                if (!busqueda.Equals(""))
                {
                    busqueda = busqueda + " AND ";
                }
                busqueda = busqueda + "Cliente_Apellido LIKE '%" + textBoxApellido.Text + "%'";
            }

            if (textBoxDNI.TextLength > 0)
            {
                if (!busqueda.Equals(""))
                {
                    busqueda = busqueda + " AND ";
                }
                busqueda = busqueda + "Cliente_DNI LIKE '%" + textBoxDNI.Text + "%'";
            }
            busqueda = busqueda.Trim();
            if (busqueda.Equals(""))
            {
                this.buttonLimpiar_Click(null, null);
                return;
            }
            busqueda += " AND Cliente_Estado = 'Habilitado'";
            this.dataGridView1.DataSource = new BindingSource(new BindingList<Cliente>(new SqlClientes().getClientes(busqueda)), null);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void seleccionChofer(object sender, EventArgs e)
        {
            cli = this.dataGridView1.SelectedRows[0].DataBoundItem as Cliente;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
