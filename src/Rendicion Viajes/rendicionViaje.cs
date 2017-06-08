using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UberFrba.SQL;
using UberFrba.Entidades;



namespace UberFrba.Rendicion_Viajes
{
    public partial class rendicionViaje : Form
    {
        private Chofer choferSeleccionado;
        private float total;
        private Automovil auto;

        public rendicionViaje()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

        }

        private void buttonCambiarChofer_Click(object sender, EventArgs e)
        {
            var form = new seleccionarChofer();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.choferSeleccionado = form.cf;
                this.labelChofer.Text = this.choferSeleccionado.nombre + " " + this.choferSeleccionado.apellido;
                this.cbTurno.DisplayMember = "desc";
                this.cbTurno.ValueMember = "this";
                auto = new SqlChoferes().getAutoHabilitado(this.choferSeleccionado);
                labelAuto.Text = "Marca: " + auto.marca + " Patente: " + auto.patente;
                this.cbTurno.DataSource = auto.turnos;
                this.actualizarTablaViajes();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actualizarTablaViajes()
        {
            if (choferSeleccionado != null)
            {
                this.dataGridView1.DataSource = new BindingSource(new BindingList<Viaje>(new SqlViajes().getViajes(this.dateTimePicker1.Value,this.choferSeleccionado, this.cbTurno.SelectedValue as Turno)),null);
                this.total = new SqlRendicion().calcularRendicion(this.dateTimePicker1.Value, this.choferSeleccionado, (this.cbTurno.SelectedValue as Turno));
                this.actualizarTotal();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.actualizarTablaViajes();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.actualizarTotal();
        }

        private void actualizarTotal()
        {
            try
            {
                this.labelTotal.Text = (float.Parse(this.textBoxPorcentaje.Text) / 100 * this.total).ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Compruebe el porcentaje");
            }
        }

        private void cbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.actualizarTablaViajes();
        }
    }
}
