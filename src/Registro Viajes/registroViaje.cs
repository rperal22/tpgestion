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
using UberFrba.Registro_Viajes;


namespace UberFrba.Registro_Viajes
{
    public partial class registroViaje : Form
     {
        private Cliente clienteSeleccionado;
        private Chofer choferSeleccionado;
        private Automovil auto;

        public registroViaje()
        {
            InitializeComponent();
            this.dtpHoraFin.Format = DateTimePickerFormat.Time;
            this.dtpHoraInicio.Format = DateTimePickerFormat.Time;
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraInicio.ShowUpDown = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbKM.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validar();
                new SqlViajes().cargarViaje(choferSeleccionado, float.Parse(tbKM.Text), this.cbTurno.SelectedValue as Turno, dtpHoraInicio.Value, dtpHoraFin.Value, auto, clienteSeleccionado);
                MessageBox.Show("Viaje se registro con exito");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Compruebe el campo kilometros.");
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
                this.actualizarAutomovil();
            }
        }

        private void buttonCambiarCliente_Click(object sender, EventArgs e)
        {
            var form = new seleccionarCliente();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.clienteSeleccionado = form.cli;
                this.labelCliente.Text = this.clienteSeleccionado.nombre + " " + this.clienteSeleccionado.apellido;
            }
        }

        private void actualizarAutomovil()
        {
            auto = new SqlChoferes().getAutoHabilitado(this.choferSeleccionado);
            lbAutoxChofer.Text = "Marca: " + auto.marca + " Patente: " + auto.patente;
            this.cbTurno.DisplayMember = "desc";
            this.cbTurno.ValueMember = "this";
            this.cbTurno.DataSource = auto.turnos;
        }

        private void validar()
        {
            Turno turno = (this.cbTurno.SelectedValue as Turno);
            if (choferSeleccionado == null && clienteSeleccionado == null && auto == null)
            {
                throw new SystemException("Completar datos obligatorios");
            }
            else if (dtpHoraInicio.Value > dtpHoraFin.Value)
            {
                throw new SystemException("Hora inicio dene ser menor que la final");
            }
            else if (!(dtpHoraInicio.Value.Hour > turno.hi && dtpHoraFin.Value.Hour < turno.hf))
            {
                throw new SystemException("Comprobar horarios dentro del limite del turno");
            }
        }

        private void cambioDeFecha(object sender, EventArgs e)
        {
            DateTime nueva = this.dayPicker.Value;
            nueva = nueva.AddMinutes(-nueva.Minute);
            nueva = nueva.AddHours(-nueva.Hour);
            int horasInicio = this.dtpHoraInicio.Value.Hour;
            int horasFin = this.dtpHoraFin.Value.Hour;
            int minutosInicio = this.dtpHoraInicio.Value.Minute;
            int minutosFin = this.dtpHoraFin.Value.Minute;

            this.dtpHoraInicio.Value = nueva;
            this.dtpHoraInicio.Value = this.dtpHoraInicio.Value.AddHours(horasInicio);
            this.dtpHoraInicio.Value = this.dtpHoraInicio.Value.AddMinutes(minutosInicio);
            this.dtpHoraFin.Value = nueva;
            this.dtpHoraFin.Value = this.dtpHoraFin.Value.AddHours(horasFin);
            this.dtpHoraFin.Value = this.dtpHoraFin.Value.AddMinutes(horasInicio);
        }

        private void cbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turno turno = (this.cbTurno.SelectedValue as Turno);
            this.labelInfoTurno.Text = "Hora Min: " + turno.hi + " Hora Max (no inclusive): " + turno.hf;
        }


    }
}
