using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using UberFrba.SQL;

namespace UberFrba.Facturacion
{
    public partial class Facturar : Form
    {
        public Facturar()
        {
            InitializeComponent();
        }

        private DateTime fechaInicio;
        private DateTime fechaFin;
        private Int32 clienteID;
        private Decimal totalFacturado;
        private Int32 cantViajes;

        SqlConnection conexion = SqlGeneral.nuevaConexion(); 
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbImporteTotal.Clear();
            tbCantViajes.Clear();
        }

        
        private void Facturar_Load(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand cmdClientes = new SqlCommand("SELECT Cliente_Nombre, CLiente_Apellido FROM SQLGROUP.Clientes", conexion);
            dr = cmdClientes.ExecuteReader();
            while (dr.Read())
            {
                cbClientes.Items.Add(dr["Cliente_Nombre"].ToString() + "" + dr["Cliente_Apellido"].ToString());
            }
            dr.Close();
            conexion.Close();
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String clienteElegido = cbClientes.SelectedItem.ToString();
            string[] words;
            words = clienteElegido.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
            String nombreCliente = words[0];
            String apellidoCliente = words[1];

            SqlCommand obtenerIdCliente = new SqlCommand("SELECT Cliente_Id FROM SQLGROUP.Clientes WHERE Cliente_Nombre LIKE @nombreCliente AND Cliente_Apellido LIKE @apellidoCliente", conexion);
            obtenerIdCliente.Parameters.AddWithValue("@nombreCliente", nombreCliente);
            obtenerIdCliente.Parameters.AddWithValue("@apellidoCLiente", apellidoCliente);
            conexion.Open();
            dr = obtenerIdCliente.ExecuteReader();
            clienteID = Convert.ToInt32(dr["Cliente_Id"]);
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            fechaInicio = dtpInicio.Value;
            fechaFin = fechaInicio.AddMonths(1);
            lbFechaFin.Text = fechaFin.ToString();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SQLGROUP.consultaListaDeViajes", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
            cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFin));
            cmd.Parameters.Add(new SqlParameter("@clienteID", clienteID));
            conexion.Open();
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dgvListaViajes.DataSource = da;
            conexion.Close();

            cantViajes = dt.Rows.Count;
            tbCantViajes.Text = cantViajes.ToString();

            //Falta ver si se puede calcular el total facturado desde la data table


        }

        
    }
}
