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
        private DateTime fechaViaje;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private String auto;
        private Int32 turnoID;
        private Int32 clienteID;
        SqlDataReader dr;
        SqlConnection conexion = SqlGeneral.nuevaConexion();


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
            textBoxIniViaje.Clear();
            textBoxFinViaje.Clear();
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
            conexion.Close();
         }

        private void cbChoferes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String choferElegido = cbChoferes.SelectedItem.ToString();
            SqlCommand cmd = new SqlCommand("SELECT Auto_Patente FROM SQLGROUP.Automoviles JOIN SQLGROUP.Choferes ON Auto_Chofer = Chofer_Id WHERE Chofer_Nombre LIKE @choferElegido ", conexion);
            cmd.Parameters.AddWithValue("@choferElegido", choferElegido);
            conexion.Open();
            dr = cmd.ExecuteReader();
            lbAutoxChofer.Text = dr["Auto_Patente"].ToString();
            dr.Close();
            conexion.Close();
        }


    }
}
