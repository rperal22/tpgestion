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


namespace UberFrba.Registro_Viajes
{
    public partial class registroViaje : Form
     {

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
            textBoxKM.Clear();
        }

        private void registroViaje_Load(object sender, EventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT Chofer_Nombre FROM SQLGROUP.Choferes", conexion);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbChoferes.Items.Add(dr["Nombre_Chofer"].ToString());
            }
            dr.Close();
            SqlCommand cmdClientes = new SqlCommand("SELECT Cliente_Nombre, CLiente_Apellido FROM SQLGROUP.Clientes", conexion);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbClientes.Items.Add(dr["Cliente_Nombre"].ToString() + "" + dr["Cliente_Apellido"].ToString());
                
            }
            dr.Close();
            conexion.Close();
         }

        private void cbChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            chofer = cbChoferes.SelectedItem.ToString(); // CARGO EL NOMBRE DEL CHOFER
            SqlCommand cmd = new SqlCommand("SELECT Auto_Patente FROM SQLGROUP.Automoviles JOIN SQLGROUP.Choferes ON Auto_Chofer = Chofer_Id WHERE Chofer_Nombre LIKE @chofer ", conexion);
            cmd.Parameters.AddWithValue("@chofer", chofer);
            conexion.Open();
            dr = cmd.ExecuteReader();
            lbAutoxChofer.Text = dr["Auto_Patente"].ToString();
            auto = dr["Auto_Patente"].ToString(); // CARGO LA PATENTE DEL AUTO
            dr.Close();


            SqlCommand query = new SqlCommand("SELECT Turno_Descripcion FROM SQLGROUP.Turno ,SQLGROUP.Chofer_Turno, SQLGROUP.Choferes WHERE Chofer_Id = Ct_Chofer_Id AND Turno_Id = Ct_Turno_Id AND Chofer_Nombre LIKE @chofer Group BY Turno_Descripcion", conexion);
            query.Parameters.AddWithValue("@chofer", chofer);
            dr = query.ExecuteReader();
            while (dr.Read())
            {
                cbTurno.Items.Add(dr["Turno_Descripcion"].ToString());
            }
            dr.Close();
            conexion.Close();
         }

        private void cbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            turno = cbTurno.SelectedItem.ToString(); // CARGO EL TURNO
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String clienteElegido = cbClientes.SelectedItem.ToString();
            string[] words;
            words = clienteElegido.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
            nombreCliente = words[0];
            apellidoCliente= words[1];

            SqlCommand obtenerIdCliente = new SqlCommand("SELECT Cliente_Id FROM SQLGROUP.Clientes WHERE Cliente_Nombre LIKE @nombreCliente AND Cliente_Apellido LIKE @apellidoCliente",conexion);
            obtenerIdCliente.Parameters.AddWithValue("@nombreCliente", nombreCliente);
            obtenerIdCliente.Parameters.AddWithValue("@apellidoCLiente",apellidoCliente);
            conexion.Open();
            dr = obtenerIdCliente.ExecuteReader();
            clienteID = Convert.ToInt32(dr["Cliente_Id"]); // CARGO EL ID DEL CLIENTE
            
        }


    }
}
