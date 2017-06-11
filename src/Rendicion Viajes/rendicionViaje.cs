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
            this.dateTimePicker1.Value = Program.dia;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                new SqlRendicion().guardarRendicion(this.dateTimePicker1.Value, this.choferSeleccionado, this.cbTurno.SelectedValue as Turno, float.Parse(this.textBoxPorcentaje.Text), float.Parse(this.labelTotal.Text));
                MessageBox.Show("Rendicion guardada correctamente");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Compruebe el porcentaje");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                this.dataGridView1.DataSource = new SqlViajes().getViajes(this.dateTimePicker1.Value, this.choferSeleccionado, this.cbTurno.SelectedValue as Turno);
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

        private void validar()
        {
            if (this.choferSeleccionado == null || this.cbTurno.SelectedValue == null || this.textBoxPorcentaje.TextLength == 0)
            {
                throw new SystemException("Complete los campos obligatorios");
            }
        }
    }
}
