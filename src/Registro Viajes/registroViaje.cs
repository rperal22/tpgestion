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


namespace UberFrba.ABM_Chofer
{
    public partial class registroViaje : Form
     {
        Cliente clienteSeleccionado;
        Chofer choferSeleccionado;

        private String chofer;
        private Decimal kilometros;
        private String turno;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private String auto;
        private Int32 turnoID;
        private Int32 clienteID;


        SqlDataReader dr;
        SqlConnection conexion = SqlGeneral.nuevaConexion();
        private String nombreCliente;
        private String apellidoCliente;


        public registroViaje()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbKM.Clear();
        }



        private void cbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            turno = cbTurno.SelectedItem.ToString(); // CARGO EL Nombre del TURNO
            SqlCommand getIdTurno = new SqlCommand("SELECT Turno_Id FROM SQLGROUP.Turno WHERE Turno_Descripcion LIKE @turno", conexion);
            getIdTurno.Parameters.AddWithValue("@turno", turno);
            conexion.Open();
            dr = getIdTurno.ExecuteReader();
            turnoID = Convert.ToInt32(dr["Turno_Id"]); // CARGO el ID del turno
        }


        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            fechaInicio = dtpInicio.Value; // CARGO FECHA de inicio de viaje
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            fechaFin = dtpFin.Value; // CARGO FECHA de fin de viaje
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (tbKM.Text != null)
            {
                kilometros = Convert.ToDecimal(tbKM.Text); // CARGO KMs
                int resultado = new SqlCargaViajes().cargarViaje(chofer, kilometros, turno, fechaInicio, fechaFin, auto,turnoID, clienteID);
                switch(resultado)
                {
                    case 0:
                        MessageBox.Show("El chofer elegido no trabaja en el turno seleccionado");
                        break;
                    case 1:
                        MessageBox.Show("Ya tiene un viaje para la fecha y hora elegida");
                        break;
                    case 2:
                        MessageBox.Show("Viaje registrado correctamente");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacios");
            }
        }

        private void buttonCambiarChofer_Click(object sender, EventArgs e)
        {
            var form = new seleccionarChofer();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.choferSeleccionado = form.cf;
                this.labelChofer.Text = this.choferSeleccionado.nombre + " " + this.choferSeleccionado.apellido;
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


    }
}
